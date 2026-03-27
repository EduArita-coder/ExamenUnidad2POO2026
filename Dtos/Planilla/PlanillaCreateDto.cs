
using System.ComponentModel.DataAnnotations;

namespace ExamenUnidad2.Dtos.Planilla
{
    public class PlanillaCreateDto
    {
        [Required(ErrorMessage = "El período es requerido")]
        [StringLength(50)]
        public string Periodo { get; set; }

        public DateTime FechaPago { get; set; }
    }
}