using BeautyAppointments.API.DTOs;
using BeautyAppointments.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyAppointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly ServicioRepository _repository;

        public ServiciosController(ServicioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("ServicioObtenerTodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(await _repository.ServicioObtenerTodos());

        }

        [HttpGet("ServicioObtenerPorId/{id}")]
        public async Task<IActionResult> ServicioObtenerPorId(int id)
        {
            var servicio = await _repository.ServicioObtenerPorId(id);
            return servicio == null ? NotFound($"No existe un servicio con el id {id}")): Ok(servicio);
        }

        [HttpPost("ServicioCrear")]
        public async Task<IActionResult> ServicioCrear([FromBody] ServicioCrearDto servicio)
        {
            var id = await _repository.ServicioCrear(servicio);
            return Ok(new { IdServicio = id });
        }

        [HttpPut("ServicioActualizar/{id}")]
        public async Task<IActionResult> ServicioActualizar(int id, [FromBody] ServicioActualizarDto servicio)
        {
            var actualizado = await _repository.ServicioActualizar(id, servicio);
            return actualizado ? NoContent() : NotFound($"No existe un servicio con el id {id}");
        }

        [HttpDelete("ServicioEliminar/{id}")]
        public async Task<IActionResult> ServicioEliminar(int id)
        {
            var eliminado = await _repository.ServicioEliminar(id);
            if (!eliminado) return NotFound($"No existe un servicio con el id {id}");
            return NoContent();
        }
    }
}
