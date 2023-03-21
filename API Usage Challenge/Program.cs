using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Reflection;
using System.Text.Json;
using System.Collections.Generic;
using Service;
using Gateways;
using Model;
using System.Linq;

namespace Service
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Service service = new Service();

            List<Person> cache = new List<Person>();
            Person respons = null;


            while (true)
            {
                respons = null;
                Console.Write("Type the id\n>>>");
                try
                {
                    int _id = Convert.ToInt32(Console.ReadLine());

                    respons = cache.Find(x => x.Id == _id);

                    if (respons == null)
                    {
                        respons = service.GetPerson(_id);
                        respons.Id= _id;
                        cache.Add(respons);
                    }

                    Console.WriteLine(respons.name);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error has occured " + ex);
                    throw;
                }

            }
        }
    }
}
 


