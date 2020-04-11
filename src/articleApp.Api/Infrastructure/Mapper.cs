using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace articleApp.Api.Infrastructure
{
    public static class Mapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}