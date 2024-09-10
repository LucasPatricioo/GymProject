using API.Data.DTO.Autenticacao;
using API.Domain.Exceptions;
using API.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Autenticar([FromBody] LoginAutenticacaoDTO loginRecebido)
        {
            try
            {
                string token = _autenticacaoService.GerarToken(loginRecebido);
                return Ok(new { Token = token });
            }
            catch (UsuarioNaoEncontradoException usuarioEx)
            {
                return BadRequest(usuarioEx.Message);
            }
            catch (AutenticacaoException autenticacaoEx)
            {
                return BadRequest(autenticacaoEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
