﻿using BooksManagementSystem.DTOs;
using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.Swagger;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace BooksManagementSystem.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //public static User user = new User();
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        //private readonly IUserRepository _userRepository;
        public AuthenticationController(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserForRegistrationDto request)
        {
            //check user exist
            var userExist = await _userManager.FindByEmailAsync(request.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            //add user in database
            IdentityUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.UserName,
            };


            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return StatusCode(StatusCodes.Status200OK);

        }

        //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //    }
        //}


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserForLoginDto request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = CreateToken(claims);

                return Ok(token);

            }


            return Unauthorized();




        }


        private string CreateToken(List<Claim> claims)
        {
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Key").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }



        //private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //we create nw computed hash value with the login password and check if resulting pass hash is same as stored it means user entered correct username
        //{
        //    using (var hmac = new HMACSHA512(user.PasswordSalt))
        //    {
        //        var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        return computeHash.SequenceEqual(passwordHash); //we compare this byte by byte with password and returns true or false
        //    }
        //}



    }
}
