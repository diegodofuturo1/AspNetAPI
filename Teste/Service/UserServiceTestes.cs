using Moq;
using Xunit;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Service.Services;
using Service.Interfaces;
using System.Threading.Tasks;

namespace Teste.Service
{
    public class UserServiceTestes
    {
        private readonly IUserService service;

        private readonly IMapper mapper;
        private readonly Mock<IUserRepository> repository;

        public UserServiceTestes()
        {
            mapper = Configuration.TesteMapperConfiguration.GetConfiguration();
            repository = new Mock<IUserRepository>();

            service = new UserService(mapper, repository.Object);
        }

        [Fact]
        public async Task Create_WhenUserIsValid_ReturnsUserDto()
        {
            var userDto = Fixture.UserFixture.GetValidUserDto();
            var user = mapper.Map<User>(userDto);

            repository.Setup(r => r.InsertAsync(It.IsAny<User>())).ReturnsAsync(() => user);

            var result = await service.CreateAsync(userDto);

            userDto.Password = "***********";

            Assert.Equal(result.Name, userDto.Name);
            Assert.Equal(result.Email, userDto.Email);
            Assert.Equal(result.Password, userDto.Password);
        }
    }
}
