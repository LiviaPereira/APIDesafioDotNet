using APIEscola.Domain.Entities;
using APIEscola.Domain.Interfaces.Services;
using APIEscola.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APIEscola.Site.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult InserirAluno([FromBody] InserirAlunoViewModel aluno)
        {
            try
            {
                var novoAluno = new Aluno
                {
                    
                    Nome = aluno.Nome,
                    Usuario = aluno.Usuario,
                    Senha = aluno.Senha,
                    Ativo = true
                };

                var alunoInserido = _alunoService.InserirAluno(novoAluno);
                
                
                return Ok(alunoInserido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult AtualizarAluno([FromBody] AtualizarAlunoViewModel aluno)
        {
            try
            {                
                var alunoAtualizado = _alunoService.AtualizarAluno(aluno);

                return Ok(alunoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("excluir/{idAluno}")]
        public IActionResult ExcluirAluno(int idAluno)
        {
            try
            {
                _alunoService.ExcluirAluno(idAluno);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("listar-ativos")]
        public IActionResult ListarAlunosAtivos()
        {
            try
            {
                var alunos = _alunoService.ListarAlunosAtivos();
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("obter/{idAluno}")]
        public IActionResult ObterAlunoPorId(int idAluno)
        {
            try
            {
                var aluno = _alunoService.ObterAlunoPorId(idAluno);
                if (aluno == null)
                {
                    return NotFound();
                }
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
