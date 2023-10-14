using APIEscola.Domain.Entities;
using APIEscola.Domain.Interfaces.Repository;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEscola.Infra.Data.Repositories
{
    public class TurmaRepository : APIEscolaRepositoryBase, ITurmaRepository
    {

        private readonly IConfiguration _configuration;

        public TurmaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Turma InserirTurma(Turma turma)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                string query = "INSERT INTO Turma (IdCurso, NomeTurma, Ano, Ativo) VALUES (@IdCurso, @NomeTurma, @Ano, @Ativo); SELECT SCOPE_IDENTITY()";
                
                int turmaId = dbConnection.QueryFirstOrDefault<int>(query, turma);
                
                string selectQuery = "SELECT * FROM Turma WHERE IdTurma = @IdTurma";
                Turma insertedTurma = dbConnection.QueryFirstOrDefault<Turma>(selectQuery, new { IdTurma = turmaId });

                return insertedTurma;
            }
        }

        public Turma AtualizarTurma(Turma turma)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                string updateQuery = "UPDATE Turma SET IdCurso = @IdCurso, NomeTurma = @NomeTurma, Ano = @Ano, Ativo = @Ativo WHERE IdTurma = @IdTurma";
                
                dbConnection.Execute(updateQuery, turma);
                
                string selectQuery = "SELECT * FROM Turma WHERE IdTurma = @IdTurma";
                Turma updatedTurma = dbConnection.QueryFirstOrDefault<Turma>(selectQuery, new { IdTurma = turma.IdTurma });

                return updatedTurma;
            }
        }

        public void ExcluirTurma(int idTurma)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                string query = "DELETE FROM Turma WHERE IdTurma = @IdTurma";
                dbConnection.Execute(query, new { IdTurma = idTurma });
            }
        }

        public IEnumerable<Turma> ListarTurmasAtivas()
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                var result = dbConnection.Query<Turma>("Turma_GetAtivas", commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public Turma ObterTurmaPorId(int idTurma)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                string query = "SELECT * FROM Turma WHERE IdTurma = @IdTurma";
                return dbConnection.QueryFirstOrDefault<Turma>(query, new { IdTurma = idTurma });
            }
        }

        public bool ExisteTurmaComNome(string nomeTurma)
        {
            using (IDbConnection dbConnection = ConnectionAPIEscola)
            {
                dbConnection.Open();
                string query = "SELECT COUNT(*) FROM Turma WHERE NomeTurma = @NomeTurma";
                int count = dbConnection.QueryFirstOrDefault<int>(query, new { NomeTurma = nomeTurma });

                // Se count for maior que zero, já existe uma turma com o mesmo nome, retorna true
                return count > 0;
            }
        }


    }
}
