using ExamenUnidad2.Database;
using ExamenUnidad2.Entities;
using ExamenUnidad2.Dtos.Empleados;
using ExamenUnidad2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ExamenUnidad2.Services
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDto>> GetAllEmpleados();
        Task<List<EmpleadoDto>> GetEmpleadosActivos();
        Task<EmpleadoDto> GetEmpleadoById(int id);
        Task<EmpleadoDto> CreateEmpleado(EmpleadoCreateDto dto);
        Task<EmpleadoDto> UpdateEmpleado(int id, EmpleadoUpdateDto dto);
        Task<bool> DeleteEmpleado(int id);
    }

    public class EmpleadoService : IEmpleadoService
    {
        private readonly PersonDBContext _context;

        public EmpleadoService(PersonDBContext context)
        {
            _context = context;
        }

        public async Task<List<EmpleadoDto>> GetAllEmpleados()
        {
            return await _context.Empleados
                .Select(e => new EmpleadoDto
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    Documento = e.Documento,
                    FechaContratacion = e.FechaContratacion,
                    Departamento = e.Departamento,
                    PuestoTrabajo = e.PuestoTrabajo,
                    SalarioBase = e.SalarioBase,
                    Activo = e.Activo
                })
                .ToListAsync();
        }

        public async Task<List<EmpleadoDto>> GetEmpleadosActivos()
        {
            return await _context.Empleados
                .Where(e => e.Activo)
                .Select(e => new EmpleadoDto
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    Documento = e.Documento,
                    FechaContratacion = e.FechaContratacion,
                    Departamento = e.Departamento,
                    PuestoTrabajo = e.PuestoTrabajo,
                    SalarioBase = e.SalarioBase,
                    Activo = e.Activo
                })
                .ToListAsync();
        }

        public async Task<EmpleadoDto> GetEmpleadoById(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            
            if (empleado == null)
                throw new NotFoundException($"Empleado con ID {id} no encontrado");

            return new EmpleadoDto
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Documento = empleado.Documento,
                FechaContratacion = empleado.FechaContratacion,
                Departamento = empleado.Departamento,
                PuestoTrabajo = empleado.PuestoTrabajo,
                SalarioBase = empleado.SalarioBase,
                Activo = empleado.Activo
            };
        }

        public async Task<EmpleadoDto> CreateEmpleado(EmpleadoCreateDto dto)
        {
            // Validar documento único
            var existingEmpleado = await _context.Empleados
                .FirstOrDefaultAsync(e => e.Documento == dto.Documento);
            
            if (existingEmpleado != null)
                throw new ValidationException($"Ya existe un empleado con el documento {dto.Documento}");

            var empleado = new Empleado
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Documento = dto.Documento,
                FechaContratacion = dto.FechaContratacion,
                Departamento = dto.Departamento,
                PuestoTrabajo = dto.PuestoTrabajo,
                SalarioBase = dto.SalarioBase,
                Activo = dto.Activo
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return new EmpleadoDto
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Documento = empleado.Documento,
                FechaContratacion = empleado.FechaContratacion,
                Departamento = empleado.Departamento,
                PuestoTrabajo = empleado.PuestoTrabajo,
                SalarioBase = empleado.SalarioBase,
                Activo = empleado.Activo
            };
        }

        public async Task<EmpleadoDto> UpdateEmpleado(int id, EmpleadoUpdateDto dto)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            
            if (empleado == null)
                throw new NotFoundException($"Empleado con ID {id} no encontrado");

            empleado.Nombre = dto.Nombre;
            empleado.Apellido = dto.Apellido;
            empleado.Departamento = dto.Departamento;
            empleado.PuestoTrabajo = dto.PuestoTrabajo;
            empleado.SalarioBase = dto.SalarioBase;
            empleado.Activo = dto.Activo;

            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();

            return new EmpleadoDto
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Documento = empleado.Documento,
                FechaContratacion = empleado.FechaContratacion,
                Departamento = empleado.Departamento,
                PuestoTrabajo = empleado.PuestoTrabajo,
                SalarioBase = empleado.SalarioBase,
                Activo = empleado.Activo
            };
        }

        public async Task<bool> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            
            if (empleado == null)
                throw new Exception($"Empleado con ID {id} no encontrado");

            // Baja lógica: cambiar Activo a false
            empleado.Activo = false;
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
