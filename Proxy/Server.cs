/******************************************************************************
* Filename    = Gate.cs
*
* Author      = Mangesh Dalvi
*
* Product     = ProxyDesignPatterns
* 
* Project     = Proxy
*
* Description =  Represents a Real server 
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    /// <summary>
    /// Represents a Real server 
    /// </summary>
    public class Server : IServer
    {

        private string _data;

        /// <summary>
        /// Initializes a new instance of the Server 
        /// </summary>
        public Server() 
        {
            _data = "";
        }

        /// <summary>
        /// Simulates a connection to the server.
        /// </summary>
        public Status Connect(string APIKey)
        {
            return new Status(200);
        }

        /// <summary>
        /// Simulates sending data to the server.
        /// </summary>
        public Status Send(string data)
        {
            _data += data;
            _data += " ";
            return new Status(200);
        }

        /// <summary>
        /// Retrieving data from the server.
        /// </summary>
        public Status Get()
        {
            return new Status(200,_data);
        }

        /// <summary>
        /// Disconnecting from the server.
        /// </summary>
        public Status Disconnect()
        {
            return new Status(200);
        }

    }
}
