using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLearn.Model
{
    public class Collection
    {
        public int UserId { get; set; }
        public int ResourceId { get; set; }
        public string PictureRoute { get; set; }
        public DateTime Time { get; set; }
    }
}
