using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VouViajar.Excursoes.Application.Behaviours;
using VouViajar.Excursoes.Application.Contracts.Infrastructure;
using VouViajar.Excursoes.Infrastructure.Persistence;
using VouViajar.Excursoes.Infrastructure.Repositories;

namespace VouViajar.Excursoes
{
    public static class ExcursaoModuleRegistrationService
    {

        public static IServiceCollection AddExcursaoModuleRegistrationService(this IServiceCollection services)
        {
            #region MediatR

            var assembly = AppDomain.CurrentDomain.Load("VouViajar.Excursoes");
            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            #endregion

            #region Injections
            services.AddDbContext<ExcursaoDbContext>(options => options.UseSqlServer("Server=vouviajar.database.windows.net;Database=vouviajar;User ID=vouviajar;Password=agoravai1@;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            services.AddScoped<IUnitOfWorkExcursao, UnitOfWorkExcursao>();
            services.AddScoped<IExcursaoRepository, ExcursaoRepository>();

            #endregion

            return services;
        }
    }
}
