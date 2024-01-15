using BlazorServerApp.Domain.Models;

namespace BlazorServerApp.Client.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
    }
}