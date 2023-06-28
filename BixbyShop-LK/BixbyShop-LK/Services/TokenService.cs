using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

namespace BixbyShop_LK.Services
{
    public static class TokenService
    {

        private static string secretKey = "hdsacsfhfjfvjdjsjvdsjvsjdvjsdjvdsvkjsbjbfjbgjsb";
        private static string issuer = "Manura Sanjula";
        private static string audience = "Manura Sanjula";
        private static UserService userService = new UserService();

        private static string GenerateJwtToken(string secretKey, string issuer, string audience, int expiryMinutes, String email, String password)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "subject"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim("email", email),
                new Claim("password", password)
            };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static dynamic ExtractCustomClaim(string jwtToken, bool allowBoolean)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var claims = token.Claims;

            var email = claims.FirstOrDefault(c => c.Type == "email");
            var password = claims.FirstOrDefault(c => c.Type == "password");

            User user = userService.GetUserByEmail(email.ToString());
            if(user == null)
            {
                return null;
            }
            else
            {
                if (allowBoolean)
                {
                    return user.Password == password.ToString();
                }
                else
                {
                    return user;
                }
            }
        }

        public static String tokenCreator(String email, String password)
        {
            int expiryMinutes = 10000;
            return GenerateJwtToken(secretKey, issuer, audience, expiryMinutes, email, password);
        }

        public static dynamic ValidateJwtToken(string token, bool allowBoolean)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidIssuer = issuer,
                ValidAudience = audience
            };

            try
            {
                SecurityToken validatedToken;
                tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                return ExtractCustomClaim(token, allowBoolean);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
