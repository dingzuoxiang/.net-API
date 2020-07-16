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
    public class HistoryRepository
    {
        public void add(History history)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("insert into history value(@UserId, @ResourceId, @Time ,@Rate)", new { history });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
        }

        public void delete(int uid, int rid)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("delete from history where UserId = @UserId and ResourceId = @ResourceId", new { UserId = uid, ResourceId = rid });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
        }

        public IEnumerable<dynamic> getAll(int id)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> historyList = client.Query("select * from history where UserId = @UserId order by Time desc", new { UserId = id });
            return historyList;
        }

        public dynamic getById(int uid, int rid)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            dynamic result = client.Query("select * from history where UserId = @UserId and ResourceId = @ResourceId ", new { UserId = uid, ResourceId = rid });
            return result;
        }

        public void update(History history)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("update history set Time = @Time , Rate = @Rate where UserId = @UserId and ResourceId = @ResourceId", new { Time = history.Time, Rate = history.Rate, UserId = history.UserId, ResourceId = history.ResourceId });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
        }
    }
}
