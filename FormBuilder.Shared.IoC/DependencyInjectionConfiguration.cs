using FormBuilder.Core.Application.AppService;
using FormBuilder.Core.Application.AppService.Interfaces;
using FormBuilder.Core.Data.DbContexts;
using FormBuilder.Core.Data.Repositories.Forms;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;
using FormBuilder.Core.Domain.Interfaces.Services.Forms;
using FormBuilder.Core.Domain.Services.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace FormBuilder.Shared.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(DbContextCore));
            
            services.AddTransient<IFormBuildService, FormBuildService>();
            services.AddTransient<IFormResponseService, FormResponseService>();

            services.AddTransient<IFormBuildRepository, FormBuildRepository>();
            services.AddTransient<IFormResponseRepository, FormResponseRepository>();

            services.AddTransient<IFormBuildQueryAppService, FormBuildQueryAppService>();
        }
    }
}
