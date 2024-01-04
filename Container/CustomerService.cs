using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPINetCore8.Helper;
using WebAPINetCore8.Modal;
using WebAPINetCore8.Repos;
using WebAPINetCore8.Repos.Models;
using WebAPINetCore8.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<APIResponse> Create(CustomerModal data)
        {
            APIResponse response = new APIResponse();
            try
            {
                TblCustomer customer = this._mapper.Map<CustomerModal, TblCustomer>(data);
                await this._context.TblCustomers.AddAsync(customer);
                await this._context.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result = data.Code;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }

            return response;
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

 

        public async Task<APIResponse> Remove(string code)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this._context.TblCustomers.FindAsync(code);
                if (_customer != null)
                {
                    this._context.TblCustomers.Remove(_customer);
                    await this._context.SaveChangesAsync();
                    response.ResponseCode = 201;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Errormessage = "Data not found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> Update(CustomerModal data, string code)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this._context.TblCustomers.FindAsync(code);
                if (_customer != null)
                {
                    _customer.Name = data.Name; 
                    _customer.Email = data.Email;
                    _customer.Phone = data.Phone;
                    _customer.IsActive = data.IsActive;
                    _customer.Creditlimit = data.Creditlimit;
                    await this._context.SaveChangesAsync();
                    response.ResponseCode = 201;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Errormessage = "Data not found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }

            return response;
        }

        public async Task<CustomerModal> Getbycode(string code)
        {
            CustomerModal _response = new CustomerModal();
            var _data = await this._context.TblCustomers.FindAsync(code);
            if (_data != null)
            {
                _response = this._mapper.Map<TblCustomer, CustomerModal>(_data);
            }
            return _response;
        }

     
    }
}
