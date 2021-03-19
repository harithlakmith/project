using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TranspotationTicketBooking.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using TranspotationTicketBooking.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TranspotationTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfigurationSection _jwtSettings;
        private readonly TicketBookingDBContext db;
        private readonly object dataa;
        private readonly object sessions;

        public AccountsController(IMapper mapper, UserManager<User> userManager, IConfiguration configuration, TicketBookingDBContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtSettings = configuration.GetSection("JwtSettings");
            db = context;
        }


        [HttpGet("Test")]  //api/Accounts/Test
        public String Test()
        {
            return "accounts controller!!!";
        }

        //  [EnableCors("*", "*", "*")]
        [HttpGet("Home")]
        public String Home()
        {
            return "Transportation Ticket Booking System";
        }

        [HttpPost("PassengerRegister")]  // api/Accounts/PassengerRegister
        public async Task<ActionResult> Register(UserRegistrationModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var passenger = _mapper.Map<Passenger>(userModel);

            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                return Ok(result.Errors);
            }
            await _userManager.AddToRoleAsync(user, "Passenger");

            db.Passenger.Add(passenger);
            db.SaveChanges();

            return StatusCode(201);
        }


        [HttpPost("AdminRegister")]  // api/Accounts/AdminRegister
        public async Task<ActionResult> AdminRegister(UserRegistrationModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                return Ok(result.Errors);
            }
            await _userManager.AddToRoleAsync(user, "Administrator");
            return StatusCode(201);
        }

        [HttpPost("BusControllerRegister")]  // api/Accounts/BusControllerRegister
        public async Task<ActionResult> BusControllerRegister(UserRegistrationModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var BusController = _mapper.Map<BusInfo>(userModel);

            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                return Ok(result.Errors);
            }
            await _userManager.AddToRoleAsync(user, "BusController");

            db.BusInfo.Add(BusController);
            db.SaveChanges();

            return StatusCode(201);
        }
        [HttpPost("Login")] // api/Accounts/Login
        public async Task<IActionResult> Login(UserLoginModel userModel)
        {
            var user = await _userManager.FindByEmailAsync(userModel.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, userModel.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);//***

                var signingCredentials = GetSigningCredentials();
                var claims = GetClaims(user);
                var tokenOptions = GenerateTokenOptions(signingCredentials, await claims);
                //var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                    role = roles, data = user,
                });
            }
            return Unauthorized("Invalid Authentication");

        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims )
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                audience: _jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }


    }
}
