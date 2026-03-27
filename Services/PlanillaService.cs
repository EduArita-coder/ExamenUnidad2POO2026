using ExamenUnidad2.Database;
using ExamenUnidad2.Entities;
using ExamenUnidad2.Dtos.Planilla;
using Microsoft.EntityFrameworkCore;

namespace ExamenUnidad2.Services
{
    public interface IPlanillaService
    {
        Task<List<PlanillaDto>> GetAllPlanillas();
        Task<PlanillaDto> GetPlanillaById(int id);
        Task<List<PlanillaDto>> GetPlanillasByPeriodo(string periodo);
        Task<PlanillaDto> CreatePlanilla(PlanillaCreateDto dto);
        Task<PlanillaDto> UpdatePlanilla(int id, PlanillaUpdateDto dto);
        Task<PlanillaDto> UpdateEstado(int id, string estado);
        Task<bool> DeletePlanilla(int id);
        Task<PlanillaDto> GenerarPlanilla(string periodo);
    }

    public class PlanillaService : IPlanillaService
    {
        private readonly PersonDBContext _context;

        public PlanillaService(PersonDBContext context)
        {
            _context = context;
        }

        public async Task<List<PlanillaDto>> GetAllPlanillas()
        {
            return await _context.Planillas
                .Select(p => new PlanillaDto
                {
                    Id = p.Id,
                    Periodo = p.Periodo,
                    FechaCreacion = p.FechaCreacion,
                    FechaPago = p.FechaPago,
                    Estado = p.Estado
                })
                .ToListAsync();
        }

        public async Task<PlanillaDto> GetPlanillaById(int id)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            
            if (planilla == null)
                throw new Exception($"Planilla con ID {id} no encontrada");

            return new PlanillaDto
            {
                Id = planilla.Id,
                Periodo = planilla.Periodo,
                FechaCreacion = planilla.FechaCreacion,
                FechaPago = planilla.FechaPago,
                Estado = planilla.Estado
            };
        }

        public async Task<List<PlanillaDto>> GetPlanillasByPeriodo(string periodo)
        {
            return await _context.Planillas
                .Where(p => p.Periodo == periodo)
                .Select(p => new PlanillaDto
                {
                    Id = p.Id,
                    Periodo = p.Periodo,
                    FechaCreacion = p.FechaCreacion,
                    FechaPago = p.FechaPago,
                    Estado = p.Estado
                })
                .ToListAsync();
        }

        public async Task<PlanillaDto> CreatePlanilla(PlanillaCreateDto dto)
        {
            // Validar que no exista dos planillas para el mismo periodo
            var existingPlanilla = await _context.Planillas
                .FirstOrDefaultAsync(p => p.Periodo == dto.Periodo);
            
            if (existingPlanilla != null)
                throw new Exception($"Ya existe una planilla para el periodo {dto.Periodo}");

            var planilla = new Planilla
            {
                Periodo = dto.Periodo,
                FechaCreacion = DateTime.Now,
                FechaPago = dto.FechaPago,
                Estado = "Pendiente"
            };

            _context.Planillas.Add(planilla);
            await _context.SaveChangesAsync();

            return new PlanillaDto
            {
                Id = planilla.Id,
                Periodo = planilla.Periodo,
                FechaCreacion = planilla.FechaCreacion,
                FechaPago = planilla.FechaPago,
                Estado = planilla.Estado
            };
        }

        public async Task<PlanillaDto> UpdatePlanilla(int id, PlanillaUpdateDto dto)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            
            if (planilla == null)
                throw new Exception($"Planilla con ID {id} no encontrada");

            // Validar que no exista otra planilla para el mismo periodo (si cambió)
            if (planilla.Periodo != dto.Periodo)
            {
                var existingPlanilla = await _context.Planillas
                    .FirstOrDefaultAsync(p => p.Periodo == dto.Periodo && p.Id != id);
                
                if (existingPlanilla != null)
                    throw new Exception($"Ya existe una planilla para el periodo {dto.Periodo}");
            }

            planilla.Periodo = dto.Periodo;
            planilla.FechaPago = dto.FechaPago;
            planilla.Estado = dto.Estado;

            _context.Planillas.Update(planilla);
            await _context.SaveChangesAsync();

            return new PlanillaDto
            {
                Id = planilla.Id,
                Periodo = planilla.Periodo,
                FechaCreacion = planilla.FechaCreacion,
                FechaPago = planilla.FechaPago,
                Estado = planilla.Estado
            };
        }

        public async Task<PlanillaDto> UpdateEstado(int id, string estado)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            
            if (planilla == null)
                throw new Exception($"Planilla con ID {id} no encontrada");

            planilla.Estado = estado;

            _context.Planillas.Update(planilla);
            await _context.SaveChangesAsync();

            return new PlanillaDto
            {
                Id = planilla.Id,
                Periodo = planilla.Periodo,
                FechaCreacion = planilla.FechaCreacion,
                FechaPago = planilla.FechaPago,
                Estado = planilla.Estado
            };
        }

        public async Task<bool> DeletePlanilla(int id)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            
            if (planilla == null)
                throw new Exception($"Planilla con ID {id} no encontrada");

            // No permitir eliminar una planilla con estado "Pagada"
            if (planilla.Estado == "Pagada")
                throw new Exception("No se puede eliminar una planilla con estado 'Pagada'");

            _context.Planillas.Remove(planilla);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PlanillaDto> GenerarPlanilla(string periodo)
        {
            // Validar que no exista planilla para este periodo
            var existingPlanilla = await _context.Planillas
                .FirstOrDefaultAsync(p => p.Periodo == periodo);
            
            if (existingPlanilla != null)
                throw new Exception($"Ya existe una planilla para el periodo {periodo}");

            var planilla = new Planilla
            {
                Periodo = periodo,
                FechaCreacion = DateTime.Now,
                FechaPago = DateTime.Now,
                Estado = "Pendiente"
            };

            _context.Planillas.Add(planilla);
            await _context.SaveChangesAsync();

            return new PlanillaDto
            {
                Id = planilla.Id,
                Periodo = planilla.Periodo,
                FechaCreacion = planilla.FechaCreacion,
                FechaPago = planilla.FechaPago,
                Estado = planilla.Estado
            };
        }
    }
}
