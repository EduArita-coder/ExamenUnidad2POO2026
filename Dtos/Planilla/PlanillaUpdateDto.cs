using System.ComponentModel.DataAnnotations;

namespace ExamenUnidad2.Dtos.Planilla
{
    public class PlanillaUpdateDto
    {
        [Required(ErrorMessage = "El periodo es requerido")]
        [StringLength(50)]
        public string Periodo { get; set; }

        public DateTime FechaPago { get; set; }

        [RegularExpression("^(Pendiente|Pagada|Anulada)$", ErrorMessage = "El estado debe ser 'Pendiente', 'Pagada' o 'Anulada'")]
        public string Estado { get; set; }
    }
}
