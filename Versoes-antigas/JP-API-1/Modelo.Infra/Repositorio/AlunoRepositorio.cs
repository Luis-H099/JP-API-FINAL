using Dapper;
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
    }
}
