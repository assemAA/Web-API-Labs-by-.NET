
using Microsoft.EntityFrameworkCore;
using Tickets.BL.Managers.DepartementMangaer;
using Tickets.BL.Managers.TicketManager;
using Tickets.DAL.Context;
using Tickets.DAL.Models;
using Tickets.DAL.Repos;

namespace Tickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("TicketsDb");
            builder.Services.AddDbContext<TicketsContext>(
                        options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IContextRepo<Departement>, DepartementRepo>();
            builder.Services.AddScoped<IContextRepo<Ticket> , TicketRepo>();
            builder.Services.AddScoped<IContextRepo<Devaloper> , DevaloperRepo>();



            builder.Services.AddScoped<ITicketManager , TicketManager>();
            builder.Services.AddScoped<IDepartementManager , DepartementManager>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
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