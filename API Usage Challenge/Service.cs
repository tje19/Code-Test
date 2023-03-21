using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Model;
using Gateways;

namespace Service
{
    class Service
    {
        public Person GetPerson(int id)
        {
            Gateway gateway = new Gateway();

            var response = gateway.GetPerson(id);

            if (response.StatusCode != (System.Net.HttpStatusCode)200)
                throw new Exception();

            return JsonSerializer.Deserialize<Person>(response.Content);
        }
    }
}
