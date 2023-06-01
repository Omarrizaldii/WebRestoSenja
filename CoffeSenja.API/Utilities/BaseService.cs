using CoffeSenja.API.Models;

namespace CoffeSenja.API.Utilities
{
    public class BaseService
    {
        public CoffeSenjaContext context;
        private readonly IHttpContextAccessor httpContext;
        private readonly IWebHostEnvironment webHost;

        public BaseService(CoffeSenjaContext context, IConfiguration configuration, IHttpContextAccessor httpContext, IWebHostEnvironment webHost, string email)
        {
            this.context = context;
            Customers = context.Customers.Where(s => s.Email == email).FirstOrDefault();
            if (Customers == null)
                Customers = new Customer();
            this.httpContext = httpContext;
            this.webHost = webHost;
        }

        public ResponseCode response(int code, string? message, object? data)
        {
            try
            {
                return new ResponseCode
                {
                    StatusCode = code,
                    Message = message,
                    Data = data
                };
            }
            catch (Exception x)
            {
                return new ResponseCode
                {
                    StatusCode = 500,
                    Message = x.Message,
                    Data = x.InnerException?.Message
                };
            }
        }

        public Customer Customers
        { get; set; }
    }
}