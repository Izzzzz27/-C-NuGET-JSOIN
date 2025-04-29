using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UserSerializationProject.Models;

namespace UserSerializationProject
{
    public class UserWithType : User 
    {
        public string? userType { get; set; }
    }

    class DeserializeUserTypes 
    {
        public static void Run() 
        {
            var users = JsonConvert.DeserializeObject<List<UserWithType>>(File.ReadAllText("user_types.json")) ?? new List<UserWithType>();
            foreach (var user in users) 
            {
                Console.WriteLine($"{user.name ?? "Unknown"} has the role of {user.userType ?? "unspecified"}");
            }
        }
    }
}
