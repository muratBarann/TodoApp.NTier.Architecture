using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.Business.Mappings.AutoMapper;
using Udemy.TodoAppNTier.Business.Services;
using Udemy.TodoAppNTier.Business.ValidationRules;
using Udemy.TodoAppNTier.DataAccess.Contexts;
using Udemy.TodoAppNTier.DataAccess.UnitOfWork;
using Udemy.TodoAppNTier.Dtos.WorkDtos;

namespace Udemy.TodoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        //Burada IServiceCollection sınıfını genişletip UI katmanında Business katmanı üzerinden dataAccess'e ulaşmaya
        //Çalışacağız Extension yazarak bunu halledeceğiz.

        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\mssqllocaldb; database=TodoDb; integrated security=true;");
                //Entity alanındaki Logları izlemek için Yazıldı
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();

            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();
        }


    }
}
