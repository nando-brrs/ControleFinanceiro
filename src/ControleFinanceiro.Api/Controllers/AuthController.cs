using ControleFinanceiro.Api.Configuration;
using ControleFinanceiro.Api.ViewModels;
using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationConfig applicationConfig;
        private readonly IUsuarioRepository _userRepository;
        public AuthController(IUsuarioRepository userRepository,
            IOptions<ApplicationConfig> options)
        {
            _userRepository = userRepository;
            applicationConfig = options.Value;
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] LoginViewModel login)
        {
            var user = (await _userRepository.Search(x => x.Login == login.Login &&
                                                     x.Senha == Helpers.Helpers.ConvertMD5(login.Senha) &&
                                                     x.Ativo)).FirstOrDefault();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = GenerateToken(user);

            return new
            {
                token = token
            };
        }
        public string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(applicationConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Login.ToString()),
                    new Claim("UserId", usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
