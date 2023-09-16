using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    /// <summary>
    /// Represents the status of an operation, including an HTTP status code and optional data.
    /// </summary>
    public class Status
    {
        public string _data;
        public int _code;

        /// <summary>
        /// Initializes a new instance of the Status class with a code and optional data.
        /// </summary>
        /// <param name="code">The HTTP status code indicating the result of an operation.</param>
        /// <param name="data">The data associated with the status (optional).</param>
        public Status(int code, string data) 
        {
            _data = data;
            _code = code;
        }

        /// <summary>
        /// Initializes a new instance of the Status class with a code and no data.
        /// </summary>
        /// <param name="code">The HTTP status code indicating the result of an operation.</param>
        public Status(int code)
        {
            _data = "";
            _code = code;
        }

    }
}