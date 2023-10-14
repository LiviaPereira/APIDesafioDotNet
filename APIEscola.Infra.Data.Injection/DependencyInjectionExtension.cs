using APIEscola.Domain.Interfaces.Repository;
using APIEscola.Domain.Interfaces.Services;
using APIEscola.Infra.Data.Repositories;
using APIEscola.Services;
using Microsoft.Extensions.DependencyInjection;

namespace APIEscola.Infra.Data.Injection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            //Services
            services.AddTransient<IAlunoService, AlunoService>();
            services.AddTransient<ITurmaService, TurmaService>();           
            services.AddTransient<IAlunoTurmaService, AlunoTurmaService>();           
            

            //Repositories
            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<ITurmaRepository, TurmaRepository>();
            services.AddTransient<IAlunoTurmaRepository, AlunoTurmaRepository>();
            

            return services;
        }
    }
}