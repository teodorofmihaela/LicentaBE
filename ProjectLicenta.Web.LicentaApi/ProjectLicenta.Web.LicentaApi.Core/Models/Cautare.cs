using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class Cautare:IEntity
    {
        public Guid Id { get; set; }
        public DateTime DataCautare { get; set; }
        public bool ProfilAccesat { get; set; }
        public float TimpPeProfil { get; set; }
        public Guid AnuntId { get; set; }
        
        public Guid UtilizatorId { get; set; }
        public Utilizator Utilizator { get; set; }
    }
}