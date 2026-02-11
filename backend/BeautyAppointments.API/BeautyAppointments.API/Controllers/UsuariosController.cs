using BeautyAppointments.API.DTOs;
using BeautyAppointments.API.Models;
using BeautyAppointments.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyAppointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("UsuarioObtenerTodos")]
        public async Task<IActionResult> UsuarioObtenerTodos()
        {
            return Ok(await _usuarioRepository.UsuarioObtenerTodos());
        }

        [HttpGet("UsuarioObtenerPorId/{id}")]
        public async Task<IActionResult> UsuarioObetenerPorId(int id)
        {
            var usuario = await _usuarioRepository.UsuarioObtenerPorId(id);
            return usuario == null ? NotFound($"No existe un usuario con el id {id}") : Ok(usuario);
        }

        [HttpPost("UsuarioCrear")]
        public async Task<IActionResult> UsuarioCrear([FromBody] Usuario usuario)
        {
            var id = await _usuarioRepository.UsuarioCrear(usuario);
            return Ok(new { IdUsuario = id });
        }

        //Arreglar
        [HttpPut("UsuarioActualizar/{id}")]
        public async Task<IActionResult> UsuarioActualizar( int id, [FromBody] UsuarioActualizarDto usuario)
        {
            var actualizado = await _usuarioRepository.UsuarioActualizar(id, usuario);
            return actualizado ? NoContent() : NotFound($"No existe un usuario con el id {id}");
        }

        [HttpDelete("UsuarioEliminar/{id}")]
        public async Task<IActionResult> UsuarioEliminar(int id)
        {
            var eliminado = await _usuarioRepository.UsuarioEliminar(id);
            return eliminado ? NoContent() : NotFound($"No existe un usuario con el id {id}");

        }
    }
}
