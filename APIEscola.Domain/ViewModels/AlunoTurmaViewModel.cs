using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEscola.Domain.ViewModels
{
    public class AlunoTurmaViewModel
    {
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
    }
}
