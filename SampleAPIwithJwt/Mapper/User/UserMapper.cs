using SampleAPIwithJwt.DTO.User;
using SampleAPIwithJwt.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Mapper.User
{
    public static class UserMapper
    {
        public static UserDTO MapToUserDTO(UserEntityModel user)
        {
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password
            };

            return userDTO;
        }

        public static UserEntityModel MapToUserEntityMode(UserDTO user)
        {
            return new UserEntityModel
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password
            };
        }
    }
}
