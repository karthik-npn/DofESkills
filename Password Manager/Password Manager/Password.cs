using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager
{
    public class Password
    {
        public string Website { get; set; }

        [DisplayName("User")]
        public string Username { get; set; }

        [DisplayName("Password")]
        public string Pwd { get;set; }
        public string Notes { get; set; }
    }
}
