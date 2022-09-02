using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstBackend.DataAccess;
using MyFirstBackend.Helpers;
using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UniversityDbContext _context;

        public AccountController(UniversityDbContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        private IEnumerable<User> Logins = new List<User>
        {
            new User{ Id = 1, Email = "djsilvab@gmail.com", FirstName = "Admin", Password = "Admin" },
            new User{ Id = 2, Email = "pepe@gmail.com", FirstName = "User01", Password = "Admin" }
        };

        [HttpPost]
        public IActionResult GetToken(UserLogin userLogin)
        {
            try
            {
                var Token = new UserTokens();

                var valid = Logins.Any(x => x.FirstName.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase));

                if (valid)
                {
                    var user = Logins.FirstOrDefault(x => x.FirstName.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(
                        new UserTokens { 
                            EmailId = user.Email,
                            Username = user.FirstName,
                            Id = user.Id,
                            GuidId = Guid.NewGuid(),
                        },
                        _jwtSettings
                    );
                }
                else
                {
                    return BadRequest("Wrong Password");
                }

                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }


    }
}
