
using Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Authentication
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

            #region Database

            var connectionString = builder.Configuration.GetConnectionString("cs");
            builder.Services.AddDbContext<ContextDb>(options =>
                options.UseSqlServer(connectionString));

            #endregion

            #region Identity Managers

            builder.Services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ContextDb>();

            #endregion


            #region Authentication Scheme

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "db";
                options.DefaultChallengeScheme = "db";
            })
            .AddJwtBearer("db", options =>
            {
                var secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
                var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
                var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            #endregion


            #region Authorization

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy
                    .RequireClaim(ClaimTypes.Role, "Admin", "Manager", "CEO")
                    .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy("User", policy => policy
                    .RequireClaim(ClaimTypes.Role, "User", "Client")
                    .RequireClaim(ClaimTypes.NameIdentifier));
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}