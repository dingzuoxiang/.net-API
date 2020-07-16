using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLearn.Repository
{
    class Common
    {
        public static MySqlConnection GetMySqlConnection()
        {
            string conString = "Server = localhost ; Database = basedate ; Uid = root ; Pwd = password";
            return new MySqlConnection(conString);
        }
    }
}
