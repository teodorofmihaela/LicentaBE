using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class FeedBacks:IEntity
    {
        public Guid Id { get; set; }
        public int IdUtilizatorDat { get; set; }
        public int IdUtilizatorPrimit { get; set; }
        public string Titlu { get; set; }
        public string Text { get; set; }
        public int IdServiciu { get; set; }
        public int NrStele { get; set; }
        public DateTime Data { get; set; }
    }
}