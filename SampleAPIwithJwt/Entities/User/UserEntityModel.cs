using SampleAPIwithJwt.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Entities.User
{
    public class UserEntityModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public List<UserPermissionEntityModel> Permits { get; set; }
    }
}
