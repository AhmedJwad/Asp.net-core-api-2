using Asp.net_core_api.Data;
using Asp.net_core_api.Model;
using AspcoreApi.share;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Asp.net_core_api.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class PassengeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public PassengeController(DataContext context, IConfiguration configuration)
        {
            _context = context;
           _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
         var model=  await _context.passengers.ToListAsync();
            return Ok(model);
        }
        [HttpPost("PhonenumberandRating")]        
        public async Task<IActionResult> PhonenumberandRating(phonenumberandratingModel model)
        {
            //var response = await _context.passengers.FirstOrDefaultAsync(x=>x.Pass_PhoneNumber==model.Pass_PhoneNumber &&
            //x.Pass_Rating==model.Pass_Rating);
            var aa = (from initel in _context.passengers where initel.Pass_PhoneNumber == model.Pass_PhoneNumber select initel).FirstOrDefault();
            return Ok(aa);
        }
        [HttpPost("GetAsyncAutho")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAsyncAutho()
        {
            var model = await _context.passengers.ToListAsync();
            return Ok(model);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var passenger = _context.passengers
                .FirstOrDefault(p => p.Pass_PhoneNumber == model.Pass_PhoneNumber && p.Pass_Password == model.Pass_Password);

            if (passenger == null)
                return Unauthorized();

            // Generate JWT token here

            return Ok(BuildToken(passenger));
        }

        private TokenDTO BuildToken(passengers passenger)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, passenger.Pass_FristName!),              
                new Claim("Pass_FristName", passenger.Pass_FristName),
                new Claim("Pass_SecondName", passenger.Pass_LastName),
                new Claim("Pass_SecondName", passenger.Pass_PhoneNumber.ToString()),
                new Claim("Pass_GenderM", passenger.Pass_GenderM.ToString()),
                new Claim("Pass_BirthDate", passenger.Pass_BirthDate.ToString()),
                
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]!));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(30);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credential

                );
            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
            };
        }

        [HttpPost("signup")]
        public async Task<IActionResult> signup([FromBody] PassengerModel model)
        {
            var passenger = new passengers
            {
                created_at = DateTime.Now,
                Pass_Flags = 0,
                Pass_BirthDate=model.Pass_BirthDate,
                email_verified_at = DateTime.Now,
                Pass_FristName=model.Pass_FristName,
                Pass_Balance=model.Pass_Balance,
                Pass_GenderM=model.Pass_GenderM,
                Pass_languge=model.Pass_languge,
                Pass_LastName=model.Pass_LastName,
                Pass_Password=model.Pass_Password,
                Pass_PhoneNumber=model.Pass_PhoneNumber,
                Pass_Rank=model.Pass_Rank,
                Pass_Rating=model.Pass_Rating,
                Pass_SecondName=model.Pass_SecondName,
                Pass_Status=model.Pass_Status,
                updated_at= DateTime.Now,

            };
            _context.Add(passenger);
            await _context.SaveChangesAsync();
            return Ok("success");            

        }
    }
}
