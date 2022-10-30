using System;
using System.Collections.Generic;
using System.Text;
using Domain.Validators;

namespace Domain.Entities
{
    public class User: Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {

        }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
            Validate();
        }

        public bool Validate() => Validate(new UserValidator(), this);

        public void SetName(string name)
        {
            Name = name;
            Validate();
        }

        public void SetPassword(string password)
        {
            Password = password;
            Validate();
        }

        public void SetEmail(string email)
        {
            Email = email;
            Validate();
        }

    }
}
