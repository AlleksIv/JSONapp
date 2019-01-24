using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using Newtonsoft.Json;


namespace JSONapp
{
    class Appview
    {
        private readonly SynchronizationContext _context = SynchronizationContext.Current;
        public ObservableCollection<User> Users { get; set; }

        public void UpdateView()
        {
            _context.Send(state =>
            {   Users.Clear();
                foreach (var user in ReadFile() )
                {                   
                    Users.Add(user);
                }

            },null);
        }

        public List<User> ReadFile()
        {   
            
            List<User> users;

            using (StreamReader reader = new StreamReader(@"C:\Users\NPC\source\repos\JSONapp\users.json"))
            {
                string json = reader.ReadToEnd();
                users = JsonConvert.DeserializeObject<ListUsers>(json).Users;
            }
            return users;
        }

        public Appview()
        {
            Users = new ObservableCollection<User>();
            UpdateView();
        }
    }
    

    public class User
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string SomeUselessStuff { get; set; }
        public string NameOfDog { get; set; }
        public string Breakfast { get; set; }
        public override string ToString()
        {
            return "User";
        }
    }
    public class ListUsers
    {
        public List<User> Users;

    }


}
