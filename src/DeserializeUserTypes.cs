using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class User {
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
}

public class UserWithType : User {
    public string userType { get; set; }
}

class DeserializeUserTypes {
    static void Main() {
        var users = JsonConvert.DeserializeObject<List<UserWithType>>(File.ReadAllText("user_types.json"));
        foreach (var user in users) {
            Console.WriteLine($"{user.name} has the role of {user.userType}");
        }
    }
}
