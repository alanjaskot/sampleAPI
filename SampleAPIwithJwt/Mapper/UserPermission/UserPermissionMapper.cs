using SampleAPIwithJwt.DTO.UserPermission;
using SampleAPIwithJwt.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Mapper.UserPermission
{
    public static class UserPermissionMapper
    {
        public static UserPermissionDTO MapToUserPermissionDTO(UserPermissionEntityModel perission)
        {
            return new UserPermissionDTO
            {
                Id = perission.Id,
                PermitsName = perission.PermitsName,
                UserId = perission.UserId
            };
        }

        public static UserPermissionEntityModel MapToUserPermissionEntityModel(UserPermissionDTO perission)
        {
            return new UserPermissionEntityModel
            {
                Id = perission.Id,
                PermitsName = perission.PermitsName,
                UserId = perission.UserId
            };
        }
    }
}
