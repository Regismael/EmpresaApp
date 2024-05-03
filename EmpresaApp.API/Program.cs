
using AgendaApp.API.Configurations;
using EmpresaApp.Domain.Interfaces.Repositories;
using EmpresaApp.Domain.Interfaces.Services;
using EmpresaApp.Domain.Services;
using EmpresaApp.Infra.Data.Repositories;
using System.Text.Json.Serialization;

namespace EmpresaApp.API
{
    public class Program
    {


        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
             options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            CorsConfiguration.Configure(builder.Services);


            builder.Services.AddTransient<IEmpresaDomainService, EmpresaDomainService>();
            builder.Services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();
            builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            builder.Services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors(CorsConfiguration.PolicyName);
            app.Run();
        }
    }
}
