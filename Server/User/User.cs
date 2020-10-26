using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.User
{
    public class User
    {
        public string mail;
        public string password;

        public User(string mail, string password)
        {
            this.mail = mail;
            this.password = password;
        }
    }
}
