using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Presto.Models
{
    public class Simulacion
    {
        [Key]
        public int ID { set; get; }

        [Display(Name = "Nombre Simulacion")]
        public string Nombre { set; get; } 

        [Display(Name = "Prestamo")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Required]
        public long? Prestamo { set; get; }

        [Display(Name = "Porcentaje Anual")]
        [Required]
        [Range(0, 100, ErrorMessage = "Rango entre 0% a 100%")]
        public double? Interes { set; get; }

        [Display(Name = "Meses")]
        [Required]
        public int? Meses { set; get; }

        //[Display(Name = "Salario")]
        //[DataType(DataType.Currency)]
        //[Column(TypeName = "money")]
        //public long? Salarios { set; get; }

        public DateTime FechaModificacion { set; get; } = DateTime.Now;

        public bool Baja { set; get; } = false;
    }
}