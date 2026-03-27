using ExamenUnidad2.Services;
using ExamenUnidad2.Dtos.Empleados;
using ExamenUnidad2.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ExamenUnidad2.Controllers
{
    [Route("api/empleados")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: api/empleados
        [HttpGet]
        public async Task<ActionResult<List<EmpleadoDto>>> GetAllEmpleados()
        {
            var empleados = await _empleadoService.GetAllEmpleados();
            return StatusCode(200, new { message = HttpMessageResponse.REGISTERS_FOUND, data = empleados });
        }

        // GET: api/empleados/activos
        [HttpGet("activos")]
        public async Task<ActionResult<List<EmpleadoDto>>> GetEmpleadosActivos()
        {
            var empleados = await _empleadoService.GetEmpleadosActivos();
            return StatusCode(200, new { message = HttpMessageResponse.REGISTERS_FOUND, data = empleados });
        }

        // GET: api/empleados/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDto>> GetEmpleadoById(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoById(id);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTER_FOUND, data = empleado });
        }

        // POST: api/empleados
        [HttpPost]
        public async Task<ActionResult<EmpleadoDto>> CreateEmpleado(EmpleadoCreateDto dto)
        {
            var empleado = await _empleadoService.CreateEmpleado(dto);
            return StatusCode(201, new { message = HttpMessageResponse.REGISTER_CREATED, data = empleado });
        }

        // PUT: api/empleados/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EmpleadoDto>> UpdateEmpleado(int id, EmpleadoUpdateDto dto)
        {
            var empleado = await _empleadoService.UpdateEmpleado(id, dto);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTER_UPDATED, data = empleado });
        }

        // DELETE: api/empleados/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            await _empleadoService.DeleteEmpleado(id);
            return StatusCode(200, new { message = HttpMessageResponse.REGISTER_DELETED });
        }
    }
}