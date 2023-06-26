using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BixbyShop_LK.Config;
using Microsoft.IdentityModel.Tokens;

namespace BixbyShop_LK.Services
{
    public class TokenService
    {

        private readonly string secretKey;
        private readonly string issuer;
        private readonly string audience;

        public TokenService()
        {
            secretKey = EnvironmentService.getEnvironmentVariable("your-secret-key");
            issuer = EnvironmentService.getEnvironmentVariable("your-issuer");
            audience = EnvironmentService.getEnvironmentVariable("your-audience");
        }

      
        private string GenerateJwtToken(string secretKey, string issuer, string audience, int expiryMinutes, String email, String password)
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

        private bool ExtractCustomClaim(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var claims = token.Claims;

            var email = claims.FirstOrDefault(c => c.Type == "email");
            var password = claims.FirstOrDefault(c => c.Type == "password");

            /*User user = _userService.checkAndGetUser(email.ToString(), true);
            if (user != null && user.EmailVerify)
                return user.Password == password.ToString();
            else
                return false;*/
            return false;
        }

        public String tokenCreator(String email, String password)
        {
            int expiryMinutes = 10000;
            return GenerateJwtToken(secretKey, issuer, audience, expiryMinutes, email, password);
        }

        public bool ValidateJwtToken(string token)
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
                return ExtractCustomClaim(token);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
