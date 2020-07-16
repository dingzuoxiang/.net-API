using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLearn.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<dynamic> getAll();
        dynamic getById(int id);
        void delete(int id);
        void update(T t);
        void add(T t);
    }
}
