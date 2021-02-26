using apiTasksApp.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiTasksApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext context;

        public TaskController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.task.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}", Name = "GetTask")]
        public ActionResult Get(int id)
        {
            try
            {
                Models.Task task = context.task.FirstOrDefault(t => t.id == id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TaskController>
        [HttpPost]
        public ActionResult Post([FromForm] Models.Task task, IFormFile image = null)
        {
            try
            {
                return Ok(task);
                context.task.Add(task);
                context.SaveChanges();
                return CreatedAtRoute("GetTask", new { task.id }, task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Models.Task task)
        {
            try
            {
                if(task.id == id)
                {
                    context.Entry(task).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTask", new { task.id }, task);
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Models.Task task = context.task.FirstOrDefault(t => t.id == id);
                if(task != null)
                {
                    context.task.Remove(task);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
