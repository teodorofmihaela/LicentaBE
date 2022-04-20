using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;
using Microsoft.Extensions.Logging;
using ProjectLicenta.Web.LicentaApi.Core.Enums;
using ProjectLicenta.Web.LicentaApi.Core.Exceptions;
using ProjectLicenta.Web.LicentaApi.Core.Extensions;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Validators;

namespace ProjectLicenta.Web.LicentaApi.Core.Services
{
    public class AnuntService : IAnuntService
    {
        private IAnuntRepository _repository;
        private IAnuntValidator _anuntValidator;
        private const int MaxPagination = 9999;

        public AnuntService(IAnuntRepository repository, IAnuntValidator anuntValidator)
        {
            _repository = repository;
            _anuntValidator = anuntValidator;
        }

        public async Task<List<Anunt>> GetAllAnunturi(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0)
        {
            return await _repository.GetAllAnunturi(
                new AnuntFilter() {ToSearch = toSearch, Ids = guids}, pagination, skip);
        }

        public async Task<bool> CreateAnunt(Anunt inputAnunt)
        {
            _anuntValidator.Validate(inputAnunt);
            var nameAlikeAnunturi = await _repository.GetAllAnunturi(
                new AnuntFilter {ToSearch = inputAnunt.Text,}, MaxPagination);

            var idAlikeAnunturi = await _repository.GetAllAnunturi(
                new AnuntFilter {Ids = new List<Guid>() {inputAnunt.Id}}, MaxPagination);

            if (idAlikeAnunturi.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Anunt already exists in the repository !",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };

            if (nameAlikeAnunturi.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Anunt name is not unique !",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            return await _repository.CreateAnunt(inputAnunt);
        }

        public async Task<bool> DeleteAnunt(string toSearch, List<Guid> guids)
        {
            var anunturiToDelete = await _repository.GetAllAnunturi(
                new AnuntFilter {ToSearch = toSearch, Ids = guids, PerfectMatch = true}, MaxPagination);

            if (!anunturiToDelete.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Anunt is not in the repository.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            var result = true;

            foreach (var anunt in anunturiToDelete)
                result = result && await _repository.DeleteAnunt(anunt.Id);
            return result;
        }

        public async Task<bool> UpdateAnunt(Anunt inputAnunt)
        {
            _anuntValidator.Validate(inputAnunt);

            var sameIdAnunturi =
                await _repository.GetAllAnunturi(new AnuntFilter {Ids = new List<Guid> {inputAnunt.Id}});

            if (sameIdAnunturi.Count != 1)
                throw new ApiException
                {
                    ExceptionMessage = $"Anunt with id {inputAnunt.Id} to update has not been found.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            if (inputAnunt.Text != sameIdAnunturi.First().Text)
            {
                var sameTextAnunturi = await _repository.GetAllAnunturi(
                    new AnuntFilter {ToSearch = inputAnunt.Text, PerfectMatch = true});
                if (sameTextAnunturi.Any(s => s.Id != inputAnunt.Id))
                    throw new ApiException
                    {
                        ExceptionMessage = $"Cannot update anunt name to one that already exists : {inputAnunt.Text}.",
                        Severity = ExceptionSeverity.Error,
                        Type = ExceptionType.ServiceException
                    };
            }

            var anunt = sameIdAnunturi.First();
            anunt.UpdateByReflection(inputAnunt);
            return await _repository.UpdateAnunt(anunt);
        }
    }
}