using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using VideoLearn.Model;
using VideoLearn.Repository;
using VideoLearn.Repository.Implementations;

namespace VideoLearnWebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserRepository userRepository = new UserRepository();
        // GET: api/User
        public HttpResponseMessage Get()
        {
            IEnumerable<dynamic> userList = userRepository.GetAllUser();
            var date = UserToJsonRepository.ToJson(userList);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(date);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.UTF8, "application/json") };
        }
        [HttpGet]
        public User Login(string loginname,string password)
        {
            if(loginname == null||password == null)
            {
                throw new Exception("用户名或密码不能为空!");
            }
            IEnumerable<dynamic> flag = userRepository.LoginCheck(loginname,password);
            User user = UserToJsonRepository.ToUser(flag);
            if(user != null)
            {
                HttpContext.Current.Session.Add("User", user);
                return (User)HttpContext.Current.Session["User"];
            }
            else
            {
                throw new Exception("用户不存在!");
            }
        }
        [HttpGet]
        public string Check(string loginname)
        {
            int flag = userRepository.SearchLoginName(loginname);
            if(flag == 1)
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }

        // POST: api/User
        [HttpPost]
        public string Register([FromBody]User user)
        {
            int flag = userRepository.AddUser(user);
            if(flag == 1)
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }

        // PUT: api/User/5
        public void Put(User user)
        {
            userRepository.UpdateUser(user);
        }

        // DELETE: api/User/5
        public bool Delete(int id)
        {
            int flag = userRepository.DeleteUser(id);
            if(flag == 1)
            {
                return true;
            }
            return false;
        }
    }
}