using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLearn.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Mailbox { get; set; }
        public DateTime RegTime { get; set; }
        public int Sign { get; set; }
        public int Permission { get; set; }
    }
}
