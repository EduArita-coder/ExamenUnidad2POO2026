using System.ComponentModel.DataAnnotations;

namespace ExamenUnidad2.Dtos.DetallePlanilla
{
    public class DetallePlanillaCreateDto
    {
        [Required(ErrorMessage = "El ID de la planilla es requerido")]
        public int PlanillaId { get; set; }

        [Required(ErrorMessage = "El ID del empleado es requerido")]
        public int EmpleadoId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El salario base debe ser un número positivo")]
        public decimal? SalarioBase { get; set; } // Opcional - se hereda del empleado si viene null

        [Range(0, double.MaxValue, ErrorMessage = "Las horas extra deben ser un número positivo")]
        public decimal HorasExtra { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El monto de horas extra debe ser un número positivo")]
        public decimal MontoHorasExtra { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Las bonificaciones deben ser un número positivo")]
        public decimal Bonificaciones { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Las deducciones deben ser un número positivo")]
        public decimal Deducciones { get; set; }

        public string Comentarios { get; set; }
    }
}
