using Dapper;
using Gestion_Labo.lib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Labo.lib.Internal.DataAccess
{

    //inner join return only the data with no null like malades that they have analyses only but left join return every thing even the people that doesnt have analyse records
    //scope_identity() to get the inserted id for the malade
    public class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        //load data with parameters like id or something
        public async Task<List<T>>  LoadData<T, U>(string storedProcedure, U parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = (await connection.QueryAsync<T>(storedProcedure, parametres, commandType: CommandType.StoredProcedure)).ToList();

                return rows;
            }
        }


        // save data in the data base
        public async Task SaveData<T>(string storedProcedure, T parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(storedProcedure, parametres, commandType: CommandType.StoredProcedure);
               

            }
        }

        public async Task<T> SaveDataAndReturnID<T,U>(string storedProcedure, U parametres, string connectionStringName)

        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                 var MaladeID = (await connection.QueryAsync<T>(storedProcedure, parametres, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return MaladeID;

            }
        }

       

        public async Task DeleteData<T>(string storedProcedure, T parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(storedProcedure, parametres, commandType: CommandType.StoredProcedure);

            }
        }






        public async Task UpdateData<T>(string storedProcedure, T parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(storedProcedure, parametres, commandType: CommandType.StoredProcedure);

            }
        }
    }
}
