using System.Collections.Generic;
using WebMotorsProject.Domain.Data.DTO;

namespace WebMotorsProject.Domain.Business.Interfaces
{
    public interface IMarcaBusiness
    {
        string Uri { set; }
        List<MarcaDTO> FindAll();
    }
}
