using APIEscola.Domain.Entities;
using APIEscola.Domain.Interfaces.Repository;
using APIEscola.Domain.Interfaces.Services;
using APIEscola.Domain.ViewModels;
using APIEscola.Infra.Util;
using System.Security.Cryptography;
using System.Text;

namespace APIEscola.Services
{
    public class AlunoService : IAlunoService
    {
        public readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Aluno InserirAluno(Aluno aluno)
        {
            
            if (!Funcoes.ValidarSenha(aluno.Senha))

            {
                throw new Exception("Senha deve conter pelo menos 8 dígitos, uma letra maiúscula, uma letra minúscula, um número e um caractere especial");
            }
            
            aluno.Senha = Funcoes.HashSenha(aluno.Senha); 
            
            
            return _alunoRepository.InserirAluno(aluno);

            
        }

        public Aluno AtualizarAluno(AtualizarAlunoViewModel aluno)
        {            
           
            return _alunoRepository.AtualizarAluno(aluno);

           
        }

        public void ExcluirAluno(int idAluno)
        {            
            _alunoRepository.ExcluirAluno(idAluno);
        }       

        public IEnumerable<Aluno> ListarAlunosAtivos()
        {            
            return _alunoRepository.ListarAlunosAtivos();
        }

        public Aluno ObterAlunoPorId(int idAluno)
        {
           
            return _alunoRepository.ObterAlunoPorId(idAluno);
        }


    }
}