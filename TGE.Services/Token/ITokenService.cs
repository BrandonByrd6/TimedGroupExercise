using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGE.Models.Token;

namespace TGE.Services.Token
{
    public interface ITokenService
    {
        Task<TokenResponse?> GetTokenAsync(TokenRequest model);
    }
}