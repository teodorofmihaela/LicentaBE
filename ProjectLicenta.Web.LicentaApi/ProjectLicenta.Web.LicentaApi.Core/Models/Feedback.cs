using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class Feedback:IEntity
    {
        public Guid Id { get; set; }
        public string Titlu { get; set; }
        public string Text { get; set; }
        public int NrStele { get; set; }
        public DateTime Data { get; set; }
        
        public Guid ServiciuId { get; set; }
        public Serviciu Serviciu { get; set; }
        
        public Guid UtilizatorId { get; set; }
        public Utilizator Utilizator { get; set; }
        
        public Guid AnuntId { get; set; }
        public Anunt Anunt { get; set; }
    }
}