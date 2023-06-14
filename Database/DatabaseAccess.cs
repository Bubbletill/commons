using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS;

public class DatabaseAccess
{
    private string _connectionString;

    public DatabaseAccess(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<T>> LoadData<T, U>(string sql, U paramaters)
    {
        using (IDbConnection connection = new MySqlConnection(_connectionString))
        {
            var rows = await connection.QueryAsync<T>(sql, paramaters);

            return rows.ToList();
        }
    }

    public Task SaveData<T>(string sql, T paramaters)
    {
        using (IDbConnection connection = new MySqlConnection(_connectionString))
        {
            return connection.ExecuteAsync(sql, paramaters);
        }
    }
}
