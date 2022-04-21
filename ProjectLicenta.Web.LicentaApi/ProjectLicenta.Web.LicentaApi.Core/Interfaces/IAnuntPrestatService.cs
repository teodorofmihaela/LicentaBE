using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IAnuntPrestatService
    {
        public Task<List<AnuntPrestat>> GetAllAnunturiPrestate(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0);

        public Task<bool> CreateAnuntPrestat(AnuntPrestat inputAnuntPrestat);

        public Task<bool> DeleteAnuntPrestat(string toSearch, List<Guid> guids);

        public Task<bool> UpdateAnuntPrestat(AnuntPrestat inputAnuntPrestat);
    }
}