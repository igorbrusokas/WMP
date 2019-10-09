using AutoMapper;
using WebMotorsProject.Domain.Data.DTO;
using WebMotorsProject.Repository.Entity;


namespace WebMotorsProject.Domain.Data.Converter
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Anuncio, AnuncioDTO>().ReverseMap();
        }
    }
}
