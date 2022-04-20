using System;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class AnuntPrestat:IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUtilizator{ get; set; }
        public Guid IdAnunt{ get; set; }
        public DateTime Data{ get; set; }
        /*public Utilizator Utilizator { get; set; }*/

    }
}