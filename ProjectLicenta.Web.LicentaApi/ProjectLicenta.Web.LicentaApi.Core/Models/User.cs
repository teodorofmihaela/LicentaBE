using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}