using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace DimaII
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (StreamReader reader = new StreamReader(@"C:\Users\NPC\source\repos\JSONapp\users.json"))
            {

                
                    string json = reader.ReadToEnd();
                    var  Users = JsonConvert.DeserializeObject<ListUsers>(json);
                //    Console.WriteLine(json); // Write to console.
                    foreach (var user in Users.Users)
                    {
                        Console.WriteLine(user);
                    }

            }
            Thread.Sleep(10000000);
        }


    }

    public class User
    {
        public string Name;
        public int Age;
        public string Email;
        public string Country;
        public string SomeUselessStuff;
        public string NameOfDog;
        public string Breakfast;
        public override string ToString()
        {
            return $"User Name {Name}, Age {Age} \n Email {Email} \n  \n ";
        }
    }
    public class ListUsers
    {
        public List<User> Users;

    }
}
