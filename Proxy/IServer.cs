using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IServer
    {
        Status Send(string data);

        Status Connect(string APIKey);

        Status Get();

        Status Disconnect();
    }
}