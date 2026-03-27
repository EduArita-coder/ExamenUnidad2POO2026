using ExamenUnidad2.Database;
using ExamenUnidad2.Entities;
using ExamenUnidad2.Dtos.DetallePlanilla;
using Microsoft.EntityFrameworkCore;

namespace ExamenUnidad2.Services
{
    public interface IDetallePlanillaService
    {
        Task<List<DetallePlanillaDto>> GetAll();
        Task<DetallePlanillaDto> GetById(int id);
        Task<List<DetallePlanillaDto>> GetByPlanillaId(int planillaId);
        Task<List<DetallePlanillaDto>> GetByEmpleadoId(int empleadoId);
        Task<DetallePlanillaDto> Create(DetallePlanillaCreateDto dto);
        Task<DetallePlanillaDto> Update(int id, DetallePlanillaUpdateDto dto);
        Task<bool> Delete(int id);
    }

    public class DetallePlanillaService : IDetallePlanillaService
    {
        private readonly PersonDBContext _context;

        public DetallePlanillaService(PersonDBContext context)
        {
            _context = context;
        }

        public async Task<List<DetallePlanillaDto>> GetAll()
        {
            var detalles = await _context.DetallePlanillas.ToListAsync();
            return detalles.Select(d => MapToDto(d)).ToList();
        }

        public async Task<DetallePlanillaDto> GetById(int id)
        {
            var detalle = await _context.DetallePlanillas.FindAsync(id);
            
            if (detalle == null)
                throw new Exception($"Detalle de planilla con ID {id} no encontrado");

            return MapToDto(detalle);
        }

        public async Task<List<DetallePlanillaDto>> GetByPlanillaId(int planillaId)
        {
            var detalles = await _context.DetallePlanillas
                .Where(d => d.PlanillaId == planillaId)
                .ToListAsync();
            return detalles.Select(d => MapToDto(d)).ToList();
        }

        public async Task<List<DetallePlanillaDto>> GetByEmpleadoId(int empleadoId)
        {
            var detalles = await _context.DetallePlanillas
                .Where(d => d.EmpleadoId == empleadoId)
                .ToListAsync();
            return detalles.Select(d => MapToDto(d)).ToList();
        }

        public async Task<DetallePlanillaDto> Create(DetallePlanillaCreateDto dto)
        {
            // Validar que la planilla existe
            var planilla = await _context.Planillas.FindAsync(dto.PlanillaId);
            if (planilla == null)
                throw new Exception($"Planilla con ID {dto.PlanillaId} no encontrada");

            // Validar que el empleado existe
            var empleado = await _context.Empleados.FindAsync(dto.EmpleadoId);
            if (empleado == null)
                throw new Exception($"Empleado con ID {dto.EmpleadoId} no encontrado");

            // Validar que el empleado esté activo
            if (!empleado.Activo)
                throw new Exception($"No se puede crear detalle planilla con un empleado inactivo");

            // Usar el SalarioBase del DTO si viene, sino heredar del Empleado
            decimal salarioBase = dto.SalarioBase ?? empleado.SalarioBase;

            // Calcular salario neto
            decimal salarioNeto = salarioBase + dto.MontoHorasExtra + dto.Bonificaciones - dto.Deducciones;

            var detalle = new DetallePlanilla
            {
                PlanillaId = dto.PlanillaId,
                EmpleadoId = dto.EmpleadoId,
                SalarioBase = salarioBase,
                HorasExtra = dto.HorasExtra,
                MontoHorasExtra = dto.MontoHorasExtra,
                Bonificaciones = dto.Bonificaciones,
                Deducciones = dto.Deducciones,
                SalarioNeto = salarioNeto,
                Comentarios = dto.Comentarios
            };

            _context.DetallePlanillas.Add(detalle);
            await _context.SaveChangesAsync();

            return MapToDto(detalle);
        }

        public async Task<DetallePlanillaDto> Update(int id, DetallePlanillaUpdateDto dto)
        {
            var detalle = await _context.DetallePlanillas.FindAsync(id);
            
            if (detalle == null)
                throw new Exception($"Detalle de planilla con ID {id} no encontrado");

            // Validar que el empleado asociado siga estando activo
            var empleado = await _context.Empleados.FindAsync(detalle.EmpleadoId);
            if (empleado == null || !empleado.Activo)
                throw new Exception($"No se puede actualizar detalle planilla con un empleado inactivo");

            // Usar el SalarioBase del DTO si viene, sino mantener el actual
            decimal salarioBase = dto.SalarioBase ?? detalle.SalarioBase;

            // Calcular salario neto
            decimal salarioNeto = salarioBase + dto.MontoHorasExtra + dto.Bonificaciones - dto.Deducciones;

            detalle.SalarioBase = salarioBase;
            detalle.HorasExtra = dto.HorasExtra;
            detalle.MontoHorasExtra = dto.MontoHorasExtra;
            detalle.Bonificaciones = dto.Bonificaciones;
            detalle.Deducciones = dto.Deducciones;
            detalle.SalarioNeto = salarioNeto;
            detalle.Comentarios = dto.Comentarios;

            _context.DetallePlanillas.Update(detalle);
            await _context.SaveChangesAsync();

            return MapToDto(detalle);
        }

        public async Task<bool> Delete(int id)
        {
            var detalle = await _context.DetallePlanillas.FindAsync(id);
            
            if (detalle == null)
                throw new Exception($"Detalle de planilla con ID {id} no encontrado");

            _context.DetallePlanillas.Remove(detalle);
            await _context.SaveChangesAsync();

            return true;
        }

        private DetallePlanillaDto MapToDto(DetallePlanilla detalle)
        {
            return new DetallePlanillaDto
            {
                Id = detalle.Id,
                PlanillaId = detalle.PlanillaId,
                EmpleadoId = detalle.EmpleadoId,
                SalarioBase = detalle.SalarioBase,
                HorasExtra = detalle.HorasExtra,
                MontoHorasExtra = detalle.MontoHorasExtra,
                Bonificaciones = detalle.Bonificaciones,
                Deducciones = detalle.Deducciones,
                SalarioNeto = detalle.SalarioNeto,
                Comentarios = detalle.Comentarios
            };
        }
    }
}
