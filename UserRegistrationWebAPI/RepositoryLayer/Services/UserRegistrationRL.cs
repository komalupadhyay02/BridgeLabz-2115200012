using System;
using ModelLayer.DTO;
namespace RepositoryLayer.Services
{
	public class UserRegistrationRL
	{ 
		List<User> users;
        public UserRegistrationRL()
		{
			users = new List<User>();
			
		}
		//method to get the users
		public List<User> GetUsers()
		{
			
			return users;

		}
		//Add user to list
		public List<User> RegistrationRL(User user)
		{
			users.Add(user);
			return users;
		}
	}
}

