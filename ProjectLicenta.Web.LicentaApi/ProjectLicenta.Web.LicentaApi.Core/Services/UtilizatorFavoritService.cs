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
    public class UtilizatorFavoritService : IUtilizatorFavoritService
    {
        private IUtilizatorFavoritRepository _repository;
        private IUtilizatorFavoritValidator _utilizatorFavoritValidator;
        private const int MaxPagination = 9999;

        public UtilizatorFavoritService(IUtilizatorFavoritRepository repository, IUtilizatorFavoritValidator utilizatorFavoritValidator)
        {
            _repository = repository;
            _utilizatorFavoritValidator = utilizatorFavoritValidator;
        }

        public async Task<List<AnuntFavorit>> GetAllUtilizatoriFavoriti(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0)
        {
            return await _repository.GetAllUtilizatoriFavoriti(
                new UtilizatorFavoritFilter() {ToSearch = toSearch, Ids = guids}, pagination, skip);
        }

        public async Task<bool> CreateUtilizatorFavorit(AnuntFavorit inputAnuntFavorit)
        {
            _utilizatorFavoritValidator.Validate(inputAnuntFavorit);
            // var nameAlikeUtilizatorFavoritiFavoriti = await _repository.GetAllUtilizatorFavoritiFavoriti(
            //     new UtilizatorFavoritFilter {ToSearch = inputUtilizatorFavorit.Nume,}, MaxPagination);

            var idAlikeUtilizatorFavoritiFavoriti = await _repository.GetAllUtilizatoriFavoriti(
                new UtilizatorFavoritFilter {Ids = new List<Guid>() {inputAnuntFavorit.Id}}, MaxPagination);

            if (idAlikeUtilizatorFavoritiFavoriti.Any())
                throw new ApiException
                {
                    ExceptionMessage = "UtilizatorFavorit already exists in the repository !",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };

            // if (nameAlikeUtilizatorFavoritiFavoriti.Any())
            //     throw new ApiException
            //     {
            //         ExceptionMessage = "UtilizatorFavorit name is not unique !",
            //         Severity = ExceptionSeverity.Error,
            //         Type = ExceptionType.ServiceException
            //     };
            return await _repository.CreateUtilizatorFavorit(inputAnuntFavorit);
        }

        public async Task<bool> DeleteUtilizatorFavorit(string toSearch, List<Guid> guids)
        {
            var utilizatorFavoritiFavoritiToDelete = await _repository.GetAllUtilizatoriFavoriti(
                new UtilizatorFavoritFilter {ToSearch = toSearch, Ids = guids, PerfectMatch = true}, MaxPagination);

            if (!utilizatorFavoritiFavoritiToDelete.Any())
                throw new ApiException
                {
                    ExceptionMessage = "UtilizatorFavorit is not in the repository.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            var result = true;

            foreach (var utilizatorFavorit in utilizatorFavoritiFavoritiToDelete)
                result = result && await _repository.DeleteUtilizatorFavorit(utilizatorFavorit.Id);
            return result;
        }

        public async Task<bool> UpdateUtilizatorFavorit(AnuntFavorit inputAnuntFavorit)
        {
            _utilizatorFavoritValidator.Validate(inputAnuntFavorit);

            var sameIdUtilizatorFavoritiFavoriti =
                await _repository.GetAllUtilizatoriFavoriti(new UtilizatorFavoritFilter {Ids = new List<Guid> {inputAnuntFavorit.Id}});

            if (sameIdUtilizatorFavoritiFavoriti.Count != 1)
                throw new ApiException
                {
                    ExceptionMessage = $"UtilizatorFavorit with id {inputAnuntFavorit.Id} to update has not been found.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            // if (inputUtilizatorFavorit.Nume != sameIdUtilizatorFavoritiFavoriti.First().Nume)
            // {
            //     var sameNumeUtilizatorFavoritiFavoriti = await _repository.GetAllUtilizatorFavoritiFavoriti(
            //         new UtilizatorFavoritFilter {ToSearch = inputUtilizatorFavorit.Nume, PerfectMatch = true});
            //     if (sameNumeUtilizatorFavoritiFavoriti.Any(s => s.Id != inputUtilizatorFavorit.Id))
            //         throw new ApiException
            //         {
            //             ExceptionMessage = $"Cannot update utilizatorFavorit name to one that already exists : {inputUtilizatorFavorit.Nume}.",
            //             Severity = ExceptionSeverity.Error,
            //             Type = ExceptionType.ServiceException
            //         };
            // }

            var utilizatorFavorit = sameIdUtilizatorFavoritiFavoriti.First();
            utilizatorFavorit.UpdateByReflection(inputAnuntFavorit);
            return await _repository.UpdateUtilizatorFavorit(utilizatorFavorit);
        }
    }
}