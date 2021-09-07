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
                if (user.Promocode.ToString() == "b77d409a-10cd-4a47-8e94-b0cd0ab50aa1")
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
        
        

        [HttpGet]
        public Guid CodeGet()
        {
            var newCode = PromocodeGenerator.CodeGen();
            return newCode;
        }
         
    }

}