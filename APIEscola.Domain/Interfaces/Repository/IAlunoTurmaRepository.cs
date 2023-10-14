using APIEscola.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEscola.Domain.Interfaces.Repository
{
    public interface IAlunoTurmaRepository
    {
        void InserirAlunoTurma(int idAluno, int idTurma);
        bool ExisteAlunoTurma(int idAluno, int idTurma);
        IEnumerable<AlunoTurmaViewModel> ListarTurmasEAlunosRelacionados();
        void ExcluirAlunoTurma(int idAluno, int idTurma);
        void AtualizarAlunoTurma(int idAluno, int idTurma, int novoIdAluno, int novoIdTurma);
    }
}
