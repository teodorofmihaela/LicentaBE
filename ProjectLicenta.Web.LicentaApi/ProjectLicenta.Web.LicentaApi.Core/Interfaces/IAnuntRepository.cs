using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IAnuntRepository
    {
        public Task<List<Anunt>> GetAllAnunturi(AnuntFilter filter, int pagination = 50, int skip = 0);

        public Task<bool> CreateAnunt(Anunt inputUtilizator);

        public Task<bool> DeleteAnunt(Guid id);

        public Task<bool> UpdateAnunt(Anunt inputAnunt);
    }
}