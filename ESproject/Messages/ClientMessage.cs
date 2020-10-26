using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESproject.Messages
{
    public class ClientMessage
    {
        public string action;
        public Dictionary<string, string> message = new Dictionary<string, string>();

    }
}
