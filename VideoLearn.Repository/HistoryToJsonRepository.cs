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
    public class HistoryToJsonRepository
    {
        public static dynamic GetData(IEnumerable<dynamic> result)
        {
            List<History> historyList = new List<History>();
            foreach (dynamic item in result)
            {
                History history = new History();
                history.UserId = item.UserId;
                history.ResourceId = item.ResourceId;
                history.Time = item.Time;
                history.Rate = item.Rate;
                historyList.Add(history);
            }


            var data = new
            {
                list = historyList,
                totalListCount = result.Count()
            };
            return data;
        }
    }
}
