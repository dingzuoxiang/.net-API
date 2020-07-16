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
    public class ReviewToJsonRepository
    {
        public static dynamic GetData(IEnumerable<dynamic> result,int totalCount,IEnumerable<dynamic> dynamics)
        {
            List<Review> reviewList = new List<Review>();
            Double ave = 0;
            foreach (dynamic item in result)
            {
                Review review = new Review();
                review.UserId = item.UserId;
                review.UserName = item.UserName;
                review.ResourceId = item.ResourceId;
                review.Comment = item.Comment;
                review.Grade = item.Grade;
                review.Time = item.Time;
                reviewList.Add(review);
            }
            foreach(dynamic i in dynamics)
            {
                if(i.Average == null)
                {
                    ave = 0;
                }
                else
                {
                    ave = i.Average;
                }
            }

            var data = new
            {
                list = reviewList,
                totalListCount = totalCount,
                average = ave
            };
            return data;
        }
    }
}
