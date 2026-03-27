using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenUnidad2.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenUnidad2.Database
{
    public class PersonDBContext : DbContext
    {
        public PersonDBContext(DbContextOptions<PersonDBContext> options) : base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Planilla> Planillas { get; set; }
        public DbSet<DetallePlanilla> DetallePlanillas { get; set; }


    }
}