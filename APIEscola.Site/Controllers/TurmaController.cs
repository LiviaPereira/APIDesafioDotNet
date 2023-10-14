using APIEscola.Domain.Entities;
using APIEscola.Domain.Interfaces.Services;
using APIEscola.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APIEscola.Site.Controllers
{
    [ApiController]
    [Route("api/turma")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult InserirTurma([FromBody] InserirTurmaViewModel turma)
        {
            try
            {
                var novaTurma = new Turma
                {
                    IdCurso = turma.IdCurso,
                    NomeTurma = turma.NomeTurma,
                    Ano = turma.Ano,
                    Ativo = true
                };

                var turmaInserida = _turmaService.InserirTurma(novaTurma);

                return Ok(turmaInserida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult AtualizarTurma([FromBody] AtualizarTurmaViewModel turma)
        {
            try
            {
                var novaTurma = new Turma
                {
                    IdTurma = turma.IdTurma,
                    IdCurso = turma.IdCurso,
                    NomeTurma = turma.NomeTurma,
                    Ano = turma.Ano,
                    Ativo = turma.Ativo
                };

                var turmaAtualizada = _turmaService.AtualizarTurma(novaTurma);

                return Ok(turmaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("excluir/{idTurma}")]
        public IActionResult ExcluirTurma(int idTurma)
        {
            try
            {
                _turmaService.ExcluirTurma(idTurma);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("listar-ativos")]
        public IActionResult ListarTurmasAtivas()
        {
            try
            {
                var turmas = _turmaService.ListarTurmasAtivas();
                return Ok(turmas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("obter/{idTurma}")]
        public IActionResult ObterTurmaPorId(int idTurma)
        {
            try
            {
                var turma = _turmaService.ObterTurmaPorId(idTurma);
                if (turma == null)
                {
                    return NotFound();
                }
                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
