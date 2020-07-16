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
    public class HistoryController : ApiController
    {
        private readonly HistoryRepository historyRepository = new HistoryRepository();

        // GET: api/History
        public HttpResponseMessage Get(int id)
        {
            IEnumerable<dynamic> historyList = historyRepository.getAll(id);
            var data = HistoryToJsonRepository.GetData(historyList);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(data);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.UTF8, "application/json") };
        }

        // POST AND PUT: api/History
        public void PostAndPut(History history)
        {
            dynamic result = historyRepository.getById(history.UserId, history.ResourceId);
            if (result != null)
            {
                historyRepository.update(history);
            }
            else
            {
                historyRepository.add(history);
            }
        }

        // DELETE: api/History/5
        public void Delete(int uid, int rid)
        {
            historyRepository.delete(uid, rid);
        }
    }
}