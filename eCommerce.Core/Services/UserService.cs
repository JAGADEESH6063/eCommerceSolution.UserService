using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.InfraStructure.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(
                loginRequest.Email, loginRequest.Password
                );

            if (user == null)
                return null;

            return new AuthenticationResponse(user.UserId, user.Email, user.PersonName,"Token", user.Gender,
                Success: true);

        }

        public async Task<AuthenticationResponse?> SignUp(RegisterRequest registerRequest)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString(),
                PersonName = registerRequest.PersonName
            };
            ApplicationUser? registeredUser = await _userRepository.AddUser(user);

            if (registeredUser == null)
                return null;

            return new AuthenticationResponse(registeredUser.UserId,
                registeredUser.Email, 
                registeredUser.PersonName, 
                "token",
                registeredUser.Gender, 
                true);
        }
    }
}
