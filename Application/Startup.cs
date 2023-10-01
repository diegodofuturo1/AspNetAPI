using System;
using AutoMapper;
using System.Text;
using Service.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Service.Services;
using Application.Token;
using Service.Interfaces;
using Infrastructure.Contexts;
using Microsoft.OpenApi.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.ViewModels;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(config => Configuration);

            #region Jwt

            var secretKey = Configuration["Jwt:Key"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion

            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDto>().ReverseMap();
                config.CreateMap<User, SignupViewModel>().ReverseMap();
                config.CreateMap<CreateUserViewModel, UserDto>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

      #endregion

      #region Database

      //services.AddDbContext<ApiContext>(options => options
      //    .UseSqlServer(Configuration["ConnectionStrings:SqlServer"])
      //    .EnableSensitiveDataLogging()
      //    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())),
      //ServiceLifetime.Transient);

      #endregion

      #region Repositories

      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IBuilderRepository, BuilderRepository>();
      services.AddScoped<IContributionRepository, ContributionRepository>();
      services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
      services.AddScoped<IInvestorRepository, InvestorRepository>();
      services.AddScoped<IWalletRepository, WalletRepository>();

      #endregion

      #region Services

      services.AddScoped<IUserService, UserService>();
      services.AddScoped<ITokenService, TokenService>();
      services.AddScoped<IBuilderService, BuilderService>();
      services.AddScoped<IContributionService, ContributionService>();
      services.AddScoped<IEnterpriseService, EnterpriseService>();
      services.AddScoped<IInvestorService, InvestorService>();
      services.AddScoped<IWalletService, WalletService>();

      #endregion

      #region Swagger

      services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1",
                    Description = "Aqui está uma breve descrição da API",
                    Contact = new OpenApiContact
                    {
                        Name = "Diego Heleno",
                        Email = "diegodofuturo1@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/diego-heleno-3b4615152/")
                    },
                });

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor utilize Bearer <TOKEN>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                config.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manager.API v1"));

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
