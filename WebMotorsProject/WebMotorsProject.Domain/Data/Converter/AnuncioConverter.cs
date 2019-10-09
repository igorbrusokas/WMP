using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebMotorsProject.Domain.Data.Converter.Interface;
using WebMotorsProject.Domain.Data.DTO;
using WebMotorsProject.Repository.Entity;

namespace WebMotorsProject.Domain.Data.Converter
{
    public class AnuncioConverter : IConverter<AnuncioDTO, Anuncio>, IConverter<Anuncio, AnuncioDTO>
    {
        private IMapper _mapper;
        public AnuncioConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Anuncio Parse(AnuncioDTO anuncio)
        {
            return _mapper.Map<Anuncio>(anuncio);
        }

        public AnuncioDTO Parse(Anuncio anuncio)
        {
            return _mapper.Map<AnuncioDTO>(anuncio);
        }

        public List<Anuncio> ParseList(List<AnuncioDTO> anuncio)
        {
            if (anuncio == null) return new List<Anuncio>();
            return anuncio.Select(item => Parse(item)).ToList();
        }

        public List<AnuncioDTO> ParseList(List<Anuncio> anuncio)
        {
            if (anuncio == null) return new List<AnuncioDTO>();
            return anuncio.Select(item => Parse(item)).ToList();
        }
    }
}
