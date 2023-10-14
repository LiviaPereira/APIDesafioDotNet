using APIEscola.Domain.Entities;
using APIEscola.Domain.Interfaces.Repository;
using APIEscola.Domain.Interfaces.Services;
using APIEscola.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEscola.Services
{
    public class AlunoTurmaService : IAlunoTurmaService
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;

        public AlunoTurmaService(
            IAlunoTurmaRepository alunoTurmaRepository,
            IAlunoRepository alunoRepository,
            ITurmaRepository turmaRepository)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
        }

        public void InserirAlunoEmTurma(int idAluno, int idTurma)
        {
            
            var aluno = _alunoRepository.ObterAlunoPorId(idAluno);
            var turma = _turmaRepository.ObterTurmaPorId(idTurma);

            if (aluno == null)
            {
                throw new Exception("Aluno não encontrado.");
            }

            if (turma == null)
            {
                throw new Exception("Turma não encontrada.");
            }
            if (_alunoTurmaRepository.ExisteAlunoTurma(idAluno, idTurma))
            {
                throw new Exception("Já existe uma relação entre este aluno e turma.");
            }

            _alunoTurmaRepository.InserirAlunoTurma(idAluno, idTurma);
        }

        public void AtualizarAlunoEmTurma(int idAluno, int idTurma, int novoIdAluno, int novoIdTurma)
        {
            if (idAluno == novoIdAluno && idTurma == novoIdTurma)
            {                
                return;
            }

            if (!_alunoTurmaRepository.ExisteAlunoTurma(idAluno, idTurma))
            {
                throw new Exception("Relação entre aluno e turma não encontrada.");
            }

            if (_alunoTurmaRepository.ExisteAlunoTurma(novoIdAluno, novoIdTurma))
            {
                throw new Exception("Já existe uma relação entre este novo aluno e turma.");
            }


            var novoAluno = _alunoRepository.ObterAlunoPorId(novoIdAluno);
            var novaTurma = _turmaRepository.ObterTurmaPorId(novoIdTurma);

            if (novoAluno == null)
            {
                throw new Exception("Novo aluno não encontrado.");
            }

            if (novaTurma == null)
            {
                throw new Exception("Nova turma não encontrada.");
            }

            
            _alunoTurmaRepository.AtualizarAlunoTurma(idAluno, idTurma, novoIdAluno, novoIdTurma);
        }


        public void ExcluirAlunoDeTurma(int idAluno, int idTurma)
        {                    
            
            _alunoTurmaRepository.ExcluirAlunoTurma(idAluno, idTurma);
        }

        public IEnumerable<AlunoTurmaViewModel> ListarAlunosETurmasRelacionados()
        {
            return _alunoTurmaRepository.ListarTurmasEAlunosRelacionados();
        }

    }
}
