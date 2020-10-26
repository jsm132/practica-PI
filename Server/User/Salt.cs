using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.User
{
    class Salt
    {
        public string mail;
        public string salt;
        public Salt(string mail, string salt)
        {
            this.mail = mail;
            this.salt = salt;
        }
    }
}
