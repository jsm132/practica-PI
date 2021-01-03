using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.User
{
    class key
    {
        public string backup;
        public string value;
        public List<string> sharedWith;

        public key(string backup, string value, List<string> list)
        {
            this.backup = backup;
            this.value = value;
            this.sharedWith = list;
        }
    }
}
