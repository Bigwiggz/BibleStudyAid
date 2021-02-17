using BibleStudyInfoAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyInfoAPI.Controllers
{
    public class TokenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public TokenController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }

        [Route("/token")]
        [HttpPost]
        public async Task<IActionResult> Create(string userName, string password, string grant_type)
        {
            if (await IsValidUsernameAndPassword(userName, password))
            {
                return new ObjectResult(await GenerateToken(userName));
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<bool> IsValidUsernameAndPassword(string userName, string password)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            return await _userManager.CheckPasswordAsync(user, password);
        }

        private async Task<dynamic> GenerateToken(string userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);

            var roles = from ur in _context.UserRoles
                        join r in _context.Roles on ur.RoleId equals r.Id
                        where ur.UserId == user.Id
                        select new { ur.UserId, ur.RoleId, r.Name };

            //Add payload information to token
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddHours(3)).ToUnixTimeSeconds().ToString())
            };

            //Add roles to token
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            //Create token and sign it
            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecretKeyForNobody")),
                        SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));


            var output = new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = userName
            };

            return output;
        }

    }
}
