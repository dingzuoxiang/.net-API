using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using VideoLearn.Model;

namespace VideoLearn.Repository
{
    public class UserToJsonRepository
    {
        public static dynamic ToJson(IEnumerable<dynamic> result)
        {
            List<User> userList = new List<User>();
            foreach(dynamic item in result)
            {
                User user = new User();
                user.Id = item.Id;
                user.Name = item.Name;
                user.LoginName = item.LoginName;
                user.Password = item.Password;
                user.Mailbox = item.Mailbox;
                user.RegTime = item.RegTime;
                user.Sign = item.Sign;
                user.Permission = item.Permission;
                userList.Add(user);
            }

            var date = new
            {
                list = userList,
                totalListCount = result.Count()
            };
            return date;
        }
        public static User ToUser(IEnumerable<dynamic> dynamics)
        {
            User user = new User();
            foreach(dynamic item in dynamics) { 
                user.Id = item.Id;
                user.Name = item.Name;
                user.LoginName = item.LoginName;
                user.Password = item.Password;
                user.Mailbox = item.Mailbox;
                user.RegTime = item.RegTime;
                user.Sign = item.Sign;
                user.Permission = item.Permission;
            }
            return user;
        }
    }
}
