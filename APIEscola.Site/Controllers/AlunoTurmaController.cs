
using APIEscola.Domain.Entities;
using APIEscola.Domain.Interfaces.Services;
using APIEscola.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APIEscola.Site.Controllers
{
    [ApiController]
    [Route("api/alunoturma")]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurmaService _alunoTurmaService;

        public AlunoTurmaController(IAlunoTurmaService alunoTurmaService)
        {
            _alunoTurmaService = alunoTurmaService;
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult InserirAlunoEmTurma([FromBody] AlunoTurma alunoTurma)
        {
            try
            {
                _alunoTurmaService.InserirAlunoEmTurma(alunoTurma.IdAluno, alunoTurma.IdTurma);

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult AtualizarAlunoEmTurma([FromBody] AtualizarAlunoTurmaViewModel alunoTurma)
        {
            try
            {
                _alunoTurmaService.AtualizarAlunoEmTurma(alunoTurma.IdAluno, alunoTurma.IdTurma, alunoTurma.NovoIdAluno, alunoTurma.NovoIdTurma);
                return Ok("Relação aluno-turma atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("excluir/{idAluno}/{idTurma}")]
        public IActionResult ExcluirAlunoDeTurma(int idAluno, int idTurma)
        {
            try
            {
                _alunoTurmaService.ExcluirAlunoDeTurma(idAluno, idTurma);
                return Ok("Aluno excluído da turma com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("listar-relacoes")]
        public IActionResult ListarAlunosETurmasRelacionados()
        {
            try
            {
                var relacoes = _alunoTurmaService.ListarAlunosETurmasRelacionados();
                return Ok(relacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
