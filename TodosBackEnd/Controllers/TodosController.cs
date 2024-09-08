using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodosBackEnd.Entities;
using TodosBackEnd.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodosBackEnd.Controllers
{
    [Route("v1/api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodosService _service;

        public TodosController(ITodosService service)
        {
            _service = service;
        }

        // GET: api/<TodosController>
        [HttpGet]
        public  async Task<ActionResult<List<TodoItem>>> Get()
        {
            return Ok(await _service.GetAllTask());
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            return Ok(await _service.GetTask(id));
        }

        // POST api/<TodosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoItem task)
        {

            await _service.AddTask(task);
            return NoContent();
        }

        // PUT api/<TodosController>/5
        [HttpPut]
        public async Task<IActionResult> Put(TodoItem todo)
        {
            var updateTask = await _service.UpdateTask(todo);
            return Ok(updateTask); ;
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var result = await _service.DeleteTodoItemAsync(id);
            if (!result)
            {
                return NotFound(); // Item not found
            }

            return NoContent(); // 204 No Content on successful deletion
        }
    }
}

