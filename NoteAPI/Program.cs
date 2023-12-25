
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NoteAPI.Data;
using NoteAPI.ExceptionHandling;
using NoteAPI.Domain;
using NoteAPI.Services;
using System.Globalization;
using System.Reflection;
using NoteAPI.Controllers;
using CollectionAPI.Services;
using NoteAPI.Validators;
using Azure.Core;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using NoteAPI.Repositories.Abstract;
using NoteAPI.Repositories.Concrete;

namespace NoteAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            #region Custom
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<AppDBContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["Default"]));
            }
            else
            {
                builder.Services.AddDbContext<AppDBContext>(options =>
                    options.UseSqlServer(Environment.GetEnvironmentVariable("GOOGLE_SQL_CONNECTIONSTRING")));
            }
            

            builder.Services.AddScoped<INoteService, NoteService>();
            builder.Services.AddScoped<INoteRepository, NoteRepository>();
            builder.Services.AddScoped<ICollectionService, CollectionService>();
            builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();

            #endregion

            #region 3rd Party
            
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            #endregion


            #region App

           

            builder.Services.AddControllers();

            builder.Services.AddCors( options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin().
                           AllowAnyHeader().
                           AllowAnyMethod();
                });
            });

            #endregion





            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
               app.UseCors();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandlingMiddleWare>();

            app.MapControllers();

            app.Run();
        }
       
    }
}