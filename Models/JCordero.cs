using System.ComponentModel.DataAnnotations;

namespace JCExamenP1.Models
{
    public class JCordero
    {
        [Required]
        [Key]
        public int JCId { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string? JCModelo { get; set; }

        [Range(0.01, 9999.99)]
        public decimal JCPrecio { get; set; }

        [Range(typeof(bool), "false", "false", ErrorMessage = "No aceptamos equipos remanofacturados")]
        public bool JCRemanofacturado { get; set; }

        [RegularExpression("[1-9]{2}/[0-9]{2}/[0-9]{4}")]//Expresión regular para valiar fecha
        public DateTime FechaFabriacion { get; set; }


       

    }
}
