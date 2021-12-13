
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;

namespace Project.Services
{
    public interface IUserService
    {
        // users create update delete
        Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
        Task<User> GetUserByPhone(string phone);
        Task<User> Create(RegisterDtos dto);
        Task<bool> Update(int id, RegisterDtos dto);
        Task<bool> Delete(int id);
    }
}