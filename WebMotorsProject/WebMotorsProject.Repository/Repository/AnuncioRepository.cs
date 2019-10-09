using WebMotorsProject.Repository.Context;
using WebMotorsProject.Repository.Entity;
using WebMotorsProject.Repository.Generic;
using WebMotorsProject.Repository.Repository.Interface;

namespace WebMotorsProject.Repository.Repository
{
    public class AnuncioRepository : GenericRepository<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepository(ContextDB context) : base(context) { }
    }
}
