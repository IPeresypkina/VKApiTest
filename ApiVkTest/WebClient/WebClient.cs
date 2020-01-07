using System;
using System.IO;
using System.Net;

namespace ApiVkTest.WebClient
{
    public class WebClient
    {
        //private string baseURL = "https://discordapp.com/api";
        
        public string SendRequest(string requestString, string method)
        {
            // requestString = baseURL + requestString;
            
            WebRequest request = WebRequest.Create(requestString);
            //request.Headers.Set("Authorization", "f9ec652d9ad60f44ad77ae7b2533583702978c976c77dff5de9efad7d53056e23ec1010ed7d7b32ba25ce");
            request.Method = method;
            request.Credentials = CredentialCache.DefaultCredentials;
            
            WebResponse response = request.GetResponse(); 
            
            Stream stream = response.GetResponseStream(); 
            
            StreamReader reader = new StreamReader(stream);
            
            
            string receiveMessage = reader.ReadToEnd();
            
            stream.Close();
            response.Close();

            return receiveMessage;
        }
    }
}