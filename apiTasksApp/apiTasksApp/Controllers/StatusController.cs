using apiTasksApp.Context;
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
    public class StatusController : ControllerBase
    {
        private readonly AppDbContext context;

        public StatusController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<StatusController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.status.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<StatusController>/5
        [HttpGet("{id}", Name = "GetStatus")]
        public ActionResult Get(int id)
        {
            try
            {
                Models.Status status = context.status.FirstOrDefault(t => t.Id == id);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<StatusController>
        [HttpPost]
        public ActionResult Post([FromBody] Models.Status status)
        {
            try
            {
                context.status.Add(status);
                context.SaveChanges();
                return CreatedAtRoute("GetStatus", new { status.Id }, status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Models.Status status)
        {
            try
            {
                if (status.Id == id)
                {
                    context.Entry(status).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetStatus", new { id = status.Id }, status);
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

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Models.Status status = context.status.FirstOrDefault(t => t.Id == id);
                if (status != null)
                {
                    context.status.Remove(status);
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
