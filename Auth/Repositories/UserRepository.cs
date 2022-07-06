using Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Repositories
{
    public class UserRepository
    {
        public User Get(User user)
        {
            List<User> users = Create();

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password))
            {
                throw new NullReferenceException("There are empty fields!");
            } 

            return users.FirstOrDefault(x => x.Name.ToLower() == user.Name.ToLower() && x.Password == user.Password);
        }

        public List<User> Create()
        {
            List<User> users = new List<User>();

            users.Add(new User() { Id = 1, Name = "Mayara", Password = "Mayara", Country = "Brasil"});
            users.Add(new User() { Id = 2, Name = "Luiz", Password = "Luiz", Country = "Portugal" });
            users.Add(new User() { Id = 3, Name = "Geni", Password = "Geni", Country = "Angola" });

            return users;
        }
    }
}
