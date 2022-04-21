using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IServiciuRepository
    {
        public Task<List<Serviciu>> GetAllServicii(ServiciuFilter filter, int pagination = 50, int skip = 0);

        public Task<bool> CreateServiciu(Serviciu inputServiciu);

        public Task<bool> DeleteServiciu(Guid id);

        public Task<bool> UpdateServiciu(Serviciu inputServiciu);
    }
}