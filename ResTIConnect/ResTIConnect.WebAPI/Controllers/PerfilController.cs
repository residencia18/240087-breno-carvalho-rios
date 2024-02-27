using Microsoft.AspNetCore.Authorization;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ResTIConnect.WebAPI.Controllers{
    [ApiController]
    [Route("/api/v0.1/")]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _perfilService;
        public List<PerfilViewModel> Perfis => _perfilService.GetAll();
        public PerfilController(IPerfilService service) => _perfilService = service;

        [HttpGet("perfis")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Get()
        {
            return Ok(Perfis);
        }

        [HttpGet("perfil/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult GetById(int id)
        {
            var perfil = _perfilService.GetById(id);
            return Ok(perfil);
        }
        [HttpPost("perfil")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Post([FromBody] NewPerfilInputModel perfil)
        {
            _perfilService.Create(perfil);

            return CreatedAtAction(nameof(Get), perfil);

        }
        [HttpPut("perfil/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Put(int id, [FromBody] NewPerfilInputModel perfil)
        {
            if (_perfilService.GetById(id) == null)
                return NoContent();
            _perfilService.Update(id, perfil);
            return Ok(_perfilService.GetById(id));
        }

        [HttpDelete("perfil/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Delete(int id)
        {
            if (_perfilService.GetById(id) == null)
                return NoContent();
            _perfilService.Delete(id);
            return Ok();
        }
    }
}
