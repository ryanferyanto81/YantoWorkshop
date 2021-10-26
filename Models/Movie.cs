using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string NamaProduk { get; set; }

        [Display(Name = "TanggalOrder")]
        [DataType(DataType.Date)]
        public DateTime TanggalOrder { get; set;}
        public string JumlahBarang { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Harga { get; set; }
    }
}