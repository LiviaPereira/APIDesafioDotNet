using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEscola.Domain.ViewModels
{
    public class AtualizarAlunoTurmaViewModel
    {
        public int IdAluno { get; set; }
        public int IdTurma { get; set; }
        public int NovoIdAluno { get; set; }
        public int NovoIdTurma { get; set; }
    }
}
