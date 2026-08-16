using System.Data;
using GESTORDEBIBLIOTECA.Features.Socio.Model;
using Dapper;
using System.Data.Common;

namespace GESTORDEBIBLIOTECA.Features.Socio.Repository;

public class SocioRepository : ISocioRepository
{
    private readonly IDbConnection _connection;

    public SocioRepository (DbConnection connection)
    {
        _connection = connection;
    }

    public async Task<Model.Socio> CreateSocio(Model.Socio socio)
    {
        var sql = "INSERT INTO socios (nombrecompleto, email) VALUES (@NombreCompleto, @Email) RETURNING id;";
        var id = await _connection.QuerySingleAsync<int>(sql, socio);
        socio.id = id;
        return socio;
    }

    public async Task<IEnumerable<Model.Socio>> GetAllSocios()
    {
        var sql = "SELECT id, nombrecompleto AS NombreCompleto, email AS Email FROM socios";
        return await _connection.QueryAsync<Model.Socio>(sql);
    }
}