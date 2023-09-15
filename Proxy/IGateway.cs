using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IGateway
    {
        Status Connect(string APIKey);
        Status Send(string data);
        Status Get();
        Status Disconnect();
    }
}
