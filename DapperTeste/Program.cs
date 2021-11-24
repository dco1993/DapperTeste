using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperTeste.Model;
using Newtonsoft.Json;

namespace DapperTeste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sql = $"exec spUserCels_GetById {1}";

            List<UserCelsModel> data = DataManager.GetUsersCel(sql);

            UsrCel usrcel = new UsrCel();

            List<CelsModel> cels = new List<CelsModel>();

            usrcel.UsrNome = data[0].UsrNome;
            usrcel.UsrSbnome = data[0].UsrSbnome;
            usrcel.UsrEmail = data[0].UsrEmail;

            foreach (UserCelsModel user in data)
            {
                cels.Add(new CelsModel
                {
                    CelDdd = user.UsrCel.CelDdd,
                    CelNum = user.UsrCel.CelNum
                });

                usrcel.UsrCels = cels;
            }

            string json = JsonConvert.SerializeObject(usrcel);

            Console.WriteLine(json);
        
        }
    }
}
