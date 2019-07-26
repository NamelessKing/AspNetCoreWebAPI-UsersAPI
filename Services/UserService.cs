using MyApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Services
{
    public static class UserService
    {

        private static readonly string path = "./users.json";
        public static void Save(User user)
        {
            var userList = Load();
            userList.Add(user);

            string json = JsonConvert.SerializeObject(userList);
            File.WriteAllText(path, json);
        }


        public static User GetUser(int id)
        {
            var userList = Load();
            var user = userList.Find(u => u.Id == id);

            return user;
        }



        public static List<User> Load()
        {
            try
            {
                var json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<User>>(json);

            }
            catch (JsonReaderException e)
            {
                throw new ApplicationException("il file ha un formato non valido", e);
            }
            catch (FileNotFoundException e)
            {
                throw new ApplicationException("il file non esiste", e);
            }
        }
    }
}
