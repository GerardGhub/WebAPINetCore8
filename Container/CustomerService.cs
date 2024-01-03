using WebAPINetCore8.Repos;
using WebAPINetCore8.Repos.Models;
using WebAPINetCore8.Service;

namespace WebAPINetCore8.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearndataContext _context;
        public CustomerService(LearndataContext context)
        {
            this._context = context;
        }

        public List<TblCustomer> Getall()
        {
            return this._context.TblCustomers.ToList();
        }
    }
}
