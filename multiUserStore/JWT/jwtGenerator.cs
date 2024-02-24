using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using multiUserStore.Models.Account;


namespace multiUserStore.JWT
{
    public class jwtGenerator
    {
        public string GenerateJwtToken(User user)
        {
            // Define security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dMd7p5FRAHgglJHGSGpt6YmIJlVg7rDu"));

            // Create token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // User ID
            new Claim(ClaimTypes.Email, user.Email), // User Email
            new Claim(ClaimTypes.UserData, user.Password) // User pwd                                    
                }),
                Expires = DateTime.UtcNow.AddDays(1), // Token expiration time
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            // Create token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Serialize token to string
            return tokenHandler.WriteToken(token);
        }

    }
}
