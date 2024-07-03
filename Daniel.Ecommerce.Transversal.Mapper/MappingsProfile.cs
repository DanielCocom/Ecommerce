using Daniel.Ecommerce.Aplicacion.Dto;
using Daniel.Ecommerce.Domain.Entity;

using AutoMapper;

namespace Daniel.Ecommerce.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
       public MappingsProfile() 
        {

            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Usuario, UsuarioDto>();
    



        }


    }
}
