using AutoMapper;
using WebAPINetCore8.Modal;
using WebAPINetCore8.Repos.Models;

namespace WebAPINetCore8.Helper
{
    public class AutoMapperHandler: Profile
    {
        public AutoMapperHandler() {
            CreateMap<TblCustomer, CustomerModal>().ForMember(item => item.Statusname, opt => opt.MapFrom(
                item => (item.IsActive != null && item.IsActive.Value) ? "Active" : "In active")).ReverseMap();

            CreateMap<TblUser, UserModal>().ForMember(item => item.Code, opt => opt.MapFrom(
       item => (item.Isactive != null && item.Isactive.Value) ? "Active" : "In active")).ReverseMap();
        }
    }
}
