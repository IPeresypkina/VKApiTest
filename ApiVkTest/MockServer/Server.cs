using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ApiVkTest.Model;

namespace MockServer
{
    public class Server
    {
        static void Main(string[] args)
        {
            Listen();
        }

        private static void Listen()
        {
            HttpListener listener = new HttpListener();
            // установка адресов прослушки
            listener.Prefixes.Add("http://localhost:8888/connection/");
            listener.Prefixes.Add("http://localhost:8888/");
            
            listener.Start();
            Console.WriteLine("Ожидание подключений...");

            while (true)
            {
                //Ожидает входящий запрос и возвращается после его получения. 
                HttpListenerContext context =  listener.GetContext();
                //Получает запрос HttpListenerRequest, представляющий запрос клиента на ресурс
                HttpListenerRequest request = context.Request;
                // получаем объект ответа
                HttpListenerResponse response = context.Response;

               ProcessRequest(request.Url.AbsolutePath, response);
            }
        }

        private static void SendMessageToClient(object message, HttpListenerResponse response)
        { 
            byte[] buffer = ConvertMessageToBytes(message);

            // получаем поток ответа и пишем в него ответ
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        private static byte[] ConvertMessageToBytes(object message)
        {
            string json = JsonConvert.SerializeObject(message);
            return System.Text.Encoding.UTF8.GetBytes(json);
        }

        private static void ProcessRequest(string request, HttpListenerResponse response)
        {
            switch (request) //выбирает ответ
            {
                case "/test":
                    string text = "Hello, world!";
                    SendMessageToClient(text, response);
                    break;
                case "/method/users/get/7438294":
                    User user = new User()
                    {
                        id = "7438294",
                        first_name = "Ирина",
                        last_name = "Пересыпкина",
                        is_closed = false
                    };
                    SendMessageToClient(user,response);
                    break;
            }
        }
    }
}