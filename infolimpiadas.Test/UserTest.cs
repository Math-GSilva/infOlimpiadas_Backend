using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using infolimpiadas.API.Controllers;
using infolimpiadas.Domain.Entity;
using infolimpiadas.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moq;
using Xunit;

namespace infolimpiadas.Tests
{
    public class UserTest
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly UsuarioController _controller;

        public UserTest()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _mockConfiguration = new Mock<IConfiguration>();

            _mockConfiguration.SetupGet(config => config["Jwt:Key"]).Returns("supersecretkey");

            _controller = new UsuarioController(_mockUsuarioService.Object, _mockConfiguration.Object);
        }

        [Fact]
        public void Add_ReturnsOkResult_WithAddedUsuario()
        {
            // Arrange
            var usuario = new Usuario { Id = 1, Nome = "João", Sobrenome = "Silva", Email = "joao@example.com", Password = "password123" };
            _mockUsuarioService.Setup(service => service.SaveUsuario(usuario)).Returns(usuario);

            // Act
            var result = _controller.Add(usuario);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Usuario>(okResult.Value);
            Assert.Equal(usuario.Id, returnValue.Id);
        }

        [Fact]
        public async Task Login_ReturnsOkResult_WithJwtToken_WhenValid()
        {
            // Arrange
            var login = new LoginRequestCommand { Email = "ms221103@gmail.com", Password = "123456" };
            _mockUsuarioService.Setup(service => service.Login(login)).ReturnsAsync(true);

            // Act
            var result = await _controller.Login(login);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var token = Assert.IsType<string>(okResult.Value);

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            Assert.NotNull(jsonToken);
            Assert.Contains(jsonToken.Claims, c => c.Type == "user" && c.Value == login.Email);
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_WhenInvalid()
        {
            // Arrange
            var login = new LoginRequestCommand { Email = "joao@example.com", Password = "wrongpassword" };
            _mockUsuarioService.Setup(service => service.Login(login)).ReturnsAsync(false);

            // Act
            var result = await _controller.Login(login);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public void ValidateToken_ReturnsOkResult_WhenTokenIsValid()
        {
            // Arrange
            var token = GenerateTestJwtToken("joao@example.com");

            // Act
            var result = _controller.ValidataToken(token);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public void ValidateToken_ReturnsUnauthorized_WhenTokenIsInvalid()
        {
            // Arrange
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

            // Act
            var result = _controller.ValidataToken(token);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        private string GenerateTestJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim("user", username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretkey1asdasdasdasdsdfsdarfgdsfg2345678"));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(5);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
