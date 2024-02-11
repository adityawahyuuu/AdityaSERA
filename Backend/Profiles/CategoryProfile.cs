using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Model.DTO;
using AutoMapper;

namespace AdityaSERA.Backend.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetAllCategoryRequest>().
                ReverseMap();

            CreateMap<Category, GetCategoryIdByName>().
                ReverseMap();
        }
    }
}
