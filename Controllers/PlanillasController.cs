using ExamenUnidad2.Services;
using ExamenUnidad2.Dtos.Planilla;
using ExamenUnidad2.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ExamenUnidad2.Controllers
{
    [Route("api/planillas")]
    [ApiController]
    public class PlanillasController : ControllerBase
    {
        private readonly IPlanillaService _planillaService;

        public PlanillasController(IPlanillaService planillaService)
        {
            _planillaService = planillaService;
        }

        // GET: api/planillas
        [HttpGet]
        public async Task<ActionResult<List<PlanillaDto>>> GetAllPlanillas()
        {
            var planillas = await _planillaService.GetAllPlanillas();
            return StatusCode(200, new { message = HttpMessageResponse.REGISTERS_FOUND, data = planillas });
        }

        // GET: api/planillas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanillaDto>> GetPlanillaById(int id)
        {
            var planilla = await _planillaService.GetPlanillaById(id);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTER_FOUND, data = planilla });
        }

        // GET: api/planillas/periodo/{periodo}
        [HttpGet("periodo/{periodo}")]
        public async Task<ActionResult<List<PlanillaDto>>> GetPlanillasByPeriodo(string periodo)
        {
            var planillas = await _planillaService.GetPlanillasByPeriodo(periodo);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTERS_FOUND, data = planillas });
        }

        // POST: api/planillas
        [HttpPost]
        public async Task<ActionResult<PlanillaDto>> CreatePlanilla(PlanillaCreateDto dto)
        {
            var planilla = await _planillaService.CreatePlanilla(dto);
            return StatusCode(201, new { message = HttpMessageResponse.REGISTER_CREATED, data = planilla });
        }

        // PUT: api/planillas/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<PlanillaDto>> UpdatePlanilla(int id, PlanillaUpdateDto dto)
        {
            var planilla = await _planillaService.UpdatePlanilla(id, dto);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTER_UPDATED, data = planilla });
        }

        // PUT: api/planillas/{id}/estado
        [HttpPut("{id}/estado")]
        public async Task<ActionResult<PlanillaDto>> UpdateEstado(int id, [FromBody] string estado)
        {
            var planilla = await _planillaService.UpdateEstado(id, estado);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTER_UPDATED, data = planilla });
        }

        // DELETE: api/planillas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanilla(int id)
        {
            await _planillaService.DeletePlanilla(id);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTER_DELETED });
        }

        // POST: api/planillas/generar
        [HttpPost("generar")]
        public async Task<ActionResult<PlanillaDto>> GenerarPlanilla([FromBody] GenerarPlanillaDto dto)
        {
            var planilla = await _planillaService.GenerarPlanilla(dto.Periodo);
            return StatusCode(201, new { message = HttpMessageResponse.REGISTER_CREATED, data = planilla });
        }
    }
}
