using System.ComponentModel.DataAnnotations;

namespace JCExamenP1.Models
{
    public class JCordero
    {
        
        [Key]
        public int JCId { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string? JCModelo { get; set; }

        [Range(0.01, 9999.99)]
        public decimal JCPrecio { get; set; }

        [Range(typeof(bool), "false", "false")]
        public bool JCRemanofacturado { get; set; }

        [Required]
        public DateTime FechaFabriacion { get; set; }


       

    }
}
