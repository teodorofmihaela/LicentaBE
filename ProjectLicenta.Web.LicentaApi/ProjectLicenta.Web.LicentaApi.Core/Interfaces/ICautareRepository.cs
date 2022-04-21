using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface ICautareRepository
    {
        public Task<List<Cautare>> GetAllCautari(CautareFilter filter, int pagination = 50, int skip = 0);

        public Task<bool> CreateCautare(Cautare inputCautare);

        public Task<bool> DeleteCautare(Guid id);

        public Task<bool> UpdateCautare(Cautare inputCautare);
    }
}