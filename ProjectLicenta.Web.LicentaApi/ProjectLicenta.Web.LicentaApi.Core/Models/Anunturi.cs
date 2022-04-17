using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class Anunturi:IEntity
    {
        public Guid Id { get; set; }
        [Required]
        public int IdServiciu { get; set; } 
        [Required]
        [Column(TypeName = "varchar(256)")]public string Titlu { get; set; }
        public string Text { get; set; }
        public DateTime DataPostare { get; set; }
        public int IdUtilizator{ get; set; }
        public bool Arhivat { get; set; }
        public int Pret{ get; set; }
        public bool Negociabil{ get; set; }
        public bool Prestator{ get; set; }
    }
}