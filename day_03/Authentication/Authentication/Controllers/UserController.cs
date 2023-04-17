using Authentication.Dtos;
using Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Controllers
{
    [Route("user/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        public UserController(IConfiguration configurations , UserManager<User> userManager) 
        {
            this.configuration = configurations;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult> RegisterUser(RegisterDto registerDto)
        {
            User user = new User() {
                UserName = registerDto.UserName,
                Email= registerDto.Email,
                Address= registerDto.Address,
            };

            IdentityResult result = await userManager.CreateAsync(user , registerDto.Password);

            if (result.Succeeded)
            {
            
            List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, "User"), };

            await userManager.AddClaimsAsync(user, claims);

            return Ok();

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<ActionResult> RegisterAdmin (RegisterDto registerDto)
        {
            User user = new User()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Address = registerDto.Address,
            };

            IdentityResult result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {

                List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, "Admin"), };

                await userManager.AddClaimsAsync(user, claims);

                return Ok();

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login (LoginDto credentials)
        {
            User user = await userManager.FindByNameAsync(credentials.UserName);
            if (user == null)
            {
                return Unauthorized();
            }
            bool isAuthenticated = await userManager.CheckPasswordAsync(user , credentials.Password);

            if (!isAuthenticated)
            {
                return Unauthorized();
            }


            IList<Claim> claimsList = await userManager.GetClaimsAsync(user);


            string secretKeyString = configuration.GetValue<string>("SecretKey");
            byte[] secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(secretyKeyInBytes);

            SigningCredentials signingCredentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256Signature);

            DateTime expireDate = DateTime.Now.AddDays(2);
            JwtSecurityToken token = new JwtSecurityToken(
                claims: claimsList,
                expires: expireDate,
                signingCredentials: signingCredentials);


            JwtSecurityTokenHandler tokenHndler = new JwtSecurityTokenHandler();
            String tokenString = tokenHndler.WriteToken(token);

            return new TokenDto(tokenString, expireDate);


        }


    }
}
