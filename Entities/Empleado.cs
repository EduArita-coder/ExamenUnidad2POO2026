using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenUnidad2.Entities
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Nombre")]
        public string Nombre {get; set;}

        [Required]
        [Column("Apellido")]
        public string Apellido {get; set;}
        [Required]
        [Column("Documento")]
        public string Documento {get; set;}
        [Column("FechaContratacion")]

        public DateTime FechaContratacion {get; set;}
        [Column("Departamento")]
        public string Departamento {get;set;}

        [Column("PuestoTrabajo")]
        public string PuestoTrabajo {get;set;}

        [Column("SalarioBase")]
        public decimal SalarioBase {get;set;}

        [Column("Activo")]
        public bool Activo {get;set;}
    }
}