using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using VideoLearn.Model;

namespace VideoLearn.Repository
{
    public class ResourceToJsonRepository
    {
        public static System.IO.MemoryStream ms = new System.IO.MemoryStream();
        public static dynamic GetData(IEnumerable<dynamic> result,int totalCount)
        {
            List<Resource> resourcelist = new List<Resource>();
            foreach (dynamic item in result)
            {
                Resource resource = new Resource();
                resource.Id = item.Id;
                resource.Author = item.Author;
                resource.UpTime = item.UpTime;
                resource.UpTime.ToString();
                resource.Title = item.Title;
                resource.Sort = item.Sort;
                if (item.Average == null)
                {
                    resource.Average = 0;
                }
                else
                {
                    resource.Average = item.Average;
                }
                byte[] blob = (byte[])item.Route;
                string str = System.Text.Encoding.UTF8.GetString(blob, 0, blob.Length);
                resource.Route = str;
                byte[] blob1 = (byte[])item.Picture;
                string str1 = System.Text.Encoding.UTF8.GetString(blob1, 0, blob1.Length);
                resource.Picture = str1;
                resource.Clicks = item.Clicks;
                resource.Sign = item.Sign;
                resourcelist.Add(resource);
            }

            var data = new
            {
                list = resourcelist,
                totalListCount = totalCount
            };

            return data;
        }
        public static dynamic ToList(IEnumerable<dynamic> dynamics)
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            Resource resource = new Resource();
            foreach (dynamic item in dynamics)
            {
                
                resource.Id = item.Id;
                resource.Author = item.Author;
                resource.UpTime = item.UpTime;
                resource.UpTime.ToString();
                resource.Title = item.Title;
                resource.Sort = item.Sort;
                if(item.Average == null)
                {
                    resource.Average = 0;
                }
                else
                {
                    resource.Average = item.Average;
                }
                byte[] blob = (byte[])item.Route;
                string str = System.Text.Encoding.UTF8.GetString(blob,0,blob.Length);
                resource.Route = str;
                byte[] blob1 = (byte[])item.Picture;
                string str1 = System.Text.Encoding.UTF8.GetString(blob1, 0, blob1.Length);
                resource.Picture = str1;
                resource.Clicks = item.Clicks;
                resource.Sign = item.Sign;
            }

            return resource;
        }
    }
}
