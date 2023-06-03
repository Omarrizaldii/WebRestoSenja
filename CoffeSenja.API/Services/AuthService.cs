using CoffeSenja.API.Models;
using CoffeSenja.API.Utilities;
using CoffeSenja.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoffeSenja.API.Services
{
    public class AuthService : BaseService
    {
        private readonly IConfiguration configuration;
        private CoffeSenjaContext context;

        public AuthService(CoffeSenjaContext context, IConfiguration configuration, IHttpContextAccessor httpContext, IWebHostEnvironment webHost, string email) : base(context, configuration, httpContext, webHost, email)
        {
            this.configuration = configuration;
            this.context = context;
        }

        public async Task<ResponseModel> LoginAsync(AuthViewModel request)
        {
            try
            {
                var checkCustomer = await context.Customers.Where(s => s.Email == request.Email && s.Password == request.Password).FirstOrDefaultAsync();
                if (checkCustomer == null)
                    return response(404, "Customer not found");

                var claim = new[]
                {
                    new Claim("Email",checkCustomer.Email),
                    new Claim("CustomerId", checkCustomer.Id.ToString())
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(10);
                var token = new JwtSecurityToken(
                    audience: configuration["Jwt:Audience"],
                    issuer: configuration["Jwt:Issuer"],
                    claims: claim,
                    expires: expires,
                    signingCredentials: sign);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return response(200, data: jwt);
            }
            catch (Exception x)
            {
                return response(500, x?.Message, x.InnerException?.Message);
            }
        }
    }
}