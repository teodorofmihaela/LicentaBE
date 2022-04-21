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
    public class ServiciuRepository : IServiciuRepository
    {
        private readonly DataContext _dataContext;

        public ServiciuRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Serviciu>> GetAllServicii(ServiciuFilter filter, int pagination = 50, int skip = 0)
        {
            return await filter.Filter(_dataContext.Servicii.AsQueryable()).Skip(skip).Take(pagination).ToListAsync();
        }

        public async Task<bool> CreateServiciu(Serviciu inputServiciu)
        {
            await _dataContext.Servicii.AddAsync(inputServiciu);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteServiciu(Guid id)
        {
            _dataContext.Servicii.Remove(await _dataContext.Servicii.FirstOrDefaultAsync(Serviciu => Serviciu.Id.Equals(id)));
            
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateServiciu(Serviciu inputServiciu)
        {
            _dataContext.Servicii.Update(inputServiciu);

            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}