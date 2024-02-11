using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Model.DTO;
using AutoMapper;

namespace AdityaSERA.Backend.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, AddProductRequest>().
                ReverseMap();
        }
    }
}
