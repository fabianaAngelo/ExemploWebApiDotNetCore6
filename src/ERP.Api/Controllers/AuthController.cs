using ERP.Api.Extensions;
using ERP.Api.ViewModels.Users;
using ERP.Api.ViewModels.UserViewModel;
using ERP.Business.Interfaces;
using ERP.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERP.Api.Controllers
{
    [Route("api")]
    public class AuthController : MainController<AuthController>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(IErrorNotifier errorNotifier,
                            SignInManager<ApplicationUser> signInManager,
                            UserManager<ApplicationUser> userManager,
                            IOptions<AppSettings> appSettings,
                            IUser user) : base(errorNotifier, user)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        //[HttpPost("new-account")]
        //public async Task<ActionResult> Register(RegisterUserViewModel registerUser)
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);

        //    var user = new ApplicationUser
        //    {
        //        UserName = registerUser.Email,
        //        Email = registerUser.Email,
        //        EmailConfirmed = false
        //    };

        //    var result = await _userManager.CreateAsync(user, registerUser.Password);
        //    if (result.Succeeded)
        //    {
        //        await _signInManager.SignInAsync(user, isPersistent: false);
        //        return CustomResponse(await GenerateJwt(user.Email));
        //    }
        //    foreach (var error in result.Errors)
        //    {
        //        NotifyError(error.Description);
        //    }

        //    return CustomResponse(registerUser);
        //}

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody]LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginUser.Email);
                if (user.Disabled || user.IsDeleted)
                {
                    NotifyError("Usuário ou Senha incorretos");
                    return CustomResponse(loginUser);
                }
                return CustomResponse(await GenerateJwt(user));
            }
            if (result.IsLockedOut)
            {
                NotifyError("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(loginUser);
            }

            NotifyError("Usuário ou Senha incorretos");
            return CustomResponse(loginUser);

        }

        private async Task<LoginResponseViewModel> GenerateJwt(ApplicationUser user)
        {
            //var user = await _userManager.FindByEmailAsync(email);
            var claims = await GetClaims(user);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            UserTokenViewModel userData = await GetUserData(user, claims);

            return new LoginResponseViewModel
            {
                AccessToken = CreateToken(identityClaims),
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiryHours).TotalSeconds,
                UserToken = userData
            };
        }
        private async Task<IList<Claim>> GetClaims(ApplicationUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email != null ? user.Email : string.Empty));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            return claims;
        }

        private async Task<UserTokenViewModel> GetUserData(ApplicationUser user, IList<Claim> claims)
        {
            var notTypeResults = new List<string>(){
                JwtRegisteredClaimNames.Sub,
                JwtRegisteredClaimNames.Email,
                JwtRegisteredClaimNames.Jti,
                JwtRegisteredClaimNames.Nbf,
                JwtRegisteredClaimNames.Iat
            };

            UserTokenViewModel userData = new UserTokenViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Claims = claims.Where(c => !notTypeResults.Contains(c.Type))
                            .Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
            };

            return userData;
        }

        private string CreateToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emitter,
                Audience = _appSettings.ValidIn,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiryHours),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
