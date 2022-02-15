using HotelsInCities.Domain.Core.Generic;

namespace HotelsInCities.Domain.Core.Entities
{
    public class User : IGenericEntity<int>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        private User() { }

        public User(string name, string login, string password)
        {
            Name = name;
        }

        public void ChangeInfo(string name, string login, string password)
        {
            ChangeName(name);
            ChangeLogin(login); 
            ChangePassword(password);
        }

        public void ChangeLogin(string login)
        {
            if(login != null)
                Login = login;
        }

        public void ChangePassword(string password)
        {
            if(password != null)
                Password = password;
        }

        public void ChangeName(string name)
        {
            if(name != null)
                Name = name;
        }
    }
}
