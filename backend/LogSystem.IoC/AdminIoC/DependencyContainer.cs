using AutoMapper;
using FluentValidation.AspNetCore;
using LogSystem.BLL.AdminBLL.AuthRepoBLL;
using LogSystem.BLL.AdminBLL.CompanyRepoBLL;
using LogSystem.BLL.AdminBLL.CompanyServiceRepoBLL;
using LogSystem.BLL.AdminBLL.LogRepoBLL;
using LogSystem.BLL.AdminBLL.ServiceRepoBLL;
using LogSystem.BLL.AdminBLL.UserRepoBLL;
using LogSystem.Core.Utility;
using LogSystem.DAL.AdminBLL.RoleRepoBLL;
using LogSystem.DAL.AdminDAL.AuthRepoBLL;
using LogSystem.DAL.AdminDAL.CompanRepoDAL;
using LogSystem.DAL.AdminDAL.CompanyServiceRepoDAL;
using LogSystem.DAL.AdminDAL.LogRepoDAL;
using LogSystem.DAL.AdminDAL.RoleRepoDAL;
using LogSystem.DAL.AdminDAL.ServiceRepoDAL;
using LogSystem.DAL.AdminDAL.UserRepoDAL;
using LogSystem.DTO.AdminDTO.AuthRepoDTO;
using LogSystem.DTO.AdminDTO.CompanyRepoDTO;
using LogSystem.DTO.AdminDTO.CompanyServiceDTO;
using LogSystem.DTO.AdminDTO.ServiceRepoDTO;
using LogSystem.DTO.AdminDTO.UserRepoDTO;
using LogSystem.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace LogSystem.IoC.AdminIoC
{
    public class DependencyContainer
    {
        public DependencyContainer(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly IConfiguration Configuration;
        public void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AdminAutoMapperProfile));

            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<IUserDAL, UserDAL>();

            services.AddScoped<IRoleBLL, RoleBLL>();
            services.AddScoped<IRoleDAL, RoleDAL>();

            services.AddScoped<ICompanyBLL, CompanyBLL>();
            services.AddScoped<ICompanyDAL, CompanyDAL>();

            services.AddScoped<IServiceBLL, ServiceBLL>();
            services.AddScoped<IServiceDAL, ServiceDAL>();

            services.AddScoped<ICompanyServiceBLL, CompanyServiceBLL>();
            services.AddScoped<ICompanyServiceDAL, CompanyServiceDAL>();

            services.AddScoped<IAuthBLL, AuthBLL>();
            services.AddScoped<IAuthDAL, AuthDAL>();

            services.AddScoped<ILogBLL, LogBLL>();
            services.AddScoped<ILogDAL, LogDAL>();

            services.AddScoped<IUtil, Util>();

            services.AddDbContext<LogContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LogDB"));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("JWTSettings:SecretKey").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LogSystemAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
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

            services.AddControllers()
            .AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining(typeof(LoginDTOValidator));
                opt.RegisterValidatorsFromAssemblyContaining(typeof(CompanyAddDTOValidator));
                opt.RegisterValidatorsFromAssemblyContaining(typeof(CompanyDTOValidator));
                opt.RegisterValidatorsFromAssemblyContaining(typeof(CompanyServiceAddDTOValidator));
                opt.RegisterValidatorsFromAssemblyContaining(typeof(CompanyServiceDeleteDTOValidator));
                opt.RegisterValidatorsFromAssemblyContaining(typeof(CompanyServiceUpdateDTOValidator));
                opt.RegisterValidatorsFromAssemblyContaining(typeof(ServiceAddDTOValidator));
                opt.RegisterValidatorsFromAssemblyContaining(typeof(ServiceDTOValidator));
                opt.RegisterValidatorsFromAssemblyContaining(typeof(UserAddDTOValidator));
                opt.RegisterValidatorsFromAssemblyContaining(typeof(UpdatePasswordDTOValidator));
                opt.RegisterValidatorsFromAssemblyContaining(typeof(UserDTOValidator));
            });
        }
    }
}
