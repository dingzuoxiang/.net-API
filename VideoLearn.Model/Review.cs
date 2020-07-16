using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLearn.Model
{
    public class Review
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ResourceId { get; set; }
        public string Comment { get; set; }
        public Double Grade { get; set; }
        public DateTime Time { get; set; }
    }
}
