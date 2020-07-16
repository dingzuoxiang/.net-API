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
    public class ReviewController : ApiController
    {
        private readonly ReviewRepository reviewRepository = new ReviewRepository();
        // GET: api/Review
        public HttpResponseMessage Get(int resourceId,int pageIndex)
        {
            IEnumerable<dynamic> reviewList = reviewRepository.GetReviewById(resourceId,pageIndex);
            IEnumerable<dynamic> dynamics = reviewRepository.GetAVGGrade(resourceId);
            int totalCount = reviewRepository.GetCount(resourceId);
            var data = ReviewToJsonRepository.GetData(reviewList, totalCount,dynamics);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(data);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.UTF8, "application/json") };
        }

        // POST: api/Review
        [HttpPost]
        public bool PostReview([FromBody]Review review)
        {
            int flag = reviewRepository.AddReview(review);
            if (flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // PUT: api/Review/5
        public void Put(Review review)
        {
            reviewRepository.UpdateReview(review);
        }

        // DELETE: api/Review/5
        public void Delete(int uid, int rid, DateTime time)
        {
            reviewRepository.DeleteReview(uid, rid, time);
        }
    }
}