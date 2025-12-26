using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.InfraStructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public async Task<ApplicationUser?> AddUser(ApplicationUser applicationUser)
        {
            applicationUser.UserId = Guid.NewGuid();
            return applicationUser;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            return new ApplicationUser()
            {
                UserId = Guid.NewGuid(),
                Email = email,
                Password = password,
                Gender = GenderOptions.MALE.ToString(),
                PersonName = "Jaga"
            };
        }
    }
}
