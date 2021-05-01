using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrillApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumersController : ControllerBase
    {
        private readonly IConsumersRepository repository;

        public ConsumersController(IConsumersRepository repository)
        {
            this.repository = repository;
        }

        //[HttpGet]
        //public bool GetNull()
        //{
        //    return true;
        //}



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok("dsads");// (repository.GetListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("dasdas");// ex.Message);
            }

        }
    }
}
