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
    public class AnuntRepository:IAnuntRepository
    {
        private readonly DataContext _dataContext;

        public AnuntRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<List<Anunt>> GetAllAnunturi(AnuntFilter filter, int pagination = 50, int skip = 0)
        {
            return await filter.Filter(_dataContext.Anunturi.AsQueryable())
                .Skip(skip)
                .Take(pagination)
                .Include(a => a.Utilizator)
                //TODO-> INCLUDERE UN ALT OBIECT PT GET
                .ToListAsync();
        }
        
        public async Task<bool> CreateAnunt(Anunt inputAnunt)
        {
            await _dataContext.Anunturi.AddAsync(inputAnunt);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAnunt(Guid id)
        {
            _dataContext.Anunturi.Remove(await _dataContext.Anunturi.FirstOrDefaultAsync(Anunt => Anunt.Id.Equals(id)));
            
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAnunt(Anunt inputAnunt)
        {
            _dataContext.Anunturi.Update(inputAnunt);

            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}