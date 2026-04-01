using Business.Profiles;
using Business.Services;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class IOC
    {
        public static IServiceCollection AddCustomServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShopContext>(opt => opt.UseSqlite(configuration.GetConnectionString("shop_db")));

            services.AddIdentity<Customer, IdentityRole>()
                    .AddEntityFrameworkStores<ShopContext>()
                    .AddDefaultTokenProviders();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ShowroomProfiles>();
                cfg.AddProfile<AuthProfiles>();
                cfg.AddProfile<ShopProfiles>();
                cfg.AddProfile<OrderProfiles>();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IShowroomService, ShowroomService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        } 
    }
}
