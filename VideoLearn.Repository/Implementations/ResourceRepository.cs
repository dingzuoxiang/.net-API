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
    public class ResourceRepository
    {
        public int AddResource(Resource resource)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            dynamic result = client.Query("select * from resource where Title = @Title", new { Title = resource.Title });
            Resource r = new Resource();
            foreach (dynamic item in result)
            {
                r.Title = item.Title;
            }
            if (r.Title == null)
            {
                var affectedRows = client.Execute("insert into resource value(0 , @Author , @UpTime , @Title , @Sort , @Average , @Route , @Picture , 0 , 1)", new { Author = resource.Author, UpTime = resource.UpTime, Title = resource.Title, Sort = resource.Sort, Average = resource.Average, Route = resource.Route, Picture = resource.Picture });
                if (affectedRows != 1)
                {
                    throw new Exception("BUG!!!!!!!");
                }
                else
                {
                    return affectedRows;
                }
            }
            else
            {
                return 0;
            }
        }

        public int DeleteResource(int id)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            var affectedRows = client.Execute("delete from resource where Id = @Id", new { Id = id });
            if (affectedRows != 1)
            {
                throw new Exception("BUG!!!!!!!");
            }
            return affectedRows;
        }

        public int GetCount(string sort)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> result = client.Query("select * from resource where Sort = @Sort",new { Sort = sort});
            return result.Count();
        }

        public IEnumerable<dynamic> PaginationBySort(string sort,int page)
        {
            int pagination = (page - 1) * 6;
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> resource = client.Query("select * from resource where Sort = @Sort order by UpTime desc limit @Pagination,6", new { Sort = sort , Pagination = pagination });
            return resource;
        }

        public IEnumerable<dynamic> GetResourceByIdAndSortAndCount(int resourceId,string sort, int count)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> resource = client.Query("select * from resource where Sort = @Sort and Id != @Id order by UpTime desc limit @Count", new { Sort = sort, Id = resourceId , Count = count });
            return resource;
        }

        public IEnumerable<dynamic> GetBySort(string sort)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> resource = client.Query("select * from resource where Sort = @Sort order by UpTime desc",new { Sort = sort });
            return resource;
        }

        public IEnumerable<dynamic> GetResourceById(int resourceId)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> resource = client.Query("select * from resource where Id = @Id order by UpTime desc", new { Id = resourceId });
            return resource;
        }

        public IEnumerable<dynamic> QueryResource(string data,int pageIndex)
        {
            int pagination = (pageIndex - 1) * 6;
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> resource = client.Query("select * from resource where Title like '%"+data+"%' or Sort like '%"+data+"%' or Author like '%"+data+"%' order by UpTime desc limit @Pagination,6",new { Pagination = pagination });
            return resource;
        }

        public int GetQueryCount(string data)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            IEnumerable<dynamic> dynamics = client.Query("select * from resource where Title like '%" + data + "%' or Sort like '%" + data + "%' or Author like '%" + data + "%' order by UpTime desc");
            return dynamics.Count();
        }

        public void UpdateClick(int resourceId)
        {
            MySqlConnection client = Common.GetMySqlConnection();
            client.Execute("update resource set Clicks = Clicks + 1 where Id = @Id", new { Id = resourceId });
        }

        public void UpdateAverage()
        {
            MySqlConnection client = Common.GetMySqlConnection();
            client.Execute("UPDATE resource SET Average = (SELECT ROUND(AVG(Grade),1) FROM review WHERE review.ResourceId = resource.Id)");
        }
    }
}
