using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;
using ToDoApi.Models.Repository;

namespace ToDoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoController : ControllerBase
	{
        private readonly IDataRepository<ToDo> _dataRepository;
        public ToDoController(IDataRepository<ToDo> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/ToDo
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ToDo> employees = _dataRepository.GetAll();
            return Ok(employees);
        }
        // GET: api/ToDo/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            ToDo todo = _dataRepository.Get(id);
            if (todo == null)
            {
                return NotFound("The ToDo record couldn't be found.");
            }
            return Ok(todo);
        }
        // POST: api/ToDo
        [HttpPost]
        public IActionResult Post([FromBody] ToDo todo)
        {
            if (todo == null)
            {
                return BadRequest("ToDo is null.");
            }
            _dataRepository.Add(todo);
            return CreatedAtRoute(
                  "Get",
                  new { Id = todo.Id },
                  todo);
        }
        // PUT: api/ToDo/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ToDo todo)
        {
            if (todo == null)
            {
                return BadRequest("Employee is null.");
            }
            ToDo todoToUpdate = _dataRepository.Get(id);
            if (todoToUpdate == null)
            {
                return NotFound("The ToDo record couldn't be found.");
            }
            _dataRepository.Update(todoToUpdate, todo);
            return NoContent();
        }
        // DELETE: api/ToDo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            ToDo todo = _dataRepository.Get(id);
            if (todo == null)
            {
                return NotFound("The ToDo record couldn't be found.");
            }
            _dataRepository.Delete(todo);
            return NoContent();
        }
    }
}
