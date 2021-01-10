using ControleFinanceiro.Business.Interfaces;
using ControleFinanceiro.Business.Notifications;
using ControleFinanceiro.Business.Services;
using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Api.Configuration
{
    public static class DependencyInjectConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ControleFinanceiroContext>();

            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<ILancamentoService, LancamentoService>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<ISubCategoriaRepository, SubCategoriaRepository>();
            services.AddScoped<ISubCategoriaService, SubCategoriaService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();


            return services;
            
        }
    }
}
