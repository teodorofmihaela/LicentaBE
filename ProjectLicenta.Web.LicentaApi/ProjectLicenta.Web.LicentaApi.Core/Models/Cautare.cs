using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class Cautare:IEntity
    {
        public Guid Id { get; set; }
        public DateTime DataCautare { get; set; }
        public Guid IdUtilizator { get; set; }
        public Guid IdAnunt { get; set; }
        public bool ProfilAccesat { get; set; }
        public float TimpPeProfil { get; set; }
        // public Utilizator Utilizator { get; set; }
        // public Anunturi Anunturi { get; set; }

    }
}