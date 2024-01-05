using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TGE.Models.Token
{
    public class TokenResponse
    {
        public string Token {get; set;} = null!;
        public DateTime IssuedAt {get; set;}
        public DateTime Expires {get; set;}
    }
}