using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IAnuntPrestatRepository
    {
        public Task<List<AnuntPrestat>> GetAllAnunturiPrestate(AnuntPrestatFilter filter, int pagination = 50, int skip = 0);

        public Task<bool> CreateAnuntPrestat(AnuntPrestat inputAnuntPrestat);

        public Task<bool> DeleteAnuntPrestat(Guid id);

        public Task<bool> UpdateAnuntPrestat(AnuntPrestat inputAnuntPrestat);
    }
}