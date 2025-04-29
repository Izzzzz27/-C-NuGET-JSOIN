public class User {
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
}

public class Admin : User {
    public string role => "admin";
}
