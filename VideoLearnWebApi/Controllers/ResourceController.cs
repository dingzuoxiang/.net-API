using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web;
using System.Web.Script.Serialization;
using VideoLearn.Model;
using VideoLearn.Repository;
using VideoLearn.Repository.Implementations;

namespace VideoLearnWebApi.Controllers
{
    public class ResourceController : ApiController
    {
        private readonly ResourceRepository resourceRepository = new ResourceRepository();
        // GET: api/Resource

        public HttpResponseMessage Get(string sort)
        {
            IEnumerable<dynamic> resourceList = resourceRepository.GetBySort(sort);
            var data = ResourceToJsonRepository.GetData(resourceList, resourceList.Count());
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(data);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.UTF8, "application/json") };
        }

        public HttpResponseMessage Get(string sort,int pageIndex)
        {
            int totalCount = resourceRepository.GetCount(sort);
            IEnumerable<dynamic> resourceList = resourceRepository.PaginationBySort(sort, pageIndex);
            var data = ResourceToJsonRepository.GetData(resourceList,totalCount);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(data);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.UTF8, "application/json") };
        }

        public HttpResponseMessage Get(int videoId)
        {
            resourceRepository.UpdateClick(videoId);
            resourceRepository.UpdateAverage();
            IEnumerable<dynamic> dynamics = resourceRepository.GetResourceById(videoId);
            Resource data = ResourceToJsonRepository.ToList(dynamics);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(data);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.UTF8, "application/json") };
        }

        public HttpResponseMessage Get(int resourceId,string sort,int count)
        {
            IEnumerable<dynamic> resourceList = resourceRepository.GetResourceByIdAndSortAndCount(resourceId, sort, count);
            var data = ResourceToJsonRepository.GetData(resourceList, count);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(data);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.UTF8, "application/json") };
        }

        // POST: api/Resource
        [HttpPost]
        public bool PostResource([FromBody]Resource resource)
        {
            int flag = resourceRepository.AddResource(resource);
            if(flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // DELETE: api/Resource/5
        public bool Delete(int id)
        {
            int flag = resourceRepository.DeleteResource(id);
            if(flag == 1)
            {
                return true;
            }
            return false;
        }
    }
}