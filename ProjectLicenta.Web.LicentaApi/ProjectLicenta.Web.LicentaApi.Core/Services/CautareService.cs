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
    public class CautareService : ICautareService
    {
        private ICautareRepository _repository;
        private ICautareValidator _cautareValidator;
        private const int MaxPagination = 9999;

        public CautareService(ICautareRepository repository, ICautareValidator cautareValidator)
        {
            _repository = repository;
            _cautareValidator = cautareValidator;
        }

        public async Task<List<Cautare>> GetAllCautari(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0)
        {
            var filtru = new CautareFilter() {ToSearch = toSearch, Ids = guids};
            
            return await _repository.GetAllCautari(filtru, pagination, skip);
        }

        public async Task<bool> CreateCautare(Cautare inputCautare)
        {
            _cautareValidator.Validate(inputCautare);
            // var nameAlikeCautari = await _repository.GetAllCautari(
            //     new CautareFilter {ToSearch = inputCautare.IdUtilizator.ToString(),}, MaxPagination);

            var idAlikeCautari = await _repository.GetAllCautari(
                new CautareFilter {Ids = new List<Guid>() {inputCautare.Id}}, MaxPagination);

            if (idAlikeCautari.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Cautare already exists in the repository !",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };

            // if (nameAlikeCautari.Any())
            //     throw new ApiException
            //     {
            //         ExceptionMessage = "Cautare name is not unique !",
            //         Severity = ExceptionSeverity.Error,
            //         Type = ExceptionType.ServiceException
            //     };
            return await _repository.CreateCautare(inputCautare);
        }

        public async Task<bool> DeleteCautare(string toSearch, List<Guid> guids)
        {
            var cautariToDelete = await _repository.GetAllCautari(
                new CautareFilter {ToSearch = toSearch, Ids = guids, PerfectMatch = true}, MaxPagination);

            if (!cautariToDelete.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Cautare is not in the repository.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            var result = true;

            foreach (var cautare in cautariToDelete)
                result = result && await _repository.DeleteCautare(cautare.Id);
            return result;
        }

        public async Task<bool> UpdateCautare(Cautare inputCautare)
        {
            _cautareValidator.Validate(inputCautare);

            var sameIdCautari =
                await _repository.GetAllCautari(new CautareFilter {Ids = new List<Guid> {inputCautare.Id}});

            if (sameIdCautari.Count != 1)
                throw new ApiException
                {
                    ExceptionMessage = $"Cautare with id {inputCautare.Id} to update has not been found.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            // if (inputCautare.IdUtilizator != sameIdCautari.First().IdUtilizator)
            // {
            //     var sameIdUtilizatorCautari = await _repository.GetAllCautari(
            //         new CautareFilter {ToSearch = inputCautare.IdUtilizator.ToString(), PerfectMatch = true});
            //     if (sameIdUtilizatorCautari.Any(s => s.Id != inputCautare.Id))
            //         throw new ApiException
            //         {
            //             ExceptionMessage = $"Cannot update cautare IdUtilizator to one that already exists : {inputCautare.IdUtilizator}.",
            //             Severity = ExceptionSeverity.Error,
            //             Type = ExceptionType.ServiceException
            //         };
            // }

            var cautare = sameIdCautari.First();
            cautare.UpdateByReflection(inputCautare);
            return await _repository.UpdateCautare(cautare);
        }
    }
}