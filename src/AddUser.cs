using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class User {
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
}

class AddUser {
    static void Main() {
        var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("users.json"));
        users.Add(new User { id = 3, name = "lena", email = "lena@example.com" });
        File.WriteAllText("users.json", JsonConvert.SerializeObject(users, Formatting.Indented));
    }
}
