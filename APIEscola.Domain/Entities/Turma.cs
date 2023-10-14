using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEscola.Domain.Entities
{
    public class Turma
    {
        [Key]
        public int IdTurma { get; set; }
        public int IdCurso { get; set; }
        public string NomeTurma { get; set; }
        public int Ano { get; set; }
        public bool Ativo { get; set; }
    }
}
