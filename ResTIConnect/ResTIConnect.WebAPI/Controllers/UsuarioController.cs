using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ResTIConnect.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public List<UsuarioViewModel> Usuarios => _usuarioService.GetAll();

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("usuarios")]
        public IActionResult Get()
        {
            return Ok(Usuarios);
        }

        [HttpGet("usuario/{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioService.GetById(id);
            return Ok(usuario);
        }

        [HttpGet("usuario/perfil/{perfilId}")]
        public IActionResult GetByPerfilId(int perfilId)
        {
            var usuario = _usuarioService.GetByPerfilId(perfilId);
            return Ok(usuario);
        }

        [HttpGet("usuario/endereco/{estado}")]
        public IActionResult GetByEstado(string estado)
        {
            var usuario = _usuarioService.GetByEstado(estado);
            return Ok(usuario);
        }

        [HttpPost("usuario")]
        public IActionResult Post([FromBody] NewUsuarioInputModel usuario)
        {
            var usuarioId = _usuarioService.Create(usuario);
            return CreatedAtAction(nameof(Get), _usuarioService.GetById(usuarioId));
        }

        [HttpPut("usuario/{id}")]
        public IActionResult Put(int id, [FromBody] NewUsuarioInputModel usuario)
        {
            if (_usuarioService.GetById(id) == null)
                return NoContent();

            _usuarioService.Update(id, usuario);
            return Ok(_usuarioService.GetById(id));
        }

        [HttpDelete("usuario/{id}")]
        public IActionResult Delete(int id)
        {
            if (_usuarioService.GetById(id) == null)
                return NoContent();

            _usuarioService.Delete(id);
            return Ok();
        }
    }
}
