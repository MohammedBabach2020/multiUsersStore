using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using multiUserStore.Data;
using multiUserStore.Models.Account;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using BCrypt.Net;
using multiUserStore.JWT;
namespace multiUserStore.Controllers
{

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{

    private readonly GlobalDbContext _context;
    public AccountController(GlobalDbContext context)
    {
        _context = context;
    }
        [HttpPost("/api/signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUpModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if email is unique
            if (await IsEmailUnique(signUpModel.Email))
            {
                // Hash the password (You need to implement this)
                string hashedPassword = HashPassword(signUpModel.Password);

                // Create new User entity
                var user = new User
                {
                    Name = signUpModel.Name,
                    Email = signUpModel.Email,
                    Password = hashedPassword,
                    CreatedDate = DateTime.UtcNow
                };

                // Add user to database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                string token = new jwtGenerator().GenerateJwtToken(user);

                return Ok(new { Token = token });
            }
            else
            {
                // Return a 409 Conflict response if email is not unique
                return Conflict("Email address is already registered");
            }
        }

        [HttpPost("/api/signin")]
        public async Task<IActionResult> SignIn([FromBody] SIgnIn signInModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Authenticate the user (You need to implement this)
            var user = await AuthenticateUser(signInModel.Email, signInModel.Password);

            if (user != null)
            {
                // generate jwt 
                string token = new jwtGenerator().GenerateJwtToken(user);

                return Ok(new { Token = token });
            }
            else
            {
                // Invalid credentials, return a 401 Unauthorized response
                return Unauthorized("Invalid email or password");
            }
        }

      

    private async Task<bool> IsEmailUnique(string email)
    {
        // Check if the email exists in the database
        return await _context.Users.AllAsync(u => u.Email != email);
    }

    private string HashPassword(string password)
    {
            //implement password hashing
        var sw = Stopwatch.StartNew();
        var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        sw.Stop();
        return hashPassword;

     }


        private async Task<User> AuthenticateUser(string email, string password)
        {
            // Find user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                // Compare hashed passwords
                if (VerifyPasswordHash(password, user.Password))
                {
               
                 
                    // Passwords match, user authenticated successfully
                    return user;
                }
            }

            // User not found or invalid credentials
            return null;
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
          
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }

}