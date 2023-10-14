namespace APIEscola.Domain.ViewModels
{
    public class AtualizarTurmaViewModel
    {
        public int IdTurma { get; set; }
        public int IdCurso { get; set; }
        public string NomeTurma { get; set; }
        public int Ano { get; set; }
        public bool Ativo { get; set; }
    }
}
