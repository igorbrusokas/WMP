using AutoMapper;
using System.Collections.Generic;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.Converter;
using WebMotorsProject.Domain.Data.DTO;
using WebMotorsProject.Repository.Repository.Interface;
namespace WebMotorsProject.Domain.Business
{
    public class AnuncioBusiness : IAnuncioBusiness
    {
        private IAnuncioRepository _repository;

        private readonly AnuncioConverter _anuncioConverter;


        public AnuncioBusiness(IAnuncioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _anuncioConverter = new AnuncioConverter(mapper);
        }

        public AnuncioDTO Create(AnuncioDTO entity)
        {
            var anuncioEntity = _anuncioConverter.Parse(entity);
            anuncioEntity = _repository.Create(anuncioEntity);
            return _anuncioConverter.Parse(anuncioEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<AnuncioDTO> FindAll()
        {
            return _anuncioConverter.ParseList(_repository.FindAll());
        }

        public AnuncioDTO FindById(long id)
        {
            return _anuncioConverter.Parse(_repository.FindById(id));
        }

        public AnuncioDTO Update(AnuncioDTO entity)
        {
            var anuncioEntity = _anuncioConverter.Parse(entity);
            anuncioEntity = _repository.Update(anuncioEntity);
            return _anuncioConverter.Parse(anuncioEntity);
        }
    }
}
