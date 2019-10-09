using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.DTO;

namespace WebMotorsProject.API.Controllers
{    
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {
        private IMarcaBusiness _marcaBusiness;

        public MarcaController(IMarcaBusiness marcaBusiness, IConfiguration configuration)
        {
            _marcaBusiness = marcaBusiness;
            marcaBusiness.Uri = configuration["UriWebMotors"] + "Make";
        }

        [HttpGet]        
        public IActionResult Get()
        {
            try
            {
                return new OkObjectResult(_marcaBusiness.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}