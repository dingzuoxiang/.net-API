using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLearn.Model
{
    public class Resource
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime UpTime { get; set; }
        public string Title { get; set; }
        public string Sort { get; set; }
        public Double Average { get; set; }
        public string Route { get; set; }
        public string Picture { get; set; }
        public int Clicks { get; set; }
        public int Sign { get; set; }
    }
}
