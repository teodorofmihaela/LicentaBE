using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IUtilizatorRepository
    {
        public Task<List<Utilizator>> GetAllUtilizatori(UtilizatorFilter filter, int pagination = 50, int skip = 0);

        public Task<bool> CreateUtilizator(Utilizator inputUtilizator);

        public Task<bool> DeleteUtilizator(Guid id);

        public Task<bool> UpdateUtilizator(Utilizator inputUtilizator);
    }
}