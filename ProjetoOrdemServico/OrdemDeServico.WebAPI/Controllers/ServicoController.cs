using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.WebAPI.InputModels.NewPrestadorDeServicoInputModel;

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
        public IActionResult Post([FromBody] NewPrestadorDeServicoInputModel servico)
        {
            
            return NoContent();
        }

        [HttpPut("servico/{id}")]
        public IActionResult Put(int id, [FromBody] NewPrestadorDeServicoInputModel servico)
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
