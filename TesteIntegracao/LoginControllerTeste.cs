using ChapterSenai.Controllers;
using ChapterSenai.Interfaces;
using ChapterSenai.Models;
using ChapterSenai.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.IdentityModel.Tokens.Jwt;

namespace TesteIntegracao
{
    public class LoginControllerTeste
    {
        [Fact]
        public void LoginController_Retorna_Usuario_Invalido()
        {
            //Arrange - Preparação
            var repositoryEspelhado = new Mock<IUsuarioRepository>();

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            var controller = new LoginController(repositoryEspelhado.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "Carlos@email.com";
            dadosUsuario.senha = "Carlos";

            //Act - Ação
            var resultado = controller.Login(dadosUsuario);

            //Assert - Verificação
            Assert.IsType<UnauthorizedObjectResult>(resultado);

        }

        [Fact]

        public void LoginController_Retornar_Token()
        {
            //Arrange´- Preparação

            Usuario usuarioRetornado = new Usuario();

            usuarioRetornado.Email = "email@email.com";
            usuarioRetornado.Senha = "1234";
            usuarioRetornado.Tipo = "0";
            usuarioRetornado.Id = 1;

            var repositoryEspelhado = new Mock<IUsuarioRepository>();

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetornado);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "Carlos@email.com";
            dadosUsuario.senha = "Carlos";

            var controller = new LoginController(repositoryEspelhado.Object);
            string issuervalido = "chapter.webapi";


            // Act - Ação

            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);
            string tokenString = resultado.Value.ToString().Split(' ')[3];

            var jwtHandler = new JwtSecurityTokenHandler();

            var tokenJwt = jwtHandler.ReadJwtToken(tokenString);

            //Assert - Verificação
            Assert.Equal(issuervalido, tokenJwt.Issuer);



        }

    }
}