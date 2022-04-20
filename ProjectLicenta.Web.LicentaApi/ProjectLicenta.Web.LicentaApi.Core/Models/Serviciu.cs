using System;
using System.Collections.Generic;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class Serviciu:IEntity
    {
        public Guid Id { get; set; }
        public string NumeServiciu { get; set; }
        
        // public List<Anunturi>? AnunturiList { get; set; }

    }
}