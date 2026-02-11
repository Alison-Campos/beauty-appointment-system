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

        [HttpGet("ClientesObtenerTodos")]
        public async Task<IActionResult> ClientesObtenerTodos()
        {
            return Ok(await _repository.ClienteObtenerTodos());
        }

        [HttpGet("ClientesObtenerPorId/{id}")]
        public async Task<IActionResult> ClientesObtenerPorId (int id)
        {
            var cliente = await _repository.ClientesObtenerPorId(id);
            return cliente == null ? NotFound($"No existe un cliente con el id {id}") : Ok(cliente);
        }

        [HttpPost("ClientesCrear")]
        public async Task<IActionResult> ClientesCrear([FromBody] ClienteCrearDto cliente)
        {
            var id = await _repository.ClienteCrear(cliente);
            return Ok( new { IdCliente = id });
        }

        [HttpPut("ClientesActualizar/{id}")]
        public async Task<IActionResult> ClientesActualizar (int id, [FromBody] ClienteActualizarDto cliente )
        {
            var actualizado = await _repository.ClienteActualizar(id, cliente); 
            return actualizado ? NoContent() : NotFound($"No existe un cliente con el id {id}");
        }

        [HttpDelete("ClientesEliminar/{id}")]
        public async Task<IActionResult> ClientesEliminar (int id)
        {
            var eliminado = await _repository.ClienteEliminar(id);
            return eliminado ? NoContent() : NotFound($"No existe un cliente con el id {id}");
        }
    }
}
