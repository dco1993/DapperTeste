using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTeste.Model
{
    public class UsrCel
    {
        public string UsrNome { get; set; }
        public string UsrSbnome { get; set; }
        public string UsrEmail { get; set; }
        public List<CelsModel> UsrCels { get; set; }
    }
}
