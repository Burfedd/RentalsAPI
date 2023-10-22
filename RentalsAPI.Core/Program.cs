using Microsoft.EntityFrameworkCore;
using RentalsAPI.Core.Data.Context;
using RentalsAPI.Core.Data.Repositories;
using RentalsAPI.Core.Services;
using RentalsAPI.Core.Suppliers;
using RentalsAPI.Core.Suppliers.BestRentals;
using RentalsAPI.Core.Suppliers.NorthernRentals;
using RentalsAPI.Core.Suppliers.SouthRentals;

namespace RentalsAPI.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
            builder.Services.AddMemoryCache();
            builder.Services.AddDbContext<RentalsContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddTransient<ISupplier, BestRentalsService>();
            builder.Services.AddTransient<ISupplier, SouthRentalsService>();
            builder.Services.AddTransient<ISupplier, NorthernRentalsService>();
            builder.Services.AddTransient<IRentalOffersRepository, RentalOffersRepository>();
            builder.Services.AddTransient<IFetchService, FetchService>();
            builder.Services.AddSingleton<IValidationService, ValidationService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}