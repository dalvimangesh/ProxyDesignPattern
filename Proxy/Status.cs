using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Status
    {
        public string _data;
        public int _code;

        public Status(int code, string data) 
        {
            _data = data;
            _code = code;
        }

        public Status(int code)
        {
            _data = "";
            _code = code;
        }

    }
}