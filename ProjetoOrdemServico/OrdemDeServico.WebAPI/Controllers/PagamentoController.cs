using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;

namespace OrdemDeServico.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;
        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }
        [HttpGet("pagamentos")]
        public IActionResult GetPagamentos()
        {
            return Ok(_pagamentoService.GetAll());
        }
        [HttpGet("pagamento/{id}")]
        public IActionResult GetPagamentoById(int id)
        {
            var _pagamento = _pagamentoService.GetById(id);
            return Ok(_pagamento);
        }
        [HttpGet("pagamento/metodo/{metodoDePagamento}")]
        public IActionResult GetPagamentoByMetodo(string metodoDePagamento)
        {
            var _pagamento = _pagamentoService.GetPagamentoByMetodo(metodoDePagamento);
            return Ok(_pagamento);
        }
        [HttpPost("pagamento")]
        public IActionResult CriarPagamento([FromBody] NewPagamentoInputModel pagamento)
        {
            var pagamentoId = _pagamentoService.Create(pagamento);
            return CreatedAtAction(nameof(GetPagamentoById), new { id = pagamentoId }, pagamento);
        }
        [HttpPut("pagamento/{id}")]
        public IActionResult AtualizarPagamento(int id, [FromBody] NewPagamentoInputModel pagamento)
        {
            _pagamentoService.Update(id, pagamento);
            return Ok();
        }
        [HttpDelete("pagamento/{id}")]
        public IActionResult DeletarPagamento(int id)
        {
            _pagamentoService.Delete(id);
            return NoContent();
        }
    }
}
