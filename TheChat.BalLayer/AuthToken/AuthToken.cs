﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TheChat.Utility.Common;
using static TheChat.BalLayer.ViewModels.AuthenticationViewModel;

namespace TheChat.BalLayer.AuthToken
{
    public static class AuthToken
    {

        public static string GenerateJSONWebToken(AuthenticationResponseViewModel ARVM)
        {

            SymmetricSecurityKey sskSecurityKey = new SymmetricSecurityKey(Convert.FromBase64String(AppSettings.JwtKey));
            var claims = new[]
            {

                new Claim(JwtRegisteredClaimNames.Email, ARVM.Email),
                new Claim(ClaimTypes.Role, ARVM.UserId.ToString()),
                new Claim(ClaimTypes.Name, ARVM.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SecurityTokenDescriptor stdDescriptor = new SecurityTokenDescriptor
            {
                Issuer = AppSettings.JwtIssuer,
                Audience = AppSettings.JwtAudience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(AppSettings.JwtAddExpireTime)),
                SigningCredentials = new SigningCredentials(sskSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler jsthHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jstToken = jsthHandler.CreateJwtSecurityToken(stdDescriptor);

            return jsthHandler.WriteToken(jstToken);
        }



        public static ClaimsPrincipal ValidateToken(string jwtToken)
        {
            ClaimsPrincipal principal = null;
            try
            {
                SecurityToken validatedToken;

                principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, GetTokenValidationParameters(), out validatedToken);

                var jwtExpValue = long.Parse(principal.Claims.FirstOrDefault(x => x.Type == "exp").Value);
                DateTime expirationTime = DateTimeOffset.FromUnixTimeSeconds(jwtExpValue).DateTime;
            }
            catch
            {
                principal = null;
            }

            return principal;
        }




        public static int LoginUserId(string jwtToken)
        {
            ClaimsPrincipal principal = null;

            try
            {
                principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, GetTokenValidationParameters(), out var validatedToken);
            }
            catch
            {
                principal = null;
            }

            return principal != null ? Convert.ToInt32(principal.FindFirst(ClaimTypes.Name).Value) : 0;
        }


        public static TokenValidationParameters GetTokenValidationParameters()
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.RequireExpirationTime = true;
            validationParameters.ValidAudience = AppSettings.JwtAudience;
            validationParameters.ValidIssuer = AppSettings.JwtIssuer;
            validationParameters.ClockSkew = TimeSpan.Zero;
            validationParameters.IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Convert.FromBase64String(AppSettings.JwtKey));

            return validationParameters;
        }
    }
}
