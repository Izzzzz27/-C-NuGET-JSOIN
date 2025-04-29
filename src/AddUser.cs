using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UserSerializationProject.Models;

namespace UserSerializationProject
{
    class AddUser 
    {
        public static void Run() 
        {
            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("users.json")) ?? new List<User>();
            
            // Generate new ID (max + 1)
            int newId = 1;
            if (users.Count > 0)
            {
                newId = users.Max(u => u.id) + 1;
            }
            
            users.Add(new User { id = newId, name = "lena", email = "lena@example.com" });
            File.WriteAllText("users.json", JsonConvert.SerializeObject(users, Formatting.Indented));
            
            Console.WriteLine($"User 'lena' added successfully with ID {newId}!");
        }
    }
}
