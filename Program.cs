
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NoteAPI.Data;
using NoteAPI.ExceptionHandling;
using NoteAPI.Domain;
using NoteAPI.Repositories;
using NoteAPI.Services;
using System.Globalization;
using System.Reflection;
using NoteAPI.Controllers;

namespace NoteAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<NoteDataContext>(options => 
            options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["SQLServerConnection"]));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddScoped<INoteService, NoteService>();
            builder.Services.AddScoped<INoteRepository, NoteRepository>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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