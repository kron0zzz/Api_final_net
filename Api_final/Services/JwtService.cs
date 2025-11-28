using Api_final.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api_final.Services
{
    public class JwtService
    {
        public readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            
            _config = config;
            
        }
        



        public string Generate(User user)
        {
            //la clave secreta para firmar el token
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            //claims: información del lusiario que irá dentro de los tokens
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
            };


            //crear token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
                );
            {
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }   
    }
}
