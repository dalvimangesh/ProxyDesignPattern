using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    /// <summary>
    /// Represents a gate that acts as a proxy for a server with authentication.
    /// </summary>
    public class Gate : IServer
    {

        private bool _isAuthenticated;
        private readonly string _secret;
        private readonly Server _server;

        /// <summary>
        /// Initializes a new instance of the Gate class.
        /// </summary>
        public Gate() 
        {
            _isAuthenticated = false;
            _secret = "mMPDpLPpP";
            _server = new Server();
        }

        /// <summary>
        /// Establishes a connection to the server with the provided API key.
        /// </summary>
        /// <param name="APIKey">The API key for authentication.</param>
        /// <returns>A Status object indicating the result of the connection attempt.</returns>
        public Status Connect(string APIKey)
        {

            if (!_isAuthenticated && Authenticate(APIKey))
            {
                _isAuthenticated = true;
                return _server.Connect(APIKey);
            }

            return new Status(404);
        }

        /// <summary>
        /// Sends data to the server if authenticated.
        /// </summary>
        /// <param name="data">The data to send to the server.</param>
        /// <returns>A Status object indicating the result of the data transmission.</returns>
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

        /// <summary>
        /// Retrieves data from the server if authenticated.
        /// </summary>
        /// <returns>A Status object containing the retrieved data or an error status.</returns>
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

        /// <summary>
        /// Disconnects from the server if authenticated.
        /// </summary>
        /// <returns>A Status object indicating the result of the disconnection.</returns>
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