using System;
using System.ComponentModel.DataAnnotations;

namespace NaveDaCrociera.DB.Entities
{
    public class Spettacoli
    {
        //[Key]
        public string Id { get; set; }
        public string NomeEvento { get; set; }
        public string Locale { get; set; }
        public string Posti { get; set; }
        public string Annullato { get; set; }

    }
}
