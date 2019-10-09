using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebMotorsProject.Domain.Business.Interfaces;
using WebMotorsProject.Domain.Data.DTO;
using System.Collections.Generic;

namespace WebMotorsProject.API.Controllers
{    
    [Route("api/[controller]")]
    public class AnuncioController : ControllerBase
    {

        private IAnuncioBusiness _anuncioBusiness;
        private IMapper _mapper;

        public AnuncioController(IAnuncioBusiness anuncioBusiness, IMapper mapper)
        {
            _anuncioBusiness = anuncioBusiness;
            _mapper = mapper;
        }

        [HttpGet]     
        public IActionResult Get()
        {
            try
            {
                return new OkObjectResult(_anuncioBusiness.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet("{id}")]            
        public IActionResult Get(int id)
        {
            try
            {
                var anuncio = _anuncioBusiness.FindById(id);
                if (anuncio == null) return NotFound();
                return new OkObjectResult(anuncio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]  
        public IActionResult Post([FromBody] AnuncioDTO anuncio)
        {
            try
            {
                if (anuncio == null) return BadRequest();
                return new OkObjectResult(_anuncioBusiness.Create(anuncio));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]  
        public IActionResult Put([FromBody] AnuncioDTO anuncio)
        {
            try
            {
                if (anuncio == null) return BadRequest();
                var updatedAnuncio = _anuncioBusiness.Update(anuncio);
                if (updatedAnuncio == null) return BadRequest();
                return new OkObjectResult(updatedAnuncio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpDelete("{id}")]               
        public IActionResult Delete(int id)
        {
            try
            {
                _anuncioBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}