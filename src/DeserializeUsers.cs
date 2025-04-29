using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class User {
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
}

class DeserializeUsers {
    static void Main() {
        var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("users.json"));
        foreach (var user in users) {
            Console.WriteLine($"id: {user.id}, name: {user.name}, email: {user.email}");
        }
    }
}
