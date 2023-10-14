using APIEscola.Domain.Entities;
using APIEscola.Domain.Interfaces.Repository;
using APIEscola.Domain.ViewModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace APIEscola.Infra.Data.Repositories
{
    public class AlunoRepository : APIEscolaRepositoryBase, IAlunoRepository
    {
        private readonly IConfiguration _configuration;

        public AlunoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Aluno InserirAluno(Aluno aluno)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                string query = "INSERT INTO Aluno (Nome, Usuario, Senha, Ativo) VALUES (@Nome, @Usuario, @Senha, @Ativo); SELECT SCOPE_IDENTITY()";
                
                int alunoId = dbConnection.QueryFirstOrDefault<int>(query, aluno);
                
                string selectQuery = "SELECT * FROM Aluno WHERE IdAluno = @IdAluno";
                Aluno insertedAluno = dbConnection.QueryFirstOrDefault<Aluno>(selectQuery, new { IdAluno = alunoId });

                return insertedAluno;
            }
        }

        public Aluno AtualizarAluno(AtualizarAlunoViewModel aluno)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                string updateQuery = "UPDATE Aluno SET Nome = @Nome, Usuario = @Usuario, Ativo = @Ativo WHERE IdAluno = @IdAluno";
                
                dbConnection.Execute(updateQuery, aluno);
                
                string selectQuery = "SELECT * FROM Aluno WHERE IdAluno = @IdAluno";
                Aluno updatedAluno = dbConnection.QueryFirstOrDefault<Aluno>(selectQuery, new { IdAluno = aluno.IdAluno });

                return updatedAluno;
            }
        }        

        public void ExcluirAluno(int idAluno)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                string query = "DELETE FROM Aluno WHERE IdAluno = @IdAluno";
                dbConnection.Execute(query, new { IdAluno = idAluno });
            }
        }

        public IEnumerable<Aluno> ListarAlunosAtivos()
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                var result = dbConnection.Query<Aluno>("Aluno_GetAtivos", commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public Aluno ObterAlunoPorId(int idAluno)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                string query = "SELECT * FROM Aluno WHERE IdAluno = @IdAluno";
                return dbConnection.QueryFirstOrDefault<Aluno>(query, new { IdAluno = idAluno });
            }
        }

    }
}