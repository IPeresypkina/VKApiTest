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
        
        [Test]
        public void ClientConnectedToServerAndReceiveMessage() //подключение клиента и получение сообщений
        {
            //Делает запрос к созданию универсальному идентификатору ресурса (URI)
            WebRequest request = WebRequest.Create("http://localhost:8080/");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse(); //есть ли ответ с сервера
            Stream stream = response.GetResponseStream(); //получмть поток вывода клиенту который присоеденился 
            StreamReader reader = new StreamReader(stream); //прочитать ответ с сервера
            string responseFromServer = reader.ReadToEnd();
            Assert.AreEqual("\"Hello, world!\"",responseFromServer);
            stream.Close();
            response.Close();
        }
    }
}