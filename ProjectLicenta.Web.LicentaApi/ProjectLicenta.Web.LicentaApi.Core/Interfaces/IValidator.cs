using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IValidator
    {
        public bool Validate(IEntity entity);
    }
}