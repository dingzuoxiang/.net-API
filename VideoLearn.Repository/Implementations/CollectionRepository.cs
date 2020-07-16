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
    public class CollectionRepository
    {
        public void add(Collection collection)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("insert into collection value(@UserId, @ResourceId, @PictureRoute, @Time)", new { collection });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
        }

        public void delete(int uid, int rid)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("delete from collection where UserId = @UserId , ResourceId = @ResourceId", new { UserId = uid, ResourceId = rid });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
        }

        public IEnumerable<dynamic> getAll(int id)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> collections = client.Query("select * from collection where UserId = @UserId order by Time desc", new { UserId = id });
            return collections;
        }

        public dynamic getById(int uid, int rid)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            dynamic result = client.Query("select * from collection where UserId = @UserId and ResourceId = @ResourceId ", new { UserId = uid, ResourceId = rid });
            return result;
        }
    }
}
