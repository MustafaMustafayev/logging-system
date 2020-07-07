using AutoMapper;
using LogSystem.DTO.AdminDTO.AuthRepoDTO;
using LogSystem.DTO.AdminDTO.CompanyRepoDTO;
using LogSystem.DTO.AdminDTO.CompanyServiceDTO;
using LogSystem.DTO.AdminDTO.LogRepoDTO;
using LogSystem.DTO.AdminDTO.RoleRepoDTO;
using LogSystem.DTO.AdminDTO.ServiceRepoDTO;
using LogSystem.DTO.AdminDTO.UserRepoDTO;
using LogSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogSystem.Core.Utility
{
    public class AdminAutoMapperProfile : Profile
    {
        public AdminAutoMapperProfile()
        {
            CreateMap<User, UsersDTO>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
                .ReverseMap();

            CreateMap<User, UserAddDTO>().ReverseMap();
            CreateMap<Role, RoleFilterDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Company, CompaniesDTO>().ReverseMap();
            CreateMap<Company, CompanyAddDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Company, CompanyFilterDTO>().ReverseMap();

            CreateMap<Service, ServicesDTO>().ReverseMap();
            CreateMap<Service, ServiceAddDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<Service, ServiceFilterDTO>().ReverseMap();

            CreateMap<CompanyService, CompanyServiceAddDTO>().ReverseMap();
            CreateMap<CompanyService, CompanyServiceUpdateDTO>().ReverseMap();

            CreateMap<CompanyService, CompanyServiceDTO>()
                .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Service))
                .ReverseMap();

            CreateMap<CompanyService, CompanyServiceDeleteDTO>().ReverseMap();

            CreateMap<User, LoginDTO>().ReverseMap();

            CreateMap<User, LoginUserDTO>()
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                 .ForMember(dest => dest.UserMail, opt => opt.MapFrom(src => src.UserMail))
                 .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
                 .ForAllOtherMembers(dest => dest.Ignore());

            CreateMap<Request, LogDTO>()
                 .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.RequestId))
                 .ForMember(dest => dest.RequestDate, opt => opt.MapFrom(src => src.RequestDate.ToString("dd-MMM-yyyy hh:mm:ss")))
                 .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyService.Company.CompanyName))
                 .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.CompanyService.Service.ServiceName))
                 .ReverseMap();

            CreateMap<Request, LogIODTO>()
                .ForMember(dest => dest.Input, opt => opt.MapFrom(src => src.RequestBody.Input))
                .ForMember(dest => dest.Output, opt => opt.MapFrom(src => src.RequestBody.Output));


        }
    }
}
