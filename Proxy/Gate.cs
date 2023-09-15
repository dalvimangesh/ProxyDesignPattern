using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Gate : IGateway
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
                return new Status(200);
            }

            return new Status(404);
        }

        public Status Send(string data)
        {
            if(_isAuthenticated)
            {
                try
                {
                    _server.Send(data);
                    return new Status(200);
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
                return new Status(200);
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