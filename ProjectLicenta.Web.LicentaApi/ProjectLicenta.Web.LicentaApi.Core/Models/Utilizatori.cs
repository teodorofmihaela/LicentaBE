using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectLicenta.Web.LicentaApi.Core.Models
{
    public class Utilizatori : IEntity
    {
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(256)")]public string Nume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Status { get; set; }
        public string Localitate { get; set; }
        public int Telefon { get; set; }
       }
}