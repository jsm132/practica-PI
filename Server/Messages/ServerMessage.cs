using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Messages
{
    class ServerMessage
    {
        public string action;
        public Dictionary<string, string> message = new Dictionary<string, string>();
    }
}
