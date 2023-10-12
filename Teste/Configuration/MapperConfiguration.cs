using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

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
