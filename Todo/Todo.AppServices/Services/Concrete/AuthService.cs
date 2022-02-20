using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Todo.AppServices.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        
        public string GenerateJWT(string username, string password)
        {
            var key = _configuration["Jwt:Key"];

            // var tokenHandler = new JwtSecurityTokenHandler();
            // var tokenKey = Encoding.ASCII.GetBytes(key);
            // var tokenDescriptor = new SecurityTokenDescriptor()
            // {
            //     Subject = new ClaimsIdentity(
            //         new Claim[]
            //         {
            //             new Claim(ClaimTypes.Name, username)
            //         }),
            //     Expires = DateTime.UtcNow.AddHours(1),
            //     SigningCredentials = new SigningCredentials(
            //         new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            // };
            // var token = tokenHandler.CreateToken(tokenDescriptor);
            // return tokenHandler.WriteToken(token);
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var issuer = _configuration["Jwt:Issuer"];
            var token = new JwtSecurityToken(issuer,    
                issuer,    
                null,    
                expires: DateTime.Now.AddMinutes(120),    
                signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}