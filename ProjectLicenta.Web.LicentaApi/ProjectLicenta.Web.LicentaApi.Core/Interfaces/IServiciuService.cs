using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IServiciuService
    {
        public Task<List<Serviciu>> GetAllServicii(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0);

        public Task<bool> CreateServiciu(Serviciu inputServiciu);

        public Task<bool> DeleteServiciu(string toSearch, List<Guid> guids);

        public Task<bool> UpdateServiciu(Serviciu inputServiciu);
    }
}