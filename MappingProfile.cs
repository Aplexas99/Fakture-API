using AutoMapper;
using FaktureAPI.DTOs;
using FaktureAPI.Models;

namespace FaktureAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BillBody, BillBodyDTO>().ReverseMap();
            CreateMap<BillBodyForUpdateDTO, BillBody>().ReverseMap();
            CreateMap<BillHeader, BillHeaderDTO>().ReverseMap();
            CreateMap<BillHeaderForUpdateDTO, BillHeader>().ReverseMap();
            CreateMap<Partner, PartnerDTO>().ReverseMap();
            CreateMap<PartnerForUpdateDTO, Partner>().ReverseMap();
            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<JobForUpdateDTO, Job>().ReverseMap();
        }
    }
    
}
