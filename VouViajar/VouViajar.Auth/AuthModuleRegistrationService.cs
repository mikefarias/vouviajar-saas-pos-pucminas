using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VouViajar.Auth.Application.Behaviours;
using VouViajar.Auth.Application.Contracts.Infrastructure;
using VouViajar.Auth.Domain.Services;
using VouViajar.Auth.Domain.Services.Interfaces;
using VouViajar.Auth.Domain.Services.Notificacoes;
using VouViajar.Auth.Infrastructure.Persistence;
using VouViajar.Auth.Infrastructure.Repositories;

namespace VouViajar.Auth
{
    public static class AuthModuleRegistrationService
    {
        public static IServiceCollection AddAuthModuleRegistrationService(this IServiceCollection services, IConfiguration configuration)
        {
            #region MediatR

            var assembly = AppDomain.CurrentDomain.Load("VouViajar.Auth");
            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            #endregion

            #region Injections
            services.AddIdentityConfiguration(configuration);
            services.AddDbContext<UsuarioDbContext>(options => options.UseSqlServer("\"Server=vouviajar.database.windows.net;Database=vouviajar;User ID=vouviajar;Password=agoravai1@;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False\""));

            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IUsuarioAgenciaService, UsuarioAgenciaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            
            services.AddScoped<IAgenciaRepository, AgenciaRepository>();

            #endregion

            return services;
        }
    }
}
