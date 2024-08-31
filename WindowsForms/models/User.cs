using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsForms.models
{
    class User
    {
        public Int32 id { get; set; }
        public string login { get; set; }
        public Role Role { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
    }
}
