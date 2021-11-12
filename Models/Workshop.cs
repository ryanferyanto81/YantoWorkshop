using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YantoWorkshop.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string NamaProduk { get; set; }

        public string JumlahBarang { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Harga { get; set; }
    }
}