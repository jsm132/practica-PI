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
        public string activated2FA;
        public string telegramUser;

        public User(string mail, string password, string activated2FA, string telegramUser)
        {
            this.mail = mail;
            this.password = password;
            this.activated2FA = activated2FA;
            this.telegramUser = telegramUser;
        }

        public void modify2FA(string telegramUser)
        {
            this.activated2FA = "YES";
            this.telegramUser = telegramUser;
        }
    }
}
