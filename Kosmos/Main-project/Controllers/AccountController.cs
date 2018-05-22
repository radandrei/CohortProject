using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using login_model.Models;
using login_model.Models.AccountViewModels;
using Kosmos.Controllers;
using BusinessLayer.Service;
using Kosmos.Helpers;
using Kosmos.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BusinessLayer.Models;
using DataAccessLayer;

namespace MainProject.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;
        private readonly UserService userService;
        private MedicalDBContext _context;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly ClaimsPrincipal _caller;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            ILogger<AccountController> logger,
            MedicalDBContext context,
            IJwtFactory jwtFactory,
            IOptions<JwtIssuerOptions> jwtOptions,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
            userService = new UserService(context);
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _caller = httpContextAccessor.HttpContext.User;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var identity = await GetClaimsIdentity(model.Username, model.Password);
                if (identity == null)
                {
                    //return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
                    return new BadRequestObjectResult("Invalid username or password");
                }

                var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, model.Username, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
                return new OkObjectResult(jwt);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }


        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                try
                {
                    var x = userService.CreateUser(model.Username, model.Password);
                    return new OkObjectResult(new { response = "Account created" });
                }
                catch (Exception ex)
                {
                    return new BadRequestObjectResult(ex);
                }
            }

            return BadRequest();

        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    _logger.LogInformation("User logged out.");
        //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //}


        [HttpGet("testlogin")]
        [Authorize(Policy = "Patient")]
        public IActionResult TestLogin()
        {
            try
            {
                var currentUser = GetLoggedInUser();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return new OkObjectResult("All peachy");
        }


        #region Helpers


        private UserModel GetLoggedInUser()
        {
            var userId = Int32.Parse(_caller.Claims.Single(c => c.Type == "id").Value);

            var user = userService.GetUserById(userId);

            return user;
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = userService.GetUserByUsernameAndPassword(userName, password);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials

            var x = await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.ID, userToVerify.Role.Name));
            return x;
        }

        #endregion
    }
}
