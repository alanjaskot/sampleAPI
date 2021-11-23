using SampleAPIwithJwt.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Entities.UserPermission
{
    public class UserPermissionEntityModel
    {
        public Guid Id { get; set; }
        public string  PermitsName { get; set; }

        public Guid UserId { get; set; }
        public UserEntityModel User { get; set; }
    }
}
