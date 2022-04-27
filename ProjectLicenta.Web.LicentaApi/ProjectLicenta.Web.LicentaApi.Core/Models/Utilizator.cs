using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class Utilizator : IEntity
    {
        public Guid Id { get; set; }
        
        [Column(TypeName = "varchar(256)")] public string Nume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Status { get; set; }
        public string Localitate { get; set; }
        public int Telefon { get; set; }

        public List<Feedback> FeedbacksDateList { get; set; }
        
        public List<Anunt>? AnunturiList { get; set; }
        
        public List<AnuntPrestat> AnunturiPrestateList { get; set; }
        
        public List<AnuntFavorit> AnunturiFavoriteList { get; set; }
    }
}