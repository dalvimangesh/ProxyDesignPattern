using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Gate : IServer
    {

        private bool _isAuthenticated;
        private readonly string _secret;
        private readonly Server _server;

        public Gate() 
        {
            _isAuthenticated = false;
            _secret = "mMPDpLPpP";
            _server = new Server();
        }

        public Status Connect(string APIKey)
        {

            if (!_isAuthenticated && Authenticate(APIKey))
            {
                _isAuthenticated = true;
                return _server.Connect(APIKey);
            }

            return new Status(404);
        }

        public Status Send(string data)
        {
            if(_isAuthenticated)
            {
                try
                {
                    return _server.Send(data);
                }
                catch
                {
                    return new Status(500);
                }
            }

            return new Status(404);
        }

        public Status Get()
        {
            if (_isAuthenticated)
            {
                try
                {
                    return _server.Get();
                }
                catch
                {
                    return new Status(404);
                }
            }

            return new Status(404);
        }

        public Status Disconnect()
        {
            if (_isAuthenticated)
            {
                _isAuthenticated = false;
                return _server.Disconnect();
            }

            return new Status(404);
        }

        private bool Authenticate(string APIKey)
        {
            if( _secret == APIKey ) 
            {
                return true;
            }

            return false;
        }
    }
}