/******************************************************************************
* Filename    = UnitTests.cs
*
* Author      = Mangesh Dalvi
*
* Product     = ProxyDesignPatterns
* 
* Project     = UnitTests
*
* Description = Unit tests for the proxy pattern demo.
*****************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tests
{
    /// <summary>
    /// Total 6 tests cases added.
    /// </summary>

    [TestClass]
    public class UnitTests
    {

        /// <summary>
        /// Test for a successful connection through the gate.
        /// </summary
        [TestMethod]
        public void PassedThroughGate()
        {

            Gate connection = new();
            Status response;

            response = connection.Connect("mMPDpLPpP");

            Assert.AreEqual(200, response._code);
        }

        /// <summary>
        /// Test for a failed connection attempt through the gate.
        /// </summary>
        [TestMethod]
        public void FailedThroughGate()
        {

            Gate connection = new();
            Status response;

            response = connection.Connect("sfJdMPd");

            Assert.AreEqual(404, response._code);
        }

        /// <summary>
        /// Test for sending data through a successful connection.
        /// </summary>
        [TestMethod]
        public void SendingData()
        {
            Gate connection = new();

            connection.Connect("mMPDpLPpP");

            connection.Send("AAA");

            Status status = connection.Get();
            string data = status._data;

            connection.Disconnect();

            Assert.AreEqual(data, "AAA ");
        }

        /// <summary>
        /// Test for sending multiple sets of data through a successful connection.
        /// </summary>
        [TestMethod]
        public void SendingMultipleData()
        {
            Gate connection = new();

            connection.Connect("mMPDpLPpP");

            connection.Send("AAA");
            connection.Send("BBB");
            connection.Send("CCC");

            Status status = connection.Get();
            string data = status._data;

            connection.Disconnect();

            Assert.AreEqual(data, "AAA BBB CCC ");
        }

        /// <summary>
        /// Test for keeping data alive after disconnecting and reconnecting.
        /// </summary>
        [TestMethod]
        public void KeepingDataAlive()
        {
            Gate connection = new();

            connection.Connect("mMPDpLPpP");

            connection.Send("AAA");

            connection.Disconnect();

            Status status = connection.Get();

            if (status._code != 404)
            {
                Assert.Fail();
            }

            connection.Connect("mMPDpLPpP");
            status = connection.Get();
            string data = status._data;
            Assert.AreEqual(data, "AAA ");

        }

        /// <summary>
        /// Test for authentication requirements.
        /// </summary>
        [TestMethod]
        public void AuthenticationIsNeeded()
        {
            Gate connection = new();

            Status status = connection.Disconnect();

            if (status._code == 200)
            {
                Assert.Fail();
            }

            status = connection.Get();

            if (status._code == 200)
            {
                Assert.Fail();
            }

            status = connection.Send("AAA");

            if (status._code == 200)
            {
                Assert.Fail();
            }

            connection.Connect("mMPDpLPpP");

            status = connection.Disconnect();

            Assert.AreEqual(200, status._code);

        }

    }
}
