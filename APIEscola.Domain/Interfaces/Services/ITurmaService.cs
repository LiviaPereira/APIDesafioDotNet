using APIEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEscola.Domain.Interfaces.Services
{
    public interface ITurmaService
    {
        Turma InserirTurma(Turma turma);
        Turma AtualizarTurma(Turma turma);
        void ExcluirTurma(int idTurma);
        IEnumerable<Turma> ListarTurmasAtivas();
        Turma ObterTurmaPorId(int idTurma);
    }
}
