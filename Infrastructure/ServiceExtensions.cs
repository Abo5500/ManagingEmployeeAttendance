using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddRepositoryInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITimesheetRepository, TimesheetRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
