using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.DTO.UserPermission
{
    public class UserPermissionDTO
    {
        public Guid Id { get; set; }
        public string PermitsName { get; set; }
        public Guid UserId { get; set; }
    }
}
