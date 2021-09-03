using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using BuyAndRead.Models;
using BuyAndRead.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace BuyAndRead.Controllers
{   
    [Route("api/")]
    [ApiController]
    public class LoginController : Controller
    {
       /* private readonly IOptions<LoginOptions> loginOptions;
        public LoginController(IOptions<LoginOptions> loginOptions)
        {
        }*/
        
        private readonly BuyAndReadDbContext _dbContext;
        public LoginController(BuyAndReadDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Guid CodeGet(Guid[] args)
        {
            var newCode = PromocodeGenerator.CodeGen();
            return newCode;
        }
        

        [HttpGet]
        public Guid CodeGet()
        {
            var newCode = PromocodeGenerator.CodeGen();
            return newCode;
        }
        //Их тоже под списание
        //[Route("login")]
        /*[HttpPost]
        public IActionResult Login([FromBody]User request)
        {
            
            var user = AuthenticateUser(request.Promocode);
            if (user != null)
            {
                var token = GenerateJWT(user);
                return Ok(new
                {
                    access_token = token
                });

            }

            return Unauthorized();
        }

        private User AuthenticateUser(string Promocode)
        {
            return BuyAndReadDbContext.Users.SingleOrDefault(u => u.Promocode == Promocode);
        }
        
        private string GenerateJWT(User user)
        {
            var loginParams = loginOptions.Value;
            var sequrityKey = loginParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(sequrityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>();
            foreach (var promo in user.Promocode)
            {
                claims.Add(new Claim("promo", promo.ToString()));
            }

            var token = new JwtSecurityToken(loginParams.Issuer,
                loginParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(loginParams.TokenLifeTime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        /// <summary>
        /// Тут авторизация из практики, совершенно не подходящая
        /// </summary>
        
        /*
        [HttpPost]
        public IActionResult Login(User model)
        {
            var user = _dbContext.Users.FirstOrDefault(c => c.Promocode == model.Promocode);
            if (user == null)
            {
                ModelState.AddModelError(String.Empty, "Такой промокод не зарегистрирован!");
            }

            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString())
                };

                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString());
                }
                var authProp = new AuthenticationProperties();
                authProp.IsPersistent = true;
                authProp.ExpiresUtc = DateTime.UtcNow.AddHours(2);

                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id), authProp);
                HttpContext.Session.SetString("NickName", user.Promocode);
                HttpContext.Session.SetInt32("UserId", user.Id);
            }
            //return RedirectToAction("Index","Main")
        }*/

       /* public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            //return RedirectToAction("Index", "Feed");
        }*/
        
    }
    


}