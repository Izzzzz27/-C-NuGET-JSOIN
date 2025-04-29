using UserSerializationProject.Models;

namespace UserSerializationProject
{
    public class Admin : User 
    {
        public Admin()
        {
            role = "admin";
        }
    }
}
