using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Reflection;
using System.Text.Json;
using System.Collections.Generic;
using Service;
using Gateways;

namespace Service
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Service service = new Service();

            while (true)
            {
                Console.Write("Type the id\n>>>");
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(service.GetPerson(id).name);

                    Console.WriteLine(service.GetPerson(id).name);

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
 


