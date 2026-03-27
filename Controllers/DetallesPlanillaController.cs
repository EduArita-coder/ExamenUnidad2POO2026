using ExamenUnidad2.Services;
using ExamenUnidad2.Dtos.DetallePlanilla;
using ExamenUnidad2.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ExamenUnidad2.Controllers
{
    [Route("api/detallesplanilla")]
    [ApiController]
    public class DetallesPlanillaController : ControllerBase
    {
        private readonly IDetallePlanillaService _detallePlanillaService;

        public DetallesPlanillaController(IDetallePlanillaService detallePlanillaService)
        {
            _detallePlanillaService = detallePlanillaService;
        }

        // GET: api/detallesplanilla
        [HttpGet]
        public async Task<ActionResult<List<DetallePlanillaDto>>> GetAll()
        {
            var detalles = await _detallePlanillaService.GetAll();
            return StatusCode(200, new { message = HttpMessageResponse.REGISTERS_FOUND, data = detalles });
        }

        // GET: api/detallesplanilla/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePlanillaDto>> GetById(int id)
        {
            var detalle = await _detallePlanillaService.GetById(id);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTER_FOUND, data = detalle });
        }

        // GET: api/detallesplanilla/planilla/{planillaId}
        [HttpGet("planilla/{planillaId}")]
        public async Task<ActionResult<List<DetallePlanillaDto>>> GetByPlanillaId(int planillaId)
        {
            var detalles = await _detallePlanillaService.GetByPlanillaId(planillaId);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTERS_FOUND, data = detalles });
        }

        // GET: api/detallesplanilla/empleado/{empleadoId}
        [HttpGet("empleado/{empleadoId}")]
        public async Task<ActionResult<List<DetallePlanillaDto>>> GetByEmpleadoId(int empleadoId)
        {
            var detalles = await _detallePlanillaService.GetByEmpleadoId(empleadoId);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTERS_FOUND, data = detalles });
        }

        // POST: api/detallesplanilla
        [HttpPost]
        public async Task<ActionResult<DetallePlanillaDto>> Create(DetallePlanillaCreateDto dto)
        {
            var detalle = await _detallePlanillaService.Create(dto);
            return StatusCode(201, new { message = HttpMessageResponse.REGISTER_CREATED, data = detalle });
        }

        // PUT: api/detallesplanilla/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<DetallePlanillaDto>> Update(int id, DetallePlanillaUpdateDto dto)
        {
            var detalle = await _detallePlanillaService.Update(id, dto);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTER_UPDATED, data = detalle });
        }

        // DELETE: api/detallesplanilla/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _detallePlanillaService.Delete(id);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTER_DELETED });
        }
    }
}
