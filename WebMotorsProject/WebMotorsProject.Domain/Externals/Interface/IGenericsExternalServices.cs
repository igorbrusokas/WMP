using System.Collections.Generic;

namespace WebMotorsProject.Domain.Externals.Interface
{
    public interface IGenericsExternalServices<T>
    {
        string QueryParam { set; }
        string Uri { set; }
        T Create(T entity);
        List<T> Find();
        T Update(T entity);
        void Delete(long id);
    }
}
