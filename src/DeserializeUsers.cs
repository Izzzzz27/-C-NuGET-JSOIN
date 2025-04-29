using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UserSerializationProject.Models;

namespace UserSerializationProject
{
    class DeserializeUsers 
    {
        public static void Run() 
        {
            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("users.json")) ?? new List<User>();
            foreach (var user in users) 
            {
                Console.WriteLine($"id: {user.id}, name: {user.name ?? "N/A"}, email: {user.email ?? "N/A"}");
            }
        }
    }
}
