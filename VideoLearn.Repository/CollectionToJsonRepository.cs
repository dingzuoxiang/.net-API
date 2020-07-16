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
    public class CollectionToJsonRepository
    {
        public static dynamic GetData(IEnumerable<dynamic> result)
        {
            List<Collection> collectionList = new List<Collection>();
            foreach (dynamic item in result)
            {
                Collection collection = new Collection();
                collection.UserId = item.UserId;
                collection.ResourceId = item.ResourceId;
                collection.PictureRoute = item.PictureRoute;
                collection.Time = item.Time;
                collectionList.Add(collection);
            }


            var data = new
            {
                list = collectionList,
                totalListCount = result.Count()
            };
            return data;
        }
    }
}
