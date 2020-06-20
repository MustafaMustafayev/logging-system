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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LogSystem.IoC.AdminIoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
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
