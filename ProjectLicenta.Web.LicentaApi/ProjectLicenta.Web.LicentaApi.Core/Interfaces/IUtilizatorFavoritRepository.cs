using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IUtilizatorFavoritRepository
    {
        public Task<List<AnuntFavorit>> GetAllUtilizatoriFavoriti(UtilizatorFavoritFilter filter, int pagination = 50, int skip = 0);

        public Task<bool> CreateUtilizatorFavorit(AnuntFavorit inputAnuntFavorit);

        public Task<bool> DeleteUtilizatorFavorit(Guid id);

        public Task<bool> UpdateUtilizatorFavorit(AnuntFavorit inputAnuntFavorit);
    }
}