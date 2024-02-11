using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.Application.InputModels;

namespace OrdemDeServico.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v0.1/")]
    public class ServicoController : ControllerBase
    {
        [HttpGet("servicos")]
        public IActionResult Get()
        {

            return NoContent();
        }

        [HttpGet("servico/{id}")]
        public IActionResult GetById(int id)
        {

            return NoContent();
        }

        [HttpPost("servico")]
        public IActionResult Post([FromBody] NewServicoInputModel servico)
        {

            return NoContent();
        }

        [HttpPut("servico/{id}")]
        public IActionResult Put(int id, [FromBody] NewServicoInputModel servico)
        {

            return NoContent();
        }

        [HttpDelete("servico/{id}")]
        public IActionResult Delete(int id)
        {

            return NoContent();
        }
    }
}
