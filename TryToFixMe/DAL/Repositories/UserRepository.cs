using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : IRepository
    {
        public List<User> LoadRecords()
        {
            List<User> users = new List<User>();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(GetJsonData())))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(users.GetType());
                users = ser.ReadObject(ms) as List<User>;
            }
            return users;
        }
        
        private string GetJsonData()
        {
            string json = "[{ \"Age\":40,\"Firstname\":\"Fred\",\"Lastname\":\"Smith\"}]";
            return json;
        }
    }
}