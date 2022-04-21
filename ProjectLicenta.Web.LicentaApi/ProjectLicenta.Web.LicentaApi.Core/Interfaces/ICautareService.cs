using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface ICautareService
    {
        public Task<List<Cautare>> GetAllCautari(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0);

        public Task<bool> CreateCautare(Cautare inputCautare);

        public Task<bool> DeleteCautare(string toSearch, List<Guid> guids);

        public Task<bool> UpdateCautare(Cautare inputCautare);
       
    }
}