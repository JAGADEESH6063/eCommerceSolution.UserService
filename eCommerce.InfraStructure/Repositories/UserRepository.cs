using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.InfraStructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.InfraStructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dapperDbContext;

        public UserRepository(DapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser applicationUser)
        {
            applicationUser.UserId = Guid.NewGuid();
            string query = "Insert into \"Users\" (\"UserId\",\"Email\",\"Password\",\"PersonName\",\"Gender\")" +
                "values (@UserId, @Email, @Password, @PersonName, @Gender)";

            int RowsAffected = await _dapperDbContext.dbConnection.ExecuteAsync(query, applicationUser);

            if (RowsAffected > 0)
                return applicationUser;
            else
                return null;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = "select *from \"Users\" where \"Email\" = @Email and \"Password\" = @Password";

            ApplicationUser? user = await _dapperDbContext.dbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,
                new { Email = email, Password = password }
                );

            return user;
        }
    }
}
