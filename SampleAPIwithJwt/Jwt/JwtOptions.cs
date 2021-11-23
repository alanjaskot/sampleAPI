using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Jwt
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int ExpiryHours { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateAudience { get; set; }
        public string ValidAudience { get; set; }
    }
}
