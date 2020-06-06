using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [Serializable()]
    public class Messages
    {
        public string action;
        public User user = null;
        public string text = "";
        public string Uname = "";
        public string fileName = "";
        public byte[] data;
    }
}
