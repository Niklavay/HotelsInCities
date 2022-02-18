using HotelsInCities.Domain.Core.Generic;

namespace HotelsInCities.Domain.Core.Entities
{
    public class User : IGenericEntity<int>
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private User() { }

        public User(string email, string password)
        {
           ChangeInfo(email, password);
        }

        public void ChangeInfo(string email, string password)
        {
            ChangeLogin(email); 
            ChangePassword(password);
        }

        public void ChangeLogin(string email)
        {
            if(email != null)
                Email = email;
        }

        public void ChangePassword(string password)
        {
            if(password != null)
                Password = password;
        }
    }
}
