using APIEscola.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEscola.Domain.Interfaces.Services
{
    public interface IAlunoTurmaService
    {
        void InserirAlunoEmTurma(int idAluno, int idTurma);
        void AtualizarAlunoEmTurma(int idAluno, int idTurma, int novoIdAluno, int novoIdTurma);
        void ExcluirAlunoDeTurma(int idAluno, int idTurma);
        IEnumerable<AlunoTurmaViewModel> ListarAlunosETurmasRelacionados();
    }
}
