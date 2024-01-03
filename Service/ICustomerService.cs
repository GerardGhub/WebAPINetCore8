
using WebAPINetCore8.Modal;
using WebAPINetCore8.Repos.Models;

namespace WebAPINetCore8.Service
{
    public interface ICustomerService
    {
        Task<List<CustomerModal>> Getall();
    }
}
