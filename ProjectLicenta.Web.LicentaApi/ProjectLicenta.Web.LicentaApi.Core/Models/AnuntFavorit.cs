using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class AnuntFavorit : IEntity
    {
        public Guid Id { get; set; }

        public Guid UtilizatorId { get; set; }
        public Utilizator Utilizator { get; set; }
        
        public Guid AnuntId { get; set; }
        public Anunt Anunt { get; set; }
    }
}