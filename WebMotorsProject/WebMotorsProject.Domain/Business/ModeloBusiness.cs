using System.Collections.Generic;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.DTO;
using WebMotorsProject.Domain.Externals.Interface;

namespace WebMotorsProject.Domain.Business
{
    public class ModeloBusiness : IModeloBusiness
    {
        private IGenericsExternalServices<ModeloDTO> _service;

        public string Uri
        {
            set { _service.Uri = value; }
        }

        public string QueryParam
        {
            set { _service.QueryParam = value; }
        }


        public ModeloBusiness(IGenericsExternalServices<ModeloDTO> service)
        {
            _service = service;

        }

        public List<ModeloDTO> Find()
        {
            return _service.Find();
        }
    }
}
