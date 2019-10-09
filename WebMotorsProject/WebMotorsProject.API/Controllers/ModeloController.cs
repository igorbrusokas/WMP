using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.DTO;

namespace WebMotorsProject.API.Controllers
{
    [Route("api/[controller]")]
    public class ModeloController : ControllerBase
    {
        private IModeloBusiness _modeloBusiness;

        public ModeloController(IModeloBusiness modelBusiness, IConfiguration configuration)
        {
            _modeloBusiness = modelBusiness;
            _modeloBusiness.Uri = configuration["UriWebMotors"] + "Model";
        }

        [HttpGet]        
        public IActionResult Get([FromQuery] string MakeID)
        {
            try
            {
                _modeloBusiness.QueryParam = "MakeID=" + MakeID;
                return new OkObjectResult(_modeloBusiness.Find());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}