using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLearn.Model
{
    public class History
    {
        public int UserId { get; set; }
        public int ResourceId { get; set; }
        public DateTime Time { get; set; }
        public Double Rate { get; set; }
    }
}
