using APIEscola.Domain.Entities;
using APIEscola.Domain.Interfaces.Repository;
using APIEscola.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace APIEscola.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public Turma InserirTurma(Turma turma)
        {
            if(turma.Ano < DateTime.Now.Year)
            {
                throw new Exception("Não é permitido criar turmas com datas anteriores à atual.");
            }
            if(_turmaRepository.ExisteTurmaComNome(turma.NomeTurma))
            {
                throw new Exception("Já existe uma turma com esse nome.");
            }
            
            return _turmaRepository.InserirTurma(turma);
        }

        public Turma AtualizarTurma(Turma turma)
        {
            if (turma.Ano < DateTime.Now.Year)
            {
                throw new Exception("Não é permitido atualizar turmas com datas anteriores à atual.");
            }
            

            return _turmaRepository.AtualizarTurma(turma);
        }

        public void ExcluirTurma(int idTurma)
        {
            
            _turmaRepository.ExcluirTurma(idTurma);
        }

        public IEnumerable<Turma> ListarTurmasAtivas()
        {
            
            return _turmaRepository.ListarTurmasAtivas();
        }

        public Turma ObterTurmaPorId(int idTurma)
        {
            
            return _turmaRepository.ObterTurmaPorId(idTurma);
        }
    }
}
