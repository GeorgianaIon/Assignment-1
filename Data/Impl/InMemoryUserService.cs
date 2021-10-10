using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualBasic;

namespace WebApplication
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    City = "Horsens",
                    Domain = "via.dk",
                    Password = "123456",
                    Role = "Teacher",
                    BirthYear = 1986,
                    SecurityLevel = 4,
                    UserName = "Troels"
                },
                new User
                {
                    City = "Horsens",
                    Domain = "hotmail.com",
                    Password = "654321",
                    Role = "Student",
                    BirthYear = 2001,
                    SecurityLevel = 2,
                    UserName = "Geana"
                }
            }.ToList();
        }
        
        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }
            return first;
        }
        
    }
}