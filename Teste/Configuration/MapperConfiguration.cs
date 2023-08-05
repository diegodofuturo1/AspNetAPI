using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Service.Dtos;

namespace Teste.Configuration
{
    public static class TesteMapperConfiguration
    {
        public static IMapper GetConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>()
                    .ReverseMap();

                //cfg.CreateMap<CreateBuilderViewModel, UserDto>()
                //    .ReverseMap();

                //cfg.CreateMap<UpdateBuilderViewModel, UserDto>()
                //    .ReverseMap();
            });

            return autoMapperConfig.CreateMapper();
        }
    }
}
