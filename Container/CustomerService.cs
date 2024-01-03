using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPINetCore8.Modal;
using WebAPINetCore8.Repos;
using WebAPINetCore8.Repos.Models;
using WebAPINetCore8.Service;

namespace WebAPINetCore8.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearndataContext _context;
        private readonly IMapper _mapper;
        public CustomerService(LearndataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<CustomerModal>> Getall()
        {
            List<CustomerModal> _response= new List<CustomerModal>();
            var _data = await this._context.TblCustomers.ToListAsync();
            if (_data != null)
            {
              _response = this._mapper.Map<List<TblCustomer>,List<CustomerModal>>(_data);
            }
            return _response;
        }
    }
}
