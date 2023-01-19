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
            CreateMap<BillBodyForUpdateDTO, BillBody>();
            CreateMap<BillHeader, BillHeaderDTO>();
            CreateMap<BillHeaderForUpdateDTO, BillHeader>();
            CreateMap<Partner, PartnerDTO>();
            CreateMap<PartnerForUpdateDTO, Partner>();
        }
    }
    
}
