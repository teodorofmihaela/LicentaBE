using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class Servicii:IEntity
    {
        public Guid Id { get; set; }
        public string NumeServiciu { get; set; }
    }
}