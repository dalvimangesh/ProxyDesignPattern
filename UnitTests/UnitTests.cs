using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void PassedThroughGate()
        {

            Gate connection = new();
            Status response;

            response = connection.Connect("mMPDpLPpP");

            Assert.AreEqual(200, response._code);
        }

        [TestMethod]
        public void FailedThroughGate()
        {

            Gate connection = new();
            Status response;

            response = connection.Connect("sfJdMPd");

            Assert.AreEqual(404, response._code);
        }

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

            status = connection.Connect("mMPDpLPpP");

            status = connection.Disconnect();

            Assert.AreEqual(200, status._code);

        }

    }
}