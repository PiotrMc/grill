using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrillApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[KeyAuthorize]
    public abstract class SharedController<T> : ControllerBase where T : EntityHelper.Entity
    {
        private readonly IRepository<T> repository;
        protected ILogger Logger { get; }
        public SharedController(IRepository<T> repository, ILogger logger)
        {
            this.repository = repository;
            Logger = logger;
        }

        //public async Task<List<T>> Get()
        [HttpGet]
        //[AllowAnonymous]
        //[KeyAuthorize(RoleType.Employee)]
        public async Task<IActionResult> Get()
        {
            try
            {
                Logger.LogInformation("Entered method Get");
                return Ok(await repository.GetListAsync());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await repository.GetAsync(id);
            if (item == null)
            {
                Logger.LogWarning($"Item id={id} not found. Method={nameof(Get)}");
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("AdultsOnly")]
        public async Task<IActionResult> GetListAdultsAsync()
        {
            try
            {
                Logger.LogInformation("Entered method Get");
                return Ok(repository.GetListAdultsAsync());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }

        }
        //[HttpGet]
        //[Route("[action]/GetAdult")]
        //public async Task<IActionResult> GetByOk(string text)
        //{
        //    return Ok(text);
        //}

        //[HttpGet]
        //[Route("GetAdults")]
        //public async Task<IActionResult> GetListAdultsAsync();
        //{
        //    return (await repository.GetListAsync());

        //}

        [HttpPost]
        //[KeyAuthorize(RoleType.Employee)]
        public async Task<ActionResult<T>> Post(T item)
        {
            Logger.LogInformation("Method Post");
            await repository.AddAsync(item);
            await repository.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        //[KeyAuthorize(RoleType.Employee)]
        public async Task<ActionResult> Put(int id, T item)
        {
            Logger.LogInformation("Method Put");
            if (id != item.Id)
            {
                Logger.LogWarning($"Item id not found. Method={nameof(Get)}");
                return BadRequest();
            }
            await repository.UpdateAsync(item);
            try
            {
                await repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!repository.FindBy(a => a.Id == id).Any())
                {
                    Logger.LogWarning($"Item id={id} not found. Method={nameof(Put)}");
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        //[KeyAuthorize(RoleType.Employee)]
        public async Task<ActionResult<T>> Delete(int id)
        {
            Logger.LogInformation("Method Delete");
            var item = await repository.GetAsync(id);
            if (item == null)
            {
                Logger.LogWarning($"Item id={id} not found. Method={nameof(Delete)}");
                return NotFound();
            }
            await repository.DeleteAsync(id);
            await repository.SaveChangesAsync();
            return Ok(item);
        }
    }
}
