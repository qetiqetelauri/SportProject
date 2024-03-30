using AutoMapper;
using ProjectDAL;
using ProjectDTO;

namespace ProjectAPI.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();

        }
    }
}
