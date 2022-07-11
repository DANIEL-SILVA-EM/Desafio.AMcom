using Desafio.AMcom.Model;
using Desafio.AMcom.Services;
using Desafio.AMcom.Services.Interfaces;
using Refit;
using System.Collections.Generic;
using Xunit;

namespace Desafio.AMcom.Testes.IntegrationService
{
    public class UsersWebServiceTeste
    {
        private readonly IReqresUsersService _webService;

        public UsersWebServiceTeste()
        {
            const string urlbase = "https://reqres.in";
            _webService = new ReqresUsersService(urlbase);
        }

        [Fact]
        public async void ObtenhaUsuarios()
        {
            IEnumerable<UserModel> users = await _webService.GetUsers(page: 2, perPage: 6);

            Assert.NotEmpty(users);
            UserModel user = new()
            {
                Id = 7,
                Email = "michael.lawson@reqres.in",
                FirstName = "Michael",
                LastName = "Lawson",
                Avatar = "https://reqres.in/img/faces/7-image.jpg"
            };

            Assert.Contains(user, users);
        }
    }
}
