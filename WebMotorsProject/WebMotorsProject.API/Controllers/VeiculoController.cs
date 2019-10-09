using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.DTO;

namespace WebMotorsProject.API.Controllers
{
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private IVeiculoBusiness _veiculoBusiness;

        public VeiculoController(IVeiculoBusiness veiculoBusiness, IConfiguration configuration)
        {
            _veiculoBusiness = veiculoBusiness;
            _veiculoBusiness.Uri = configuration["UriWebMotors"] + "Vehicles";
        }

        [HttpGet]        
        public IActionResult Get([FromQuery] string Page)
        {
            try
            {
                _veiculoBusiness.QueryParam = "Page=" + Page;
                return new OkObjectResult(_veiculoBusiness.Find());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
