using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VouViajar.Auth.Application.Extensions;
using VouViajar.Auth.Application.Features.RegistrarUuario;
using VouViajar.Auth.Domain.Entities.Aggregates;
using VouViajar.Auth.Domain.Services.Interfaces;
using VouViajar.Auth.Domain.Services.ViewModel;

namespace VouViajar.Auth.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public UsuarioService(SignInManager<IdentityUser> signInManager,
                                UserManager<IdentityUser> userManager,
                                IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
        }

        public async Task<LoginResponseViewModel> RegistrarUsuarioAsync(RegistrarUsuarioCommand request)
        {

            var usuario = new Usuario
            {
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = request.EmailConfirmed
            };

            var resultUser = await _userManager.CreateAsync(usuario, request.Password);

            await _userManager.AddToRoleAsync(usuario, request.TipoUsuario.ToString());

            if (!resultUser.Succeeded)
                throw new InvalidOperationException("Erro ao criar registro de usuário.");
            await _signInManager.SignInAsync(usuario, false);

            return await Task.FromResult(await GerarToken(usuario.Email));
        }

        public async Task<LoginResponseViewModel> LogarUsuarioAsync(string email, string password, bool isPersistent, bool bockoutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent, bockoutOnFailure);
            if (!result.Succeeded)
                throw new InvalidOperationException("Erro ao logar usuário.");
            if (result.IsLockedOut)
                throw new InvalidOperationException("Usuário bloqueado por execeder número máximo de tentativas de login");

            return await Task.FromResult(await GerarToken(email));
        }

        private async Task<LoginResponseViewModel> GerarToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new InvalidOperationException("Usuário inválido");

            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
                claims.Add(new Claim("role", userRole));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
             => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
