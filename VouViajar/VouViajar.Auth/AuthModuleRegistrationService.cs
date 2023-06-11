using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VouViajar.Auth.Application.Behaviours;
using VouViajar.Auth.Domain.Services;
using VouViajar.Auth.Domain.Services.Interfaces;
using VouViajar.Auth.Domain.Services.Notificacoes;
using VouViajar.Auth.Infrastructure.Persistence;

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
            services.AddDbContext<UsuarioDbContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=vouviajar;Integrated Security=True"));

            services.AddScoped<INotificador, Notificador>();
            #endregion

            services.AddScoped<IUsuarioAgenciaService, UsuarioAgenciaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
