using System.ComponentModel.DataAnnotations;

namespace ExamenUnidad2.Dtos.Planilla
{
    public class GenerarPlanillaDto
    {
        [Required(ErrorMessage = "El periodo es requerido")]
        public string Periodo { get; set; }
    }
}
