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
    public class ReviewRepository
    {
        public int AddReview(Review review)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("insert into review value(@UserId , @UserName  , @ResourceId , @Comment  , @Grade , @Time)", new { UserId = review.UserId , UserName = review.UserName  , ResourceId = review.ResourceId , Comment = review.Comment , Grade = review.Grade , Time = review.Time });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
            return affectedRows;
        }

        public void DeleteReview(int uid, int rid, DateTime time)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("delete from review where UserId = @UserId and ResourceId = @ResourceId and Time = @Time", new { UserId = uid, ResourceId = rid, Time = time });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
        }

        public IEnumerable<dynamic> GetReviewById(int typeid,int page)
        {
            int pagination = (page - 1)*6;
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> result = client.Query("select * from review where ResourceId = @ResourceId order by Time desc limit @Pagination,6",new { ResourceId = typeid , Pagination = pagination });
            return result;
        }

        public IEnumerable<dynamic> GetAVGGrade(int typeid)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> result = client.Query("SELECT ROUND(AVG(Grade),1) as Average FROM review WHERE ResourceId = @ResourceId", new { ResourceId = typeid });
            client.Execute("UPDATE resource SET Average = (SELECT ROUND(AVG(Grade),1) FROM review WHERE review.ResourceId = resource.Id)");
            return result;
        }

        public void UpdateReview(Review review)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("update review set Comment = @Comment where UserId = @UserId and ResourceId = @ResourceId and Tiem = @Time", new { Comment = review.Comment, UserId = review.UserId, ResourceId = review.ResourceId, Time = review.Time });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
        }
        public int GetCount(int resourceId)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> reviewList = client.Query("select * from review where ResourceId = @ResourceId",new { ResourceId = resourceId});
            int totalCount = reviewList.Count();
            return totalCount;
        }
    }
}
