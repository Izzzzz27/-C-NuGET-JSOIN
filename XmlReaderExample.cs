using System;
using System.Xml;
using UserSerializationProject.Models;

namespace UserSerializationProject
{
    class XmlReaderExample 
    {
        public static void Run() 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("users.xml");
            XmlNodeList? nodes = doc.SelectNodes("/users/user");

            if (nodes != null)
            {
                foreach (XmlNode node in nodes) 
                {
                    // Handle potentially null elements safely
                    var nameNode = node["name"];
                    string userName = nameNode?.InnerText ?? "Unknown";
                    Console.WriteLine("user: " + userName);
                }
            }
        }
    }
}