using Microsoft.EntityFrameworkCore;
using NoteAPI.Data;
using NoteAPI.ExceptionHandling;
using NoteAPI.Services;
using System.Reflection;
using CollectionAPI.Services;
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
                    options.UseSqlite(builder.Configuration.GetSection("ConnectionStrings")["Default"]));
            }
            else
            {
                builder.Services.AddDbContext<AppDBContext>(options =>
                    options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTIONSTRING")));
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

            // Apply pending migrations
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbContext = services.GetRequiredService<AppDBContext>(); 
                    dbContext.Database.Migrate(); 
                }
                catch (Exception)
                {
                    throw;
                }
            }

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