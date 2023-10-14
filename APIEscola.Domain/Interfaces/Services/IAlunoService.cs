using APIEscola.Domain.Entities;
using APIEscola.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEscola.Domain.Interfaces.Services
{
    public interface IAlunoService
    {
        Aluno InserirAluno(Aluno aluno);
        Aluno AtualizarAluno(AtualizarAlunoViewModel aluno);
        void ExcluirAluno(int idAluno);
        IEnumerable<Aluno> ListarAlunosAtivos();
        Aluno ObterAlunoPorId(int idAluno);
    }
}
