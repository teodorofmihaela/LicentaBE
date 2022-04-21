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
    public class AnuntPrestatRepository : IAnuntPrestatRepository
    {
        private readonly DataContext _dataContext;

        public AnuntPrestatRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<AnuntPrestat>> GetAllAnunturiPrestate(AnuntPrestatFilter filter, int pagination = 50, int skip = 0)
        {
            return await filter.Filter(_dataContext.AnunturiPrestate.AsQueryable()).Skip(skip).Take(pagination).ToListAsync();
        }

        public async Task<bool> CreateAnuntPrestat(AnuntPrestat inputAnuntPrestat)
        {
            await _dataContext.AnunturiPrestate.AddAsync(inputAnuntPrestat);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAnuntPrestat(Guid id)
        {
            _dataContext.AnunturiPrestate.Remove(await _dataContext.AnunturiPrestate.FirstOrDefaultAsync(AnuntPrestat => AnuntPrestat.Id.Equals(id)));
            
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAnuntPrestat(AnuntPrestat inputAnuntPrestat)
        {
            _dataContext.AnunturiPrestate.Update(inputAnuntPrestat);

            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}