using System.ComponentModel.DataAnnotations;

namespace APIEscola.Domain.Entities
{
    public class Aluno
    {
        [Key]
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

    }
}