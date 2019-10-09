using System.Collections.Generic;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.DTO;
using WebMotorsProject.Domain.Externals.Interface;

namespace WebMotorsProject.Domain.Business
{
    public class VersaoBusiness : IVersaoBusiness
    {
        private IGenericsExternalServices<VersaoDTO> _service;

        public string Uri
        {
            set { _service.Uri = value; }
        }

        public string QueryParam
        {
            set { _service.QueryParam = value; }
        }


        public VersaoBusiness(IGenericsExternalServices<VersaoDTO> service)
        {
            _service = service;

        }

        public List<VersaoDTO> Find()
        {
            return _service.Find();
        }
    }
}
