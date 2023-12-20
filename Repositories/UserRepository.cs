using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTransacoesBancarias.Models;

namespace ApiTransacoesBancarias.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "admin", Password = "admin"});

            return users.
            FirstOrDefault(
                x => x.Username == username 
                && x.Password == password);
        }
    }
}