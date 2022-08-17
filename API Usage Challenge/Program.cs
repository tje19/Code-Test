using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Text.Json;

namespace API_Usage_Challenge
{

    /*
    I've decided to seperate the actual API call into a class and give it a local cache
    as the challenge asks for, that way outside processes can simply request the desired
    person by calling the callPerson methode and not worry whether the entry is stored
    local or needs to be retrived
     */
    class Program
    {
        static void Main(string[] args)
        {
            ApiCalls apiCalls = new ApiCalls();
            int index = 0;
            while (true)
            {

                Console.Write("Enter index of entry to retrieve a name\n>>>");
                try
                {
                    index = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {

                    Console.WriteLine("Logging Exception: " + e);
                }

                try
                {
                    Console.WriteLine(apiCalls.callPerson(index).name);

                }
                catch (Exception e)
                {
                    Console.WriteLine("logging Exception: " + e);
                }

            }

        }
    }

    /*
     The methode callPerson is simple to use, taking an int and throwing back the desired
     person. Internally the methode handles checkking if the person is already stored 
     loaclly or needs to be retrived. I've also made sure that if an index with no person
     tied to it is called it returns an exception and is logged*/
    class ApiCalls
    {
        private PersonClass[] local = new PersonClass[82];
        string detailNotFound = "\"detail\":\"Not found\"";
        RestClient client = new RestClient("https://swapi.dev/api/");
        public PersonClass callPerson(int Call)
        {
            if (local[Call] == null)
            {
                try
                {
                    var request = new RestRequest("people/" + Call + "/", Method.Get) { RequestFormat = DataFormat.Json };
                    var response = client.Execute(request);

                    if (!detailNotFound.Equals(response.Content))
                    {
                        local[Call] = JsonSerializer.Deserialize<PersonClass>(response.Content);
                        return local[Call];
                    }
                    else
                    {
                        throw new Exception("No entry found on SWAPI");
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                return local[Call];
            }
        }
    }
}
