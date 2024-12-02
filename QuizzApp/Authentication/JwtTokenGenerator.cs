using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuizzApp.Common.Interfaces.Authentication;
using QuizzApp.Models;

public class JwtTokenGenerator : IJwtTokenGenerator{

    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings){
        _jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(User user){
        var sigCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Aud, _jwtSettings.Audience)
        };

        var securityToken = new JwtSecurityToken(
            issuer:_jwtSettings.Issuer,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            claims:claims,
            signingCredentials:sigCredentials
            );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}