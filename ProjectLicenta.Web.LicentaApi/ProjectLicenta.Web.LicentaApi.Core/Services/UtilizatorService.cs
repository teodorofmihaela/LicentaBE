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
    public class UtilizatorService : IUtilizatorService
    {
        private IUtilizatorRepository _repository;
        private IUtilizatorValidator _utilizatorValidator;
        private const int MaxPagination = 9999;

        public UtilizatorService(IUtilizatorRepository repository, IUtilizatorValidator utilizatorValidator)
        {
            _repository = repository;
            _utilizatorValidator = utilizatorValidator;
        }

        public async Task<List<Utilizator>> GetAllUtilizatori(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0)
        {
            return await _repository.GetAllUtilizatori(
                new UtilizatorFilter() {ToSearch = toSearch, Ids = guids}, pagination, skip);
        }

        public async Task<bool> CreateUtilizator(Utilizator inputUtilizator)
        {
            _utilizatorValidator.Validate(inputUtilizator);
            var nameAlikeUtilizatori = await _repository.GetAllUtilizatori(
                new UtilizatorFilter {ToSearch = inputUtilizator.Nume,}, MaxPagination);

            var idAlikeUtilizatori = await _repository.GetAllUtilizatori(
                new UtilizatorFilter {Ids = new List<Guid>() {inputUtilizator.Id}}, MaxPagination);

            if (idAlikeUtilizatori.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Utilizator already exists in the repository !",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };

            if (nameAlikeUtilizatori.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Utilizator name is not unique !",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            return await _repository.CreateUtilizator(inputUtilizator);
        }

        public async Task<bool> DeleteUtilizator(string toSearch, List<Guid> guids)
        {
            var utilizatoriToDelete = await _repository.GetAllUtilizatori(
                new UtilizatorFilter {ToSearch = toSearch, Ids = guids, PerfectMatch = true}, MaxPagination);

            if (!utilizatoriToDelete.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Utilizator is not in the repository.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            var result = true;

            foreach (var utilizator in utilizatoriToDelete)
                result = result && await _repository.DeleteUtilizator(utilizator.Id);
            return result;
        }

        public async Task<bool> UpdateUtilizator(Utilizator inputUtilizator)
        {
            _utilizatorValidator.Validate(inputUtilizator);

            var sameIdUtilizatori =
                await _repository.GetAllUtilizatori(new UtilizatorFilter {Ids = new List<Guid> {inputUtilizator.Id}});

            if (sameIdUtilizatori.Count != 1)
                throw new ApiException
                {
                    ExceptionMessage = $"Utilizator with id {inputUtilizator.Id} to update has not been found.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            if (inputUtilizator.Nume != sameIdUtilizatori.First().Nume)
            {
                var sameNumeUtilizatori = await _repository.GetAllUtilizatori(
                    new UtilizatorFilter {ToSearch = inputUtilizator.Nume, PerfectMatch = true});
                if (sameNumeUtilizatori.Any(s => s.Id != inputUtilizator.Id))
                    throw new ApiException
                    {
                        ExceptionMessage = $"Cannot update utilizator name to one that already exists : {inputUtilizator.Nume}.",
                        Severity = ExceptionSeverity.Error,
                        Type = ExceptionType.ServiceException
                    };
            }

            var utilizator = sameIdUtilizatori.First();
            utilizator.UpdateByReflection(inputUtilizator);
            return await _repository.UpdateUtilizator(utilizator);
        }
    }
}