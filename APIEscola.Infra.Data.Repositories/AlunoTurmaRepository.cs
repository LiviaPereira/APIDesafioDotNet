using APIEscola.Domain.Entities;
using APIEscola.Domain.Interfaces.Repository;
using APIEscola.Domain.ViewModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace APIEscola.Infra.Data.Repositories
{
    public class AlunoTurmaRepository : APIEscolaRepositoryBase, IAlunoTurmaRepository
    {
        private readonly IConfiguration _configuration;

        public AlunoTurmaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void InserirAlunoTurma(int idAluno, int idTurma)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();         
                
                string query = "INSERT INTO Aluno_Turma (IdAluno, IdTurma) VALUES (@IdAluno, @IdTurma)";
                dbConnection.Execute(query, new { IdAluno = idAluno, IdTurma = idTurma });
            }
        }

        public void AtualizarAlunoTurma(int idAluno, int idTurma, int novoIdAluno, int novoIdTurma)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();

                string query = "UPDATE Aluno_Turma SET IdAluno = @NovoIdAluno, IdTurma = @NovoIdTurma WHERE IdAluno = @IdAluno AND IdTurma = @IdTurma";
                dbConnection.Execute(query, new { IdAluno = idAluno, IdTurma = idTurma, NovoIdAluno = novoIdAluno, NovoIdTurma = novoIdTurma });
            }
        }


        public bool ExisteAlunoTurma(int idAluno, int idTurma)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                string query = "SELECT COUNT(*) FROM Aluno_Turma WHERE IdAluno = @IdAluno AND IdTurma = @IdTurma";
                int count = dbConnection.QueryFirstOrDefault<int>(query, new { IdAluno = idAluno, IdTurma = idTurma });
                return count > 0;
            }
        }

        public IEnumerable<AlunoTurmaViewModel> ListarTurmasEAlunosRelacionados()
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();

                string query = "SELECT T.IdTurma, T.NomeTurma, A.IdAluno, A.Nome " +
                              "FROM Turma T " +
                              "INNER JOIN Aluno_Turma AT ON T.IdTurma = AT.IdTurma " +
                              "INNER JOIN Aluno A ON AT.IdAluno = A.IdAluno";
                return dbConnection.Query<AlunoTurmaViewModel>(query);
            }
        }

        public void ExcluirAlunoTurma(int idAluno, int idTurma)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();

                string query = "DELETE FROM Aluno_Turma WHERE IdAluno = @IdAluno AND IdTurma = @IdTurma";
                dbConnection.Execute(query, new { IdAluno = idAluno, IdTurma = idTurma });
            }
        }    




    }
}
