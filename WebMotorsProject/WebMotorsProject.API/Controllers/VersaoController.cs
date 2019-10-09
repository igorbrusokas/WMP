using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.DTO;

namespace WebMotorsProject.API.Controllers
{
    [Route("api/[controller]")]
    public class VersaoController : ControllerBase
    {
        private IVersaoBusiness _versaoBusiness;

        public VersaoController(IVersaoBusiness versaoBusiness, IConfiguration configuration)
        {
            _versaoBusiness = versaoBusiness;
            _versaoBusiness.Uri = configuration["UriWebMotors"] + "Version";
        }

        [HttpGet]        
        public IActionResult Get([FromQuery] string modelID)
        {
            try
            {
                _versaoBusiness.QueryParam = "ModelID=" + modelID;
                return new OkObjectResult(_versaoBusiness.Find());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
