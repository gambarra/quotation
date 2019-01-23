using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quotation.Application.Services;
using Quotation.Application.Services.Interfaces;
using Quotation.Domain.Aggregates.CurrencyAgg.Repository;
using Quotation.Domain.Seedwork;
using Quotation.Infra.Data.Repositories;
using Quotation.Infra.Data.Seedwork;
using Quotation.Infra.EventBus;
using Quotation.Infra.Mapper;
using Quotation.Queries.Aggregates.QuotationAgg.Repository;
using System;
using System.Reflection;

namespace Quotation.Infra.Ioc {
    public static class DependencyInjectionExtension {

        public static IServiceCollection AddDependencies(this IServiceCollection services) {

            services
               .AddSingleton<ITypeAdapterFactory, AutoMapperTypeAdapterFactory>()
               .AddSingleton<ITypeAdapter, AutoMapperTypeAdapter>()
               .AddSingleton<IEventBus,MockEventBus>()
               .AddScoped<IUnitOfWork, UnitOfWork>()
               .AddScoped<Context>()

               .AddTransient<ICurrencyRepository, CurrencyRepository>()
               .AddTransient<ICurrencyAppService, CurrencyAppService>()
               .AddTransient<IQuotationQueriesRepository, QuotationQueriesRepository>()
               .AddTransient<IQuotationAppService, QuotationAppService>();


            services
               .AddMediatR(typeof(Entity));

            var sp = services.BuildServiceProvider();
            
            TypeAdapterFactory.SetCurrent(sp.GetService<ITypeAdapterFactory>());
    
            return services;
        }
    }
}
