using AutoMapper;
using CoffeSenja.API.Models;
using CoffeSenja.API.ViewModels;

namespace CoffeSenja.API.Utilities
{
    public class BaseService
    {
        public CoffeSenjaContext context;
        public Mapper mapper;
        private readonly IHttpContextAccessor httpContext;
        private readonly IWebHostEnvironment webHost;

        public BaseService(CoffeSenjaContext context, IConfiguration configuration, IHttpContextAccessor httpContext, IWebHostEnvironment webHost, string email)
        {
            this.context = context;
            mapper = new Mapper(config);
            Customers = context.Customers.Where(s => s.Email == email).FirstOrDefault();
            if (Customers == null)
                Customers = new Customer();
            this.httpContext = httpContext;
            this.webHost = webHost;
        }

        public ResponseModel response(int code, string? message = null, object? data = null)
        {
            try
            {
                return new ResponseModel
                {
                    StatusCode = code,
                    Message = message,
                    Data = data
                };
            }
            catch (Exception x)
            {
                return new ResponseModel
                {
                    StatusCode = 500,
                    Message = x.Message,
                    Data = x.InnerException?.Message
                };
            }
        }

        #region Mapper

        public MapperConfiguration config = new MapperConfiguration(s =>
        {
            s.AllowNullCollections = true;
            s.AllowNullDestinationValues = true;
            s.CreateMap<Customer, CustomerViewModel>().ReverseMap();
        });

        #endregion Mapper

        public Customer Customers
        { get; set; }
    }
}