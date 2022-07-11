using Desafio.AMcom.Model;
using Desafio.AMcom.Services.Interfaces;
using Polly;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desafio.AMcom.Services
{
    public class ReqresUsersService : IReqresUsersService
    {
        private readonly IReqresUsersServiceContext _webService;

        public ReqresUsersService(string urlbase)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            _webService = RestService.For<IReqresUsersServiceContext>(urlbase, new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(options)
            });
        }

        public async Task<IEnumerable<UserModel>> GetUsers(int page = 1, int perPage = 6)
        {
            var policy = Policy.Handle<HttpRequestException>()
                               .WaitAndRetryAsync(new[] {
                                   TimeSpan.FromSeconds(1), 
                                   TimeSpan.FromSeconds(2), 
                                   TimeSpan.FromSeconds(4)
                               });

            var response = await policy.ExecuteAsync(async () => await _webService.GetDataUsers(page, perPage));

            return response.Users;
        }
    }
}
