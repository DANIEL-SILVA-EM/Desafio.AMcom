using Desafio.AMcom.Model;
using Refit;
using System.Threading.Tasks;

namespace Desafio.AMcom.Services.Interfaces
{
    public interface IReqresUsersServiceContext
    {
        [Get("/api/users")]
        Task<PageUsersModel> GetDataUsers(int page, [AliasAs("per_page")] int perPage);
    }
}
