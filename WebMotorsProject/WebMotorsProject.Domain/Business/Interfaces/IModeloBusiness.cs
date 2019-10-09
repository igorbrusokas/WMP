using System.Collections.Generic;
using WebMotorsProject.Domain.Data.DTO;

namespace WebMotorsProject.Domain.Business.Interfaces
{
    public interface IModeloBusiness
    {
        string QueryParam { set; }
        string Uri { set; }
        List<ModeloDTO> Find();
    }
}

