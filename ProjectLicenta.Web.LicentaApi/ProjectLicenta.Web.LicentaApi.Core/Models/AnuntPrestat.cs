using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class AnuntPrestat:IEntity
    {
        public Guid Id { get; set; }
        public DateTime Data{ get; set; }
        
        public Guid AnuntId { get; set; }
        public Anunt Anunt { get; set; }
        
        public Guid UtilizatorId { get; set; }
        public Utilizator Utilizator { get; set; }

    }
}