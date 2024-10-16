using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LauraOliveira.Models;

namespace LauraOliveira.Controllers
{
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public FuncionarioController(AppDataContext ctx)
        {
            _ctx = ctx; // Inicializa o contexto
        }

        // POST: api/funcionario
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            _ctx.Funcionarios.Add(funcionario);
            _ctx.SaveChanges();

            return Created("", funcionario);
        }

        [HttpPost]
        [Route("Listar")]
        public IActionResult ObterFuncionarios()
        {
            var funcionarios = _ctx.Funcionarios.ToList();
            return Ok(funcionarios);
        }
    }
}