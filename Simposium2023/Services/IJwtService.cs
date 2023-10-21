using Microsoft.IdentityModel.Tokens;
using Simposium2023.Models.Authentications;

namespace Simposium2023.Services
{
    public interface IJwtService
    {
        SecurityToken GenerateToken(TokenData tokenData, string secretKeyId);
        TokenData ValidateToken(string token, string secretKeyId);
    }
}
