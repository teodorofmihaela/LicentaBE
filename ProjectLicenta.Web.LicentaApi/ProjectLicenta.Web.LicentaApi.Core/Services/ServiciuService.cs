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
    public class ServiciuService : IServiciuService
    {
        private IServiciuRepository _repository;
        private IServiciuValidator _serviciuValidator;
        private const int MaxPagination = 9999;

        public ServiciuService(IServiciuRepository repository, IServiciuValidator serviciuValidator)
        {
            _repository = repository;
            _serviciuValidator = serviciuValidator;
        }

        public async Task<List<Serviciu>> GetAllServicii(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0)
        {
            return await _repository.GetAllServicii(
                new ServiciuFilter() {ToSearch = toSearch, Ids = guids}, pagination, skip);
        }

        public async Task<bool> CreateServiciu(Serviciu inputServiciu)
        {
            _serviciuValidator.Validate(inputServiciu);
            // var nameAlikeServicii = await _repository.GetAllServicii(
            //     new ServiciuFilter {ToSearch = inputServiciu.Nume,}, MaxPagination);

            var idAlikeServicii = await _repository.GetAllServicii(
                new ServiciuFilter {Ids = new List<Guid>() {inputServiciu.Id}}, MaxPagination);

            if (idAlikeServicii.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Serviciu already exists in the repository !",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };

            // if (nameAlikeServicii.Any())
            //     throw new ApiException
            //     {
            //         ExceptionMessage = "Serviciu name is not unique !",
            //         Severity = ExceptionSeverity.Error,
            //         Type = ExceptionType.ServiceException
            //     };
            return await _repository.CreateServiciu(inputServiciu);
        }

        public async Task<bool> DeleteServiciu(string toSearch, List<Guid> guids)
        {
            var serviciiToDelete = await _repository.GetAllServicii(
                new ServiciuFilter {ToSearch = toSearch, Ids = guids, PerfectMatch = true}, MaxPagination);

            if (!serviciiToDelete.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Serviciu is not in the repository.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            var result = true;

            foreach (var serviciu in serviciiToDelete)
                result = result && await _repository.DeleteServiciu(serviciu.Id);
            return result;
        }

        public async Task<bool> UpdateServiciu(Serviciu inputServiciu)
        {
            _serviciuValidator.Validate(inputServiciu);

            var sameIdServicii =
                await _repository.GetAllServicii(new ServiciuFilter {Ids = new List<Guid> {inputServiciu.Id}});

            if (sameIdServicii.Count != 1)
                throw new ApiException
                {
                    ExceptionMessage = $"Serviciu with id {inputServiciu.Id} to update has not been found.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            // if (inputServiciu.Nume != sameIdServicii.First().Nume)
            // {
            //     var sameNumeServicii = await _repository.GetAllServicii(
            //         new ServiciuFilter {ToSearch = inputServiciu.Nume, PerfectMatch = true});
            //     if (sameNumeServicii.Any(s => s.Id != inputServiciu.Id))
            //         throw new ApiException
            //         {
            //             ExceptionMessage = $"Cannot update serviciu name to one that already exists : {inputServiciu.Nume}.",
            //             Severity = ExceptionSeverity.Error,
            //             Type = ExceptionType.ServiceException
            //         };
            // }

            var serviciu = sameIdServicii.First();
            serviciu.UpdateByReflection(inputServiciu);
            return await _repository.UpdateServiciu(serviciu);
        }
    }
}