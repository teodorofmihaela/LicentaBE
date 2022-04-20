using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class UtilizatorFavorit:IEntity
    {
        public Guid Id { get; set; }//id utilizator principal
        public Guid IdUtilizatorFavorit{ get; set; }
        //public Utilizator Utilizator { get; set; }

    }
}