using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MockServer.Tests
{
    public class MocTest
    {
        [Test]
        public void ServerCreated() //проверка целостности и качества соединений в сети
        {
            var ping = new Ping();
            var reply = ping.Send(new IPAddress(new byte[]{127,0,0,1}), 3000);
            Assert.AreEqual(reply.Status, IPStatus.Success);
        }
    }
}