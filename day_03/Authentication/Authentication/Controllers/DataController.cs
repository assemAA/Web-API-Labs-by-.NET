using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("data/[controller]")]
    [ApiController]
    public class DataController : Controller
    {
        private readonly UserManager<User> userManager;

        public DataController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("userInfo")]
        [Authorize]
        public async Task<ActionResult> getUserInfo()
        {
            User user = await userManager.GetUserAsync(User);

            return Ok(new
            {
                UserName = user?.UserName,
                Email = user?.Email,
                Address = user?.Address
            });
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        [Route("Admin")]
        public ActionResult getDataForAdmin()
        {
            return Ok(new string[] { "Admin data" });
        }


        [HttpGet]
        [Authorize(Policy = "User")]
        [Route("User")]
        public ActionResult getDataForUser()
        {
            return Ok(new string[] { "User data" });
        }
    }
}
