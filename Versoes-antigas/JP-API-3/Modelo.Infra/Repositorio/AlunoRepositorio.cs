using Dapper;
using Microsoft.Data.SqlClient;
using Modelo.Domain;
using Modelo.Infra.Repositorio.Interfaces;

namespace Modelo.Infra.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly DbConnectionFactory _connectionFactory;

        public AlunoRepositorio(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Aluno> BuscarAluno(int id)
        {

            using var connection = _connectionFactory.CreateConnection();

            string sql = "Select * from ALuno Where Id = @Id";

            var aluno = await connection.QueryFirstOrDefaultAsync<Aluno>(sql, new {id = id});

            return aluno;
        }

        public void Adicionar(Aluno aluno)
        {
            using var connection = new SqlConnection(_connectionFactory.CreateConnection().ConnectionString);
            connection.Open();

            var command = new SqlCommand(
                @"INSERT INTO Aluno (Nome, Matricula, Cep, Endereco, Bairro, Cidade) 
                  VALUES (@Nome, @Matricula, @Cep, @Endereco, @Bairro, @Cidade)", connection);

            command.Parameters.AddWithValue("@Nome", aluno.Nome);
            command.Parameters.AddWithValue("@Matricula", aluno.Matricula);
            command.Parameters.AddWithValue("@Cep", aluno.Cep);
            command.Parameters.AddWithValue("@Endereco", aluno.Endereco);
            command.Parameters.AddWithValue("@Bairro", aluno.Bairro);
            command.Parameters.AddWithValue("@Cidade", aluno.Cidade);

            command.ExecuteNonQuery();
        }
    }
}

