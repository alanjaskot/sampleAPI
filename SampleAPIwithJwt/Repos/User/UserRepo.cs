using SampleAPIwithJwt.Context.Interaface;
using SampleAPIwithJwt.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Repos.User
{
    public class UserRepo: IUserRepo
    {
        private readonly IAppDataBaseContext _context;

        public UserRepo(IAppDataBaseContext context)
        {
            _context = context;
        }

        public List<UserEntityModel> GetAll()
        {
            var result = default(List<UserEntityModel>);
            try
            {
                result = _context.Users.ToList();
            }
            catch
            {
                throw;
            }
            return result;
        }

        public UserEntityModel Login(string login, string password)
        {
            var result = default(UserEntityModel);
            try
            {
                result = _context.Users
                    .Where(u => u.Login == login && u.Password == password)
                    .FirstOrDefault();
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
