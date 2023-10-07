
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
            builder.Services.AddDbContext<AppDBContext>(options => 
            options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["SQLServerConnection"]));

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

            #endregion





            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
               
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandlingMiddleWare>();

            app.MapControllers();

            app.Run();
        }
       
    }
}