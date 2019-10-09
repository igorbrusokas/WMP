using System;
using System.Collections.Generic;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.DTO;
using WebMotorsProject.Domain.Externals.Interface;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebMotorsProject.Domain.Business
{
    public class MarcaBusiness : IMarcaBusiness
    {
        private IGenericsExternalServices<MarcaDTO> _service;

        public string Uri
        {
            set { _service.Uri = value; }
        }

        public string QueryParam
        {
            set { _service.QueryParam = value; }
        }

        public MarcaBusiness(IGenericsExternalServices<MarcaDTO> service)
        {
            _service = service;
        }

        public List<MarcaDTO> FindAll()
        {
            return _service.Find();
        }
    }
}
