using erecruta.Interface;
using erecruta.Repository;
using erecruta.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection services)
        {            
            services.AddSingleton<IOportunidadeService, OportunidadeService>();
            services.AddSingleton<IOportunidadeRepository, OportunidadeRepository>();
            services.AddSingleton<IOportunidadeNivelRepository, OportunidadeNivelRepository>();
            services.AddSingleton<INivelRepository, NivelRepository>();
            services.AddSingleton<ICandidatoService, CandidatoService>();
            services.AddSingleton<ICandidatoRepository, CandidatoRepository>();
            services.AddSingleton<IIBGEService, IBGEService>();
            services.AddSingleton<IIBGERepository, IBGERepository>();
            return services;
        }
    }
}
