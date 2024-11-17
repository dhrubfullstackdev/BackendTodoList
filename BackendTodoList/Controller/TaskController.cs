using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendTodoList.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendTodoList.Dtos;
using System;

namespace BackendTodoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DBContext _context;

        public TaskController(IMapper mapper, DBContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TaskDto>>(tasks));
        }

        // GET: api/task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();
            return Ok(_mapper.Map<TaskDto>(task));
        }

        // POST: api/task
        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask(TaskDto taskDto)
        {
            var task = _mapper.Map<Tasks>(taskDto);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.TaskId }, _mapper.Map<TaskDto>(task));
        }

        // PUT: api/task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskDto taskDto)
        {
            if (id != taskDto.TaskId) return BadRequest();
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            _mapper.Map(taskDto, task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
