using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using VideoLearn.Repository;
using VideoLearn.Repository.Implementations;

namespace VideoLearnWebApi.Controllers
{
    public class QueryController : ApiController
    {
        private readonly ResourceRepository resourceRepository = new ResourceRepository();
        // GET: api/Query
        public HttpResponseMessage Get(string data,int pageIndex)
        {
            int totalCount = resourceRepository.GetQueryCount(data);
            IEnumerable<dynamic> resourceList = resourceRepository.QueryResource(data,pageIndex);
            var result = ResourceToJsonRepository.GetData(resourceList,totalCount);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(result);
            return new HttpResponseMessage { Content = new StringContent(str, Encoding.UTF8, "application/json") };
        }
    }
}
