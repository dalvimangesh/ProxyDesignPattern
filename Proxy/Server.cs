using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Server : IServer
    {

        private string _data;
        public Server() 
        {
            _data = "";
        }

        public Status Send(string data)
        {
            _data += data;
            _data += " ";
            return new Status(200);
        }
        public Status Get()
        {
            return new Status(200,_data);
        }

    }
}
