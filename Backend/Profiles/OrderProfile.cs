using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Model.DTO;
using AutoMapper;

namespace AdityaSERA.Backend.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, AddOrderRequest>().
                ReverseMap();
        }
    }
}
