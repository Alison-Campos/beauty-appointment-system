using BeautyAppointments.API.DTOs;
using BeautyAppointments.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyAppointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteRepository _repository;

        public ClientesController(ClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("ClienteObtenerTodos")]
        public async Task<IActionResult> ClienteObtenerTodos()
        {
            return Ok(await _repository.ClienteObtenerTodos());
        }

        [HttpGet("ClienteObtenerPorId/{id}")]
        public async Task<IActionResult> ClienteObtenerPorId (int id)
        {
            var cliente = await _repository.ClientesObtenerPorId(id);
            return cliente == null ? NotFound($"No existe un cliente con el id {id}") : Ok(cliente);
        }

        [HttpPost("ClienteCrear")]
        public async Task<IActionResult> ClienteCrear([FromBody] ClienteCrearDto cliente)
        {
            var id = await _repository.ClienteCrear(cliente);
            return Ok( new { IdCliente = id });
        }

        [HttpPut("ClienteActualizar/{id}")]
        public async Task<IActionResult> ClienteActualizar (int id, [FromBody] ClienteActualizarDto cliente )
        {
            var actualizado = await _repository.ClienteActualizar(id, cliente); 
            return actualizado ? NoContent() : NotFound($"No existe un cliente con el id {id}");
        }

        [HttpDelete("ClienteEliminar/{id}")]
        public async Task<IActionResult> ClienteEliminar (int id)
        {
            var eliminado = await _repository.ClienteEliminar(id);
            return eliminado ? NoContent() : NotFound($"No existe un cliente con el id {id}");
        }
    }
}
