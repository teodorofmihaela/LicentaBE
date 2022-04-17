using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class UtilizatoriFavoriti:IEntity
    {
        public Guid Id { get; set; }//id utilizator principal
        public int IdUtilizatorFavorit{ get; set; }

    }
}