using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IUtilizatorFavoritService
    {
        public Task<List<UtilizatorFavorit>> GetAllUtilizatoriFavoriti(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0);

        public Task<bool> CreateUtilizatorFavorit(UtilizatorFavorit inputUtilizatorFavorit);

        public Task<bool> DeleteUtilizatorFavorit(string toSearch, List<Guid> guids);

        public Task<bool> UpdateUtilizatorFavorit(UtilizatorFavorit inputUtilizatorFavorit);
    }
}