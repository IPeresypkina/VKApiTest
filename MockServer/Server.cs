using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using MockServer.Models;
using Newtonsoft.Json;

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
            listener.Prefixes.Add("http://localhost:8080/connection/");
            listener.Prefixes.Add("http://localhost:8080/");
            
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

               ProcessRequest(request.Url.PathAndQuery, response);
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
                    //http://localhost:8080/method/users.get?users_ids=86031446&access_token=f9ec652d9ad60f44ad77ae7b2533583702978c976c77dff5de9efad7d53056e23ec1010ed7d7b32ba25ce&v=5.103
                case "/method/users.get?users_ids=86031446&access_token=f9ec652d9ad60f44ad77ae7b2533583702978c976c77dff5de9efad7d53056e23ec1010ed7d7b32ba25ce&v=5.103":
                    User user = new User()
                    {
                        id = "86031446",
                        first_name = "Ирина",
                        last_name = "Пересыпкина",
                        is_closed = false,
                        bdate = "1.6.1998"
                    };
                    SendMessageToClient(user,response);
                    break;
                ///method/groups.getById?group_id=1&access_token=f9ec652d9ad60f44ad77ae7b2533583702978c976c77dff5de9efad7d53056e23ec1010ed7d7b32ba25ce&v=5.103
                case "/method/groups.getById?group_id=1&access_token=f9ec652d9ad60f44ad77ae7b2533583702978c976c77dff5de9efad7d53056e23ec1010ed7d7b32ba25ce&v=5.103":
                    Group group = new Group()
                    {
                        id = "maxkorzh",
                        name = "Макс Корж",
                        members_count = 1409669
                    };
                    SendMessageToClient(group,response);
                    break;
                default:
                    string faild = "Failed!";
                    SendMessageToClient(faild,response);
                    break;
            }
        }
    }
}