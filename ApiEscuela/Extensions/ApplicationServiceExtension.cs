using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.UnitOfWork;
using Domain.Interfaces;

namespace ApiEscuela.Extensions;
public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });
    public static void AddAplicacionServices(this IServiceCollection services)
        {
            //In case to need a Repo that isn't contained in UnitOfWork, remove comment
            //Services.AddScoped<IpaisInterface,PaisRepository>();
            //Services.AddScoped<ITipoPersona,TipoPeronsaRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
}