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
    public class CollectionController : ApiController
    {
        private readonly CollectionRepository collectionRepository = new CollectionRepository();

        // GET: api/Collection
        public HttpResponseMessage Get(int id)
        {
            IEnumerable<dynamic> collectionList = collectionRepository.getAll(id);
            var result = CollectionToJsonRepository.GetData(collectionList);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(result);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.UTF8, "application/json") };
        }

        // POST: api/Collection
        public void Post(Collection collection)
        {
            dynamic result = collectionRepository.getById(collection.UserId, collection.ResourceId);
            if (result == null)
            {
                collectionRepository.add(collection);
            }
        }

        // DELETE: api/Collection/5
        public void Delete(int uid, int rid)
        {
            collectionRepository.delete(uid, rid);
        }
    }
}