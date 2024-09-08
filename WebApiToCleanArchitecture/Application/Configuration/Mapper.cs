using AutoMapper;
using WebApiToCleanArchitecture.Application.DTOs;
using WebApiToCleanArchitecture.Domain.Entities;

namespace WebApiToCleanArchitecture.Application.Configuration
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<CustomerDto, Customer>();
            CreateMap<ProductDto, Product>();
        }
    }
}
