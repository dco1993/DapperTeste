using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using DapperTeste.Model;

namespace DapperTeste
{
    public static class DataManager
    {
        public static string ConnDataBase(string strName = "AzurePersonsDB")
        {
            return ConfigurationManager.ConnectionStrings["AzurePersonsDB"].ConnectionString;
        }

        public static List<T> GetData<T>(string sql)
        {
            using (var cnn = new SqlConnection(ConnDataBase()))
            {
                return cnn.Query<T>(sql).ToList();
            }

        }

        public static List<UserCelsModel> GetUsersCel(string sql)
        {
            using (SqlConnection cnn = new SqlConnection(DataManager.ConnDataBase()))
            {
                return cnn.Query<UserCelsModel, CelsModel, UserCelsModel>(sql, map:(usuario, celular) =>
                {
                    usuario.UsrCel = celular;
                    return usuario;
                },
                splitOn: "UsrNome, CelDdd").ToList();
            }
        }
    }
}
