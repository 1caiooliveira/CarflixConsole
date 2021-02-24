using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Carflix
{
    class Program
    {
        static void Main(string[] args)
        {
            string tag;
            Console.WriteLine("Digite a tag: ");
            tag = Console.ReadLine();

            GetQuestions(tag);
            Console.ReadKey();


        }

        static void GetQuestions(string tag)
        {
            string ApiBaseUrl = "https://api.stackexchange.com/2.2";
            string action = string.Format("/questions?key=U4DMV*8nvpm3EOpvf69Rxw((&site=stackoverflow&order=desc&sort=activity&tagged={0}&filter=default", tag);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + action);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;

            var response = httpWebRequest.GetResponse();
            if(((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                using(Stream stream = response.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(stream);

                    
                    Console.Write(streamReader.ReadToEnd());
                }
            }else
            {
                Console.Write("Algo deu errado!!");
            }







        }

    }
}
