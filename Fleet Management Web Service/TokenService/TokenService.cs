using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FleetManagementWebService.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace FleetManagementWebService.TokenService
{
    public class TokenService: IToken
    {
        public TokenObject GetToken()
        {
            var expiry = DateTime.Now.AddMinutes(30);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@54321"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:44395/",
                audience: "https://localhost:44395/",
                claims: new List<Claim>(),
                expires: expiry,
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return new TokenObject { Token = tokenString, expiry = expiry.ToShortTimeString() };
        }
    }

    public class TokenObject
    {
        public string Token { get; set; }
        public string expiry { get; set; }
    }
}
