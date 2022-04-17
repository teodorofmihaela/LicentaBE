using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class Cautari:IEntity
    {
        public Guid Id { get; set; }
        public DateTime DataCautare { get; set; }
        public int IdUtilizator { get; set; }
        public int IdAnunt { get; set; }
        public bool ProfilAccesat { get; set; }
        public float TimpPeProfil { get; set; }
    }
}