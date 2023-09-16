/******************************************************************************
* Filename    = IServer.cs
*
* Author      = Mangesh Dalvi
*
* Product     = ProxyDesignPattern
* 
* Project     = Proxy
*
* Description = Defines the contract for a server interface that can be implemented by server classes.
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    /// <summary>
    /// Defines the contract for a server interface that can be implemented by server classes.
    /// </summary>
    public interface IServer
    {
        /// <summary>
        /// Sends data to the server.
        /// </summary>
        /// <param name="data">The data to send to the server</param>
        /// <returns>A Status object indicating the result of the data transmission</returns>
        Status Send(string data);

        /// <summary>
        /// Establishes a connection to the server with the provided API key.
        /// </summary>
        /// <param name="APIKey">The API key for authentication.</param>
        /// <returns>A Status object indicating the result of the connection attempt</returns>
        Status Connect(string APIKey);

        /// <summary>
        /// Retrieves data from the server.
        /// </summary>
        /// <returns>A Status object containing the retrieved data or an error status</returns>
        Status Get();

        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        /// <returns>A Status object indicating the result of the disconnection</returns>
        Status Disconnect();
    }
}