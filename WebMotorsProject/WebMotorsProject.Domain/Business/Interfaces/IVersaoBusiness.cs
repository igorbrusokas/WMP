using System;
using System.Collections.Generic;
using System.Text;
using WebMotorsProject.Domain.Data.DTO;

namespace WebMotorsProject.Domain.Business.Interfaces
{
    public interface IVersaoBusiness
    {
        string QueryParam { set; }
        string Uri { set; }
        List<VersaoDTO> Find();
    }
}
