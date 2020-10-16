using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace ConsomeESL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string requestUrl = null;
            object requestBody = null;
            object responseObject = null;

            string accessToken = getAccessToken("http://localhost/Reservas/App_Services/Auth.OAuth2.svc/Token", "sysdba", "masterkey");

            Console.WriteLine("Consumindo a API do WES - ESL");
            Console.WriteLine("*** Apenas o Status ***");
            Console.Write("\nInforme o status: ");
            string status = Console.ReadLine();

            var queryString = string.Format("?status={0}", HttpUtility.UrlEncode(status));
            requestUrl = "http://localhost/Reservas/api/gerenciadorreservas/ReservasPorStatus" + queryString;
            responseObject = postUrl<string>(accessToken, requestUrl, null);

            Console.WriteLine(responseObject);

            //Com Data
            Console.WriteLine("\n*** Com Data e Status ***");
            Console.Write("\nInforme o status: ");
            status = Console.ReadLine();
            Console.Write("Informe a data de início (dd/mm/aaaa): ");
            DateTime dataInicio = DateTime.Parse(Console.ReadLine());
            Console.Write("Informe a data de fim (dd/mm/aaaa): ");
            DateTime dataFim = DateTime.Parse(Console.ReadLine());

            requestUrl = "http://localhost/Reservas/api/gerenciadorreservas/ReservasPorStatusData";
            requestBody = new
            {
                Status = status,
                DataInicio = dataInicio,
                DataFim = dataFim
            };

            var listDictionary = postUrl<List<Dictionary<string, string>>>(accessToken, requestUrl, requestBody);
            for (int i = 0; i < listDictionary.Count; i++)
            {
                Dictionary<string, string> reserva = listDictionary[i];
                Console.WriteLine("\nReserva {0}", (i + 1));
                foreach (var value in reserva)
                {
                    Console.WriteLine(value.Key + " = " + value.Value);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static TypeReturn postUrl<TypeReturn>(string accessToken, string url, object objectRequest)
            where TypeReturn : class
        {
            // Montando a requisição do sistema, passando token de autenticação
            // Header, accessToken
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Headers.Add("Authorization", accessToken);
            httpWebRequest.Method = "POST";

            // Request body JSON
            if (objectRequest != null)
            {
                httpWebRequest.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(objectRequest);
                    streamWriter.Write(json);
                }
            }
            else //request sem body
            {
                httpWebRequest.ContentLength = 0;
            }
            // Response Json            
            HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                if (typeof(TypeReturn) == typeof(string))
                    return streamReader.ReadToEnd() as TypeReturn;
                return new JavaScriptSerializer().Deserialize<TypeReturn>(streamReader.ReadToEnd());
            }
        }

        private static string getAccessToken(string url, string username, string password)
        {
            // Montando a requisição
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";

            StringBuilder requestBuilder = new StringBuilder();
            requestBuilder.AppendFormat("grant_type={0}", System.Web.HttpUtility.UrlEncode("password"));
            requestBuilder.AppendFormat("&username={0}", HttpUtility.UrlEncode(username));
            requestBuilder.AppendFormat("&password={0}", HttpUtility.UrlEncode(password));

            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(requestBuilder);
            }

            // Disparando a requisição rest
            var response = webRequest.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var responseBody = streamReader.ReadToEnd();
                var jsonObject = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(responseBody);
                var accessToken = string.Format("Bearer {0}", jsonObject["access_token"]);
                return accessToken;
            }
        }
    }
}
