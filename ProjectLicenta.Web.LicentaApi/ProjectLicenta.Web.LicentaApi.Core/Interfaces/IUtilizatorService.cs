using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IUtilizatorService
    {
        public Task<List<Utilizator>> GetAllUtilizatori(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0);

        public Task<bool> CreateUtilizator(Utilizator inputUtilizator);

        public Task<bool> DeleteUtilizator(string toSearch, List<Guid> guids);

        public Task<bool> UpdateUtilizator(Utilizator inputUtilizator);
    }
}