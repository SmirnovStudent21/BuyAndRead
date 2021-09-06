using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
    [Route("api/auth")]
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

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                if (user == null)
                    return BadRequest("Invalid client request");
                if (user.Promocode == "b77d409a-10cd-4a47-8e94-b0cd0ab50aa1")
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5001",
                        audience: "http://localhost:5001",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signingCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new {Token = tokenString});
                }
            }

            return Unauthorized();
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