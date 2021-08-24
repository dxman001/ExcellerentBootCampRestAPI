using Microsoft.IdentityModel.Tokens;
using RestAPICompleted.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RestAPICompleted.Helper
{
    public class Auth : IJwtAuth
    {
        private readonly string _key;
        private readonly SymmetricSecurityKey _signingKey;
        public Auth(string key)
        {
            _key = key;
            _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
          
        }
        public string Authentication(Member member)
        {
            if (member==null) return null;
            var credentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            DateTime expiry = DateTime.UtcNow.AddMinutes(60);
            int expiryTimeinSec = (int)(expiry - new DateTime(1970, 1, 1)).TotalSeconds;
            var payload = new JwtPayload
            {
                {"sub",member.Id },
                {"Name",member.FullName },
                {"email",member.Email },
                {"exp",expiryTimeinSec },
                {"iss","https://localhost:44303" },
                {"aud","https://localhost:44303" }
            };
            var securityToken = new JwtSecurityToken(header, payload);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(securityToken);
            return tokenString;
        }
    }
}
