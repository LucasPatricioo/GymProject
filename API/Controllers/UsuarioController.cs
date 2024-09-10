using API.Data.DTO.Usuario;
using API.Domain.Enums;
using API.Domain.Exceptions;
using API.Domain.Models;
using API.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize]
        [HttpGet("BuscarUsuarios")]
        public IActionResult BuscarUsuario()
        {
            try
            {
                var listaUsuariosRecebidos = _usuarioService.BuscarUsuario();

                if (listaUsuariosRecebidos.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(listaUsuariosRecebidos);
            }
            catch (UsuarioException usuarioEx)
            {
                return BadRequest(usuarioEx.Message);
            }
        }

        [Authorize]
        [HttpGet("BuscarUsuario")]
        public IActionResult BuscarUsuario([FromQuery] int id)
        {
            try
            {
                Usuario usuarioRetornado = _usuarioService.BuscarUsuario(id);

                return Ok(usuarioRetornado);
            }
            catch (UsuarioNaoEncontradoException)
            {
                return NoContent();
            }
            catch (UsuarioException usuarioEx)
            {
                return BadRequest(usuarioEx.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("CriarUsuario")]
        public IActionResult CriarUsuario([FromBody] CreateUsuarioDTO usuario)
        {
            try
            {
                Usuario usuarioRetornado = _usuarioService.CriarUsuario(usuario);

                return CreatedAtAction(nameof(BuscarUsuario), new { id = usuarioRetornado.IdUsuario }, usuarioRetornado);
            }
            catch (UsuarioException usuarioEx)
            {
                return BadRequest(usuarioEx.Message);
            }
        }

        [Authorize]
        [HttpPut("AtualizarUsuario")]
        public IActionResult AtualizarUsuario([FromBody] UpdateUsuarioDTO usuario)
        {
            try
            {
                Usuario usuarioRetornado = _usuarioService.AtualizarUsuario(usuario);

                return Ok(usuarioRetornado);
            }
            catch (UsuarioException usuarioEx)
            {
                return BadRequest(usuarioEx.Message);
            }
        }

        [Authorize]
        [HttpDelete("RemoverUsuario")]
        public IActionResult RemoverUsuario(int id)
        {
            try
            {
                _usuarioService.RemoverUsuario(id);

                return NoContent();
            }
            catch (UsuarioException usuarioEx)
            {
                return BadRequest(usuarioEx.Message);
            }
        }
    }
}
