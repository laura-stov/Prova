using Microsoft.AspNetCore.Mvc;
using LauraOliveira.Models;

namespace LauraOliveira.Controllers
{
    [Route("api/folha")]
    [ApiController]
    public class FolhaDePagamentoController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public FolhaDePagamentoController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Folha folhaDePagamento)
        {
            if (folhaDePagamento == null)
            {
                return BadRequest("Folha de pagamento não pode ser nula.");
            }

            var funcionario = _ctx.Funcionarios.Find(folhaDePagamento.FuncionarioId);
            if (funcionario == null)
            {
                return NotFound("Funcionário não encontrado.");
            }

            folhaDePagamento.Funcionario = funcionario;

            _ctx.Folhas.Add(folhaDePagamento);
            _ctx.SaveChanges();

            return Created("", folhaDePagamento);
        }

        [HttpGet("listar")]
        public IActionResult ObterFolhasDePagamento()
        {
            var folhas = _ctx.Folhas.ToList();
            return Ok(folhas);
        }

    }
}