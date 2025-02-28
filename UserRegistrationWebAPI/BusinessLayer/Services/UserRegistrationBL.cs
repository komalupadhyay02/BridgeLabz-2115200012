using System;
using RepositoryLayer.Services;
using ModelLayer.DTO;
//using RepositoryLayer.Service;

namespace BusinessLayer.Services
{
	public class UserRegistrationBL{
		UserRegistrationRL _userRegistrationRL;
		public UserRegistrationBL(UserRegistrationRL userRegistrationRL)
		{
			_userRegistrationRL = userRegistrationRL;
		}
		public List<User> RegistrationBL(User user)
		{
			//Check if user exist in list then we do not add it
			List<User> currentUsers = _userRegistrationRL.GetUsers();
			foreach (User data in currentUsers)
			{
				if (data.Email.Equals(user.Email))
				{
					return currentUsers ;
				}

			}
			//send it to repository layer to add the user
			return _userRegistrationRL.RegistrationRL(user);
		}
	}
}

