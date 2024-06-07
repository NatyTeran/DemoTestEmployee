using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test.Domain.DTOs;
using Test.Domain.Entities;
using Test.Domain.Interfaces;
using Test.Domain.Mappers;

namespace Test.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository Repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            Repository = repository;
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmployeeDto empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = Repository.Add(empleado.ToEmployeeEntity()); ;
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] EmployeeDto empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = Repository.Update(empleado.ToEmployeeEntity());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(Repository.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await Repository.GetAll();
        }

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(Repository.GetById(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
