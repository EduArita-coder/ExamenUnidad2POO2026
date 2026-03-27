using System.ComponentModel.DataAnnotations;

namespace ExamenUnidad2.Dtos.Empleados
{
    public class EmpleadoCreateDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El documento es requerido")]
        [StringLength(50)]
        public string Documento { get; set; }

        public DateTime FechaContratacion { get; set; }

        [StringLength(100)]
        public string Departamento { get; set; }

        [StringLength(100)]
        public string PuestoTrabajo { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El salario base debe ser un número positivo")]
        public decimal SalarioBase { get; set; }

        public bool Activo { get; set; } = true;
    }
}
