using AutoMapper;
using WebAPINetCore8.Helper;
using WebAPINetCore8.Modal;
using WebAPINetCore8.Repos;
using WebAPINetCore8.Repos.Models;
using WebAPINetCore8.Service;

namespace WebAPINetCore8.Container
{
    public class UserService : IUserService
    {
        private readonly LearndataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        public UserService(LearndataContext context, IMapper mapper, ILogger<UserService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<APIResponse> Create(UserModal data)
        {
            APIResponse response = new APIResponse();
            try
            {
                this._logger.LogInformation("Create new User");
                TblUser user = this._mapper.Map<UserModal, TblUser>(data);

                await this._context.TblUsers.AddAsync(user);

                await this._context.SaveChangesAsync();

                response.ResponseCode = 201;
                response.Result = data.Code;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
                this._logger.LogError(ex.Message, ex);
            }

            return response;
        }

        public Task<List<UserModal>> Getall()
        {
            throw new NotImplementedException();
        }

        public Task<UserModal> Getbycode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> Remove(string code)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> Update(UserModal data, string code)
        {
            throw new NotImplementedException();
        }
    }
}
