﻿using Account.Domain.Interfaces;
using Account.Infrastructure.Authentication;
using Account.Infrastructure.Db;
using Account.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime;

namespace Account.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

            services.AddSingleton<IJwtProvider, JwtProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
