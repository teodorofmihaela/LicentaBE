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
    public class AnuntPrestatService : IAnuntPrestatService
    {
        private IAnuntPrestatRepository _repository;
        private IAnuntPrestatValidator _anuntPrestatValidator;
        private const int MaxPagination = 9999;

        public AnuntPrestatService(IAnuntPrestatRepository repository, IAnuntPrestatValidator anuntPrestatValidator)
        {
            _repository = repository;
            _anuntPrestatValidator = anuntPrestatValidator;
        }

        public async Task<List<AnuntPrestat>> GetAllAnunturiPrestate(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0)
        {
            return await _repository.GetAllAnunturiPrestate(
                new AnuntPrestatFilter() {ToSearch = toSearch, Ids = guids}, pagination, skip);
        }

        public async Task<bool> CreateAnuntPrestat(AnuntPrestat inputAnuntPrestat)
        {
            _anuntPrestatValidator.Validate(inputAnuntPrestat);
            // var nameAlikeAnunturiPrestate = await _repository.GetAllAnunturiPrestate(
            //     new AnuntPrestatFilter {ToSearch = inputAnuntPrestat.Nume,}, MaxPagination);

            var idAlikeAnunturiPrestate = await _repository.GetAllAnunturiPrestate(
                new AnuntPrestatFilter {Ids = new List<Guid>() {inputAnuntPrestat.Id}}, MaxPagination);

            if (idAlikeAnunturiPrestate.Any())
                throw new ApiException
                {
                    ExceptionMessage = "AnuntPrestat already exists in the repository !",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };

            // if (nameAlikeAnunturiPrestate.Any())
            //     throw new ApiException
            //     {
            //         ExceptionMessage = "AnuntPrestat name is not unique !",
            //         Severity = ExceptionSeverity.Error,
            //         Type = ExceptionType.ServiceException
            //     };
            return await _repository.CreateAnuntPrestat(inputAnuntPrestat);
        }

        public async Task<bool> DeleteAnuntPrestat(string toSearch, List<Guid> guids)
        {
            var anunturiPrestateToDelete = await _repository.GetAllAnunturiPrestate(
                new AnuntPrestatFilter {ToSearch = toSearch, Ids = guids, PerfectMatch = true}, MaxPagination);

            if (!anunturiPrestateToDelete.Any())
                throw new ApiException
                {
                    ExceptionMessage = "AnuntPrestat is not in the repository.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            var result = true;

            foreach (var anuntPrestat in anunturiPrestateToDelete)
                result = result && await _repository.DeleteAnuntPrestat(anuntPrestat.Id);
            return result;
        }

        public async Task<bool> UpdateAnuntPrestat(AnuntPrestat inputAnuntPrestat)
        {
            _anuntPrestatValidator.Validate(inputAnuntPrestat);

            var sameIdAnunturiPrestate =
                await _repository.GetAllAnunturiPrestate(new AnuntPrestatFilter {Ids = new List<Guid> {inputAnuntPrestat.Id}});

            if (sameIdAnunturiPrestate.Count != 1)
                throw new ApiException
                {
                    ExceptionMessage = $"AnuntPrestat with id {inputAnuntPrestat.Id} to update has not been found.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            // if (inputAnuntPrestat.Nume != sameIdAnunturiPrestate.First().Nume)
            // {
            //     var sameNumeAnunturiPrestate = await _repository.GetAllAnunturiPrestate(
            //         new AnuntPrestatFilter {ToSearch = inputAnuntPrestat.Nume, PerfectMatch = true});
            //     if (sameNumeAnunturiPrestate.Any(s => s.Id != inputAnuntPrestat.Id))
            //         throw new ApiException
            //         {
            //             ExceptionMessage = $"Cannot update anuntPrestat name to one that already exists : {inputAnuntPrestat.Nume}.",
            //             Severity = ExceptionSeverity.Error,
            //             Type = ExceptionType.ServiceException
            //         };
            // }

            var anuntPrestat = sameIdAnunturiPrestate.First();
            anuntPrestat.UpdateByReflection(inputAnuntPrestat);
            return await _repository.UpdateAnuntPrestat(anuntPrestat);
        }
    }
}