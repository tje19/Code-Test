using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;

namespace Gateways
{
    public class Gateway
    {
        public RestResponse GetPerson(int id)
        {
            try
            {
                RestClient client = new RestClient("https://swapi.dev/api/");
                var request = new RestRequest("people/" + id + "/", Method.Get) { RequestFormat = DataFormat.Json };
                return client.Execute(request);
            }
            catch (Exception ex)
            {
                Console.Write("Error: " + ex);
                throw;
            }
        }
    }
}