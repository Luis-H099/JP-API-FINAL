using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Domain;
using Modelo.Infra.Repositorio.Interfaces;
using Modelo.Application.Interface;


namespace JP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplication _alunoApplication;
        private readonly ICepService _cepService;

        public AlunoController(IAlunoApplication alunoApplication, ICepService cepService)
        {
            _alunoApplication = alunoApplication;
            _cepService = cepService;
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
        [HttpPost("adicionar")]
        public IActionResult AdicionarAluno([FromBody] Aluno aluno)
        {
            try
            {
                _alunoApplication.AdicionarAluno(aluno);
                return Ok("Aluno adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar aluno: {ex.Message}");
            }
        }

        [HttpPost("BuscarCep/{cep}")]
        public async Task<IActionResult> BuscarCep(string cep)
        {
            try
            {
                var endereco = await _cepService.BuscarEnderecoPorCep(cep);
                
                return Ok(endereco);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
        

    

