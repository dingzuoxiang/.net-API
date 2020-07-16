using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLearn.Model;

namespace VideoLearn.Repository.Implementations
{
    public class UserRepository
    {
        public int AddUser(User user)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            dynamic result = client.Query("select * from user where LoginName = @LoginName", new { LoginName = user.LoginName });
            User u = new User();
            foreach (dynamic item in result)
            {
                u.LoginName = item.LoginName;
            }
            if (u.LoginName == null)
            {
                var affectedRows = client.Execute("insert into user value(0 , @Name , @LoginName  , @Password , @Mailbox , @RegTime , 1 , 0)", new { Name = user.Name, LoginName = user.LoginName, Password = user.Password, Mailbox = user.Mailbox, RegTime = user.RegTime });
                if (affectedRows != 1)
                {
                    throw new Exception("BUG!!!!!!!");
                }
                else
                {
                    return affectedRows;
                }
            }
            else
            {
                return 0;
            }
        }

        public int SearchLoginName(string loginname)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            dynamic dynamic = client.Query("select * from user where LoginName = @LoginName", new { LoginName = loginname });
            User user = new User();
            foreach(dynamic item in dynamic)
            {
                user.LoginName = item.LoginName;
            }
            if (user.LoginName == null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int DeleteUser(int id)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("delete from user where Id = @Id", new { Id = id });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
            return affectedRows;
        }

        public IEnumerable<dynamic> GetAllUser()
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> data = client.Query("select * from user where Sign = 1");
            return data;
        }

        public dynamic LoginCheck(string loginname,string password)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> result = client.Query("select * from user where LoginName = @LoginName and Password = @Password and Sign = 1 ", new { LoginName = loginname , Password = password});
            return result;
        }

        public void UpdateUser(User user)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("update user set Name = @Name and Password = @Password where Id = @Id", new { Name = user.Name, Password = user.Password, Id = user.Id });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
        }
    }
}
