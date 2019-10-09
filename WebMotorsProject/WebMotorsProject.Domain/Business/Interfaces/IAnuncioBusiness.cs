using System.Collections.Generic;
using WebMotorsProject.Domain.Data.DTO;

namespace WebMotorsProject.Domain.Business.Interfaces
{
    public interface IAnuncioBusiness
    {
        AnuncioDTO Create(AnuncioDTO entity);
        AnuncioDTO FindById(long id);
        List<AnuncioDTO> FindAll();
        AnuncioDTO Update(AnuncioDTO entity);
        void Delete(long id);
    }
}
