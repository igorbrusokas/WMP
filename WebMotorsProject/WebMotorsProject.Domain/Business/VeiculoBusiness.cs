using System.Collections.Generic;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.DTO;
using WebMotorsProject.Domain.Externals.Interface;

namespace WebMotorsProject.Domain.Business
{
    public class VeiculoBusiness : IVeiculoBusiness
    {
        private IGenericsExternalServices<VeiculoDTO> _service;

        public string Uri
        {
            set { _service.Uri = value; }
        }

        public string QueryParam
        {
            set { _service.QueryParam = value; }
        }


        public VeiculoBusiness(IGenericsExternalServices<VeiculoDTO> service)
        {
            _service = service;

        }

        public List<VeiculoDTO> Find()
        {
            return _service.Find();
        }
    }
}
