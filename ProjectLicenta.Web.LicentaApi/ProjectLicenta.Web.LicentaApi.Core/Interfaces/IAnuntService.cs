using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IAnuntService
    {
        public Task<List<Anunt>> GetAllAnunturi(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0);

        public Task<bool> CreateAnunt(Anunt inputAnunt);

        public Task<bool> DeleteAnunt(string toSearch, List<Guid> guids);

        public Task<bool> UpdateAnunt(Anunt inputAnunt);
    }
}