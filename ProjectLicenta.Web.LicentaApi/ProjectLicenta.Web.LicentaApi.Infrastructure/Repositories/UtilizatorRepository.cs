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
    public class UtilizatorRepository : IUtilizatorRepository
    {
        private readonly DataContext _dataContext;

        public UtilizatorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Utilizator>> GetAllUtilizatori(UtilizatorFilter filter, int pagination = 50, int skip = 0)
        {
            return await filter.Filter(_dataContext.Utilizatori.AsQueryable()).Skip(skip).Take(pagination).ToListAsync();
        }

        public async Task<bool> CreateUtilizator(Utilizator inputUtilizator)
        {
            await _dataContext.Utilizatori.AddAsync(inputUtilizator);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUtilizator(Guid id)
        {
            _dataContext.Utilizatori.Remove(await _dataContext.Utilizatori.FirstOrDefaultAsync(Utilizator => Utilizator.Id.Equals(id)));
            
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUtilizator(Utilizator inputUtilizator)
        {
            _dataContext.Utilizatori.Update(inputUtilizator);

            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}