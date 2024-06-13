using WebAPINetCore8.Helper;
using WebAPINetCore8.Modal;

namespace WebAPINetCore8.Service
{
    public interface IUserService
    {
        Task<List<UserModal>> Getall();
        Task<UserModal> Getbycode(string code);
        Task<APIResponse> Remove(string code);
        Task<APIResponse> Create(UserModal data);
        Task<APIResponse> Update(UserModal data, string code);
    }
}
