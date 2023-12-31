﻿using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS;

public class DatabaseAccess
{
    private string _readConnectionString;
    private string _writeConnectionString;

    public DatabaseAccess(string readConnectionString, string writeConnectionString)
    {
        _readConnectionString = readConnectionString;
        _writeConnectionString = writeConnectionString;
    }

    public async Task<List<T>> LoadData<T, U>(string sql, U paramaters)
    {
        using (IDbConnection connection = new MySqlConnection(_readConnectionString))
        {
            var rows = await connection.QueryAsync<T>(sql, paramaters);

            return rows.ToList();
        }
    }

    public async Task SaveData<T>(string sql, T paramaters)
    {
        using (IDbConnection connection = new MySqlConnection(_writeConnectionString))
        {
            await connection.ExecuteAsync(sql, paramaters);
        }
    }
}
