using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrillApi.Middleware
{
    public static class RegisterRepositoryServices
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Consumer>, Repository<Consumer>>(); //Dependency Injection  
            services.AddTransient<IRepository<Event>, Repository<Event>>(); //Dependency Injection  
            services.AddTransient<IRepository<Participant>, Repository<Participant>>(); //Dependency Injection  
            return services;
        }
    }
}
