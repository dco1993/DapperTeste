using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperTeste.Model;

namespace DapperTeste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sql = $"exec spUserCels_GetById {1}";
            List<UserCelsModel> data = DataManager.GetUsersCel(sql);

            Console.WriteLine(data[0].UsrNome);
            Console.WriteLine(data[0].UsrSbnome);
            Console.WriteLine(data[0].UsrEmail);

            int cont = 0; 

            foreach (UserCelsModel user in data)
            {
                cont++;
                Console.WriteLine($"-----> Cel({cont}): ({user.UsrCels.CelDdd}) {user.UsrCels.CelNum}");
            }

        
        }
    }
}
