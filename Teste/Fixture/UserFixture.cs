using Bogus;
using Domain.Dtos;
using Bogus.DataSets;
using Domain.Entities;
using System.Collections.Generic;

namespace Teste.Fixture
{
    public static class UserFixture
    {
        public static int GetId()
        {
            return new Randomizer().Int(1, 1000);
        }
        public static string GetName()
        {
            return new Name().FirstName();
        }

        public static string GetEmail()
        {
            return new Internet().Email();
        }

        public static string GetPassword()
        {
            return new Internet().Password();
        }

        public static User GetValidUser()
        {
            return new User(GetName(), GetEmail(), GetPassword());
        }

        public static UserDto GetValidUserDto()
        {
            return new UserDto(GetId(), GetName(), GetEmail(), GetPassword());
        }

        public static UserDto GetInvalidUserDto()
        {
            return new UserDto(0, "", "", "");
        }

        public static List<User> GetValidListUsers(int limit = 5) {

            var list = new List<User>();

            for (int i = 0; i < limit; i++)
            {
                list.Add(GetValidUser());
            }

            return list;
        }
    }
}
