using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Models
{
    public class TokenResponseModel
    {

        public string Type { get; }
        public string Token { get; }
        

        public TokenResponseModel(string type, string token)
        {
            Token = token;
            Type = type;
        }
    }
}
