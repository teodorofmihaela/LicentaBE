using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class AnunturiPrestate:IEntity
    {
        public Guid Id { get; set; }
        public int IdUtilizator{ get; set; }
        public int IdAnunt{ get; set; }
        public DateTime Data{ get; set; }
    }
}