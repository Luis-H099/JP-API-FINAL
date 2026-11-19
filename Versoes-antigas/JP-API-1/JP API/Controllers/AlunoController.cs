using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Domain;
using Modelo.Infra.Repositorio.Interfaces;

namespace JP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplication _alunoApplication;
        public AlunoController()
        {

        }

        [HttpGet("BuscarDadosAluno/{id}")]
        public async Task<IActionResult> BuscarDadosAluno(int id)
        {
            try
            {
                Aluno aluno = new Aluno();

                aluno.Id = id;
                aluno.Nome = "James";
                aluno.Matricula = "ABC123";

                return Ok(aluno);
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }

        }
    }
}
