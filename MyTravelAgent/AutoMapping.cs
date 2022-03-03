using AutoMapper;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTravelAgent
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest =>
                dest.CustomerName,
                opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
               .ForMember(dest=> dest.HotelId,
                opt=> opt.MapFrom(src=>src.Hotel.Id))
                .ForMember(dest =>
                dest.HotelName,
                opt => opt.MapFrom(src => src.Hotel.Name));

            CreateMap<OrderDTO, Order>();
            CreateMap<Customer, customerDTO>().ReverseMap();
            CreateMap<Admin,AdminLoginDTO>().ReverseMap();


        }
    }
}
