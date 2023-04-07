using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrostructure.Infrostructure
{
    public class ConnectionClass
    {
        public required string ConnectionString { get; set; }

    }

    public class GetConnection
    {
        private readonly static string path = @"..\..\..\..\..\KitobDokon\Infrostructure\Infrostructure\Coonection.json";
       
        public static string Connection()
        {
            return JsonConvert.DeserializeObject<ConnectionClass>(File.ReadAllText(path)).ConnectionString;
        }

    }
}
