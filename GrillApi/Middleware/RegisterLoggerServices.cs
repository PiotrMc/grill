using Domain.Models;
using GrillApi.Controllers;
using Logger.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrillApi.Middleware
{
    public static class RegisterLoggerServices
    {
        public static IServiceCollection AddLoggers(this IServiceCollection services)
        {
            services.AddLogger<ConsumersController>();
            services.AddLogger<ParticipantsController>();
            services.AddLogger<EventsController>();
            return services;
        }
    }
}
