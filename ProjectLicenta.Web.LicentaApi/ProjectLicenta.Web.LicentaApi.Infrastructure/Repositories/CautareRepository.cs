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
    public class CautareRepository : ICautareRepository
    {
        private readonly DataContext _dataContext;

        public CautareRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Cautare>> GetAllCautari(CautareFilter filter, int pagination = 50, int skip = 0)
        {
            return await filter.Filter(_dataContext.Cautari.AsQueryable())
                .Skip(skip).Take(pagination).ToListAsync();
        }

        public async Task<bool> CreateCautare(Cautare inputCautare)
        {
            await _dataContext.Cautari.AddAsync(inputCautare);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCautare(Guid id)
        {
            _dataContext.Cautari.Remove(await _dataContext.Cautari.FirstOrDefaultAsync(Cautare => Cautare.Id.Equals(id)));
            
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCautare(Cautare inputCautare)
        {
            _dataContext.Cautari.Update(inputCautare);

            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}