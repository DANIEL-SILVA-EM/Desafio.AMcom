using Desafio.AMcom.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.AMcom.Services.Interfaces
{
    public interface IReqresUsersService
    {
        public Task<IEnumerable<UserModel>> GetUsers(int page, int perPage);
    }
}