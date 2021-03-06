using AutoMapper;
using BL;
using DL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;//gf
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTravelAgent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("key").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddScoped<IOrderBL,orderBL>();
            services.AddScoped<IOrderDL,orderDL>();
            services.AddScoped<ICustomerBL,customerBL>();
            services.AddScoped<ICustomerDL,customerDL>();
            services.AddScoped<IAlertBL,AlertBL>();
            services.AddScoped<IAlertDL,AlertDL>();
            services.AddScoped<IHotelBL, HotelBL>();
            services.AddScoped<IHotelDL, HotelDL>();
            services.AddScoped<IBookingBL, BookingBL>();
            services.AddScoped<IAdminBL, AdminBL>();
            services.AddScoped<IAdminDL,AdminDL>();
            services.AddScoped<IPasswordHashHelper, PasswordHashHelper>();
            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNameCaseInsensitive =true);
           // services.AddMvc().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyTravelAgent", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
            services.AddDbContext<MyTravelAgent2Context>(options => options.UseSqlServer(
            Configuration.GetConnectionString("Home")));
            //"Server=DESKTOP-R5RADSP;Database=MyTravelAgent2;Trusted_Connection=True;"), ServiceLifetime.Scoped);
            //(LocalDB)\\MSSQLLocalDB;Database=https:\\github.com\\myTravelAgentProject\\good.git\\DL\\DB.mdf
            services.AddResponseCaching();          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup>logger)
        { 
            logger.LogInformation("server is up:)");

            app.UseErrorsMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyTravelAgent v1"));
            }
            app.UseResponseCaching();

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(1)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                context.Response.Headers.Add(
                    "Content-Security-Policy",
                    "script-src 'self'; " +
                    "style-src 'self' ; " +
                    "img-src 'self'");

                await next();
            });

            app.UseStaticFiles();
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();


            app.Map("/api", app2 =>
            {
                app2.UseAuthentication();
                app2.UseRouting();
                app2.UseRatingMiddleware();
                app2.UseAuthorization();

                app2.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });


            app.UseAuthorization();
  

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
    }
}
