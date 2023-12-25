using AutoMapper;
using Entities.BizEntites;
using Repository.DBEntities;

namespace Repository.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BizEmployeInfo, EmployeInfo>().ReverseMap();
        }
    }
}
