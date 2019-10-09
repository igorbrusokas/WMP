using System.Collections.Generic;
using WebMotorsProject.Repository.Entity;

namespace WebMotorsProject.Repository.Generic.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Create(T entity);
        T FindById(long id);
        List<T> FindAll();
        T Update(T entity);
        void Delete(long id);
    }
}
