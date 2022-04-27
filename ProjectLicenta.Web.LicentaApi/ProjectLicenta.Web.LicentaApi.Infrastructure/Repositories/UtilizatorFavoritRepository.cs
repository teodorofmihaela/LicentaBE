using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;
using ProjectLicenta.Web.LicentaApi.Infrastructure.Data;

namespace ProjectLicenta.Web.LicentaApi.Infrastructure.Repositories
{
    public class UtilizatorFavoritRepository : IUtilizatorFavoritRepository
    {
        private readonly DataContext _dataContext;

        public UtilizatorFavoritRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<AnuntFavorit>> GetAllUtilizatoriFavoriti(UtilizatorFavoritFilter filter, int pagination = 50, int skip = 0)
        {
            return await filter.Filter(_dataContext.UtilizatoriFavoriti.AsQueryable()).Skip(skip).Take(pagination).ToListAsync();
        }

        public async Task<bool> CreateUtilizatorFavorit(AnuntFavorit inputAnuntFavorit)
        {
            await _dataContext.UtilizatoriFavoriti.AddAsync(inputAnuntFavorit);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUtilizatorFavorit(Guid id)
        {
            _dataContext.UtilizatoriFavoriti.Remove(await _dataContext.UtilizatoriFavoriti.FirstOrDefaultAsync(UtilizatorFavorit => UtilizatorFavorit.Id.Equals(id)));
            
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUtilizatorFavorit(AnuntFavorit inputAnuntFavorit)
        {
            _dataContext.UtilizatoriFavoriti.Update(inputAnuntFavorit);

            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}