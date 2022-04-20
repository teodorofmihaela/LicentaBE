using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class Feedback:IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUtilizatorDat { get; set; }
        public Guid IdUtilizatorPrimit { get; set; }
        public string Titlu { get; set; }
        public string Text { get; set; }
        public Guid IdServiciu { get; set; }
        public int NrStele { get; set; }
        public DateTime Data { get; set; }
        
        public Utilizator Utilizator { get; set; }

    }
}