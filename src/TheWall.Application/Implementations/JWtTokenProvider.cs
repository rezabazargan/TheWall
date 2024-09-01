using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TheWall.Application.Contracts;
using TheWall.Application.Model;

namespace TheWall.Application.Implementations;

internal class JwtTokenProvider : ITokenProvider
{
    public Task<string> GetToken(LoginUserResult user, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = "4f1feeca525de4cdb064656007da3edac7895a87ff0ea865693300fb8b6e8f9c"u8.ToArray();
        
        
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim("id", user.Id) ,
                new Claim("name", user.Name ?? ""),
                new Claim("email", user.Email ?? ""),
                new Claim("roles", string.Join(',', user.Roles)),

            ]),
            Issuer = "http://thewall.com",
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        return Task.FromResult(tokenHandler.CreateEncodedJwt(tokenDescriptor));
    }
}