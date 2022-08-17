using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API_Usage_Challenge;

namespace Threding_Challenge
{
    /*
     As suggested in the challenge description, I've used used the previous challenge as the process function and populate a
     Arry of 20 people from the SWAPI. I've added the API Challenge as a project reference and using the namespace to 
     get access to the classes and methods from there.  
     */
    class Program
    {
        private static SemaphoreSlim semaphore = new SemaphoreSlim(0,3);
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            try
            {
                populate();
            }
            catch (Exception e)
            {
                Console.WriteLine("Logging Error: " + e);
            }

        }
        static void populate()
        {
            semaphore = new SemaphoreSlim(0, 3);
            Console.WriteLine("{0} tasks can enter the semaphore.", semaphore.CurrentCount);
            Task[] tasks = new Task[20];
            string[] local = new string[20];
            ApiCalls api = new ApiCalls();


            for (int i = 0; i <= 19; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    Console.WriteLine("Task {0} begins and waits for the semaphore.", Task.CurrentId);

                    int semaphoreCount;
                    semaphore.Wait();
                    try
                    {
                        int taskid = (int)Task.CurrentId;
                        Console.WriteLine("Task {0} enters the semaphore.", taskid);
                        Thread.Sleep(rand.Next(1000, 1500));
                        local[taskid - 1] = api.callPerson(taskid).name;

                    }
                    catch(Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        semaphoreCount = semaphore.Release();
                    }
                    Console.WriteLine("Task {0} releases the semaphore; previous count: {1}.",
                                      Task.CurrentId, semaphoreCount);
                });
            }

            Thread.Sleep(500);
            Console.Write("Main thread calls Release(3) --> ");
            semaphore.Release(3);
            Console.WriteLine("{0} tasks can enter the semaphore.", semaphore.CurrentCount);
            Task.WaitAll(tasks);
            Console.WriteLine("Main thread exits.");
        }
    }
    
}
