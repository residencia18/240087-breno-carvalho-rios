using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.WebAPI.InputModels;

namespace OrdemServico.WebAPI.Controllers{
    [ApiController]
    [Route("/api/v0.1/")]
    public class PagamentoController : ControllerBase{
        [HttpGet("pagamentos")]
        public IActionResult GetPagamentos(){
            return NoContent();
        }
        [HttpGet("pagamento/{id}")]
        public IActionResult GetPagamentoById(int id){
            return NoContent();
        }
        [HttpPost("pagamento")]
        public IActionResult CriarPagamento([FromBody] NewPagamentoInputModel pagamento){
            return NoContent();
        }
        [HttpPut("pagamento/{id}")]
        public IActionResult AtualizarPagamento(int id, [FromBody] NewPagamentoInputModel pagamento){
            return NoContent();
        }
        [HttpDelete("pagamento/{id}")]
        public IActionResult DeletarPagamento(int id){
            return NoContent();
        }
    }
}
