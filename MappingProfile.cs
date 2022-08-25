using AutoMapper;
using FaktureAPI.DTOs;
using FaktureAPI.Models;

namespace FaktureAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BillBody, BillBodyDTO>();
        }
    }
    
}
