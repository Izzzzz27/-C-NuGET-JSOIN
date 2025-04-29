using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UserSerializationProject.Models;

namespace UserSerializationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task Menu
            Console.WriteLine("Choose a task to run:");
            Console.WriteLine("1. Add a user (via Program.cs)");
            Console.WriteLine("2. Deserialize users from JSON (via Program.cs)");
            Console.WriteLine("3. Exit");
            Console.WriteLine("4. Add User (via AddUser.cs)");
            Console.WriteLine("5. Deserialize Users (via DeserializeUsers.cs)");
            Console.WriteLine("6. Deserialize User Types (via DeserializeUserTypes.cs)");
            Console.WriteLine("7. Read XML (via XmlReaderExample.cs)");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddUserMethod();
                    break;

                case "2":
                    DeserializeUsersMethod();
                    break;
                    
                case "3":
                    Console.WriteLine("Exiting...");
                    break;
                    
                case "4":
                    AddUser.Run();
                    break;
                    
                case "5":
                    DeserializeUsers.Run();
                    break;
                    
                case "6":
                    DeserializeUserTypes.Run();
                    break;
                    
                case "7":
                    XmlReaderExample.Run();
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }

        // Method to Add a User to the JSON File
        static void AddUserMethod()
        {
            Console.WriteLine("Enter username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter email:");
            var email = Console.ReadLine();
            Console.WriteLine("Enter role (admin/user):");
            var role = Console.ReadLine();

            // Load existing users (or create an empty list if none exists)
            var users = LoadUsers();
            
            // Generate new ID (max + 1)
            int newId = 1;
            if (users.Count > 0)
            {
                newId = users.Max(u => u.id) + 1;
            }

            // Create new user object based on role
            User newUser;
            // Handle nullability by providing safe defaults
            string safeUsername = username ?? "unnamed";
            string safeEmail = email ?? "";
            
            if (role?.ToLower() == "admin")
            {
                newUser = new Admin { id = newId, name = safeUsername, email = safeEmail };
            }
            else
            {
                newUser = new RegularUser { id = newId, name = safeUsername, email = safeEmail };
            }
            users.Add(newUser);

            // Save updated users list back to the JSON file
            File.WriteAllText("users.json", JsonConvert.SerializeObject(users, Formatting.Indented));
            Console.WriteLine("User added successfully!");
        }

        // Method to Deserialize Users from the JSON File
        static void DeserializeUsersMethod()
        {
            var users = LoadUsers();

            Console.WriteLine("Deserialized Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.id}, Name: {user.name}, Email: {user.email}, Role: {user.role}");
            }
        }

        // Helper method to load users from JSON file
        static List<User> LoadUsers()
        {
            if (!File.Exists("users.json"))
            {
                // If file doesn't exist, return an empty list
                return new List<User>();
            }

            var json = File.ReadAllText("users.json");
            return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
        }
    }
}