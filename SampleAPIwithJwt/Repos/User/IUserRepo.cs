using SampleAPIwithJwt.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Repos.User
{
    public interface IUserRepo
    {
        public List<UserEntityModel> GetAll();
        public UserEntityModel Login(string login, string password);

    }
}
