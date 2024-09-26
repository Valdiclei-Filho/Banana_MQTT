using Banana.UI.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace Banana.UI;

public class Database
{
    private static MySqlConnection connection = new MySqlConnection("Server=localhost;Database=banana;Uid=root;Pwd=Chamex13;");
    public static async Task Gravar(LeituraModel leitura)
    {
        var sql = "INSERT INTO leitura_ambiente (ID, temperature, humidity) VALUES (?, ?, ?)";

        await connection.ExecuteAsync(sql, new
        {
            ID = Guid.NewGuid().ToString(),
            leitura.temperature,
            leitura.humidity
        });
    }

    public static async Task<IEnumerable<LeituraModel>> GetAll()
    {
        return await connection.QueryAsync<LeituraModel>("SELECT * FROM leitura_ambiente");
    }
}
