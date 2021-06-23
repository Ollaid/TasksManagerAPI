using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.DAL.CrudManager;
using TaskManager.DAL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputTaskController : ControllerBase
    {

        // GET: api/<InputTaskController>
        [HttpGet]
        public  DbElements Get()
        {
            DbElements elements = new();
            try
            {
                List<User> users = CrudManager.GetAllUsers();
                List<Tasks> tasks = CrudManager.GetAllTasks();

                elements.Users = users;
                elements.Tasks = tasks;
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Get: {0}", ex.Message));
            }

            return elements;
        }

        // GET api/<InputTaskController>/5
        [HttpGet("{id}")]
        public DbElements Get(int id)
        {
            DbElements result = new();

            try
            {
                List<User> users = CrudManager.GetAllUsers();
                List<Tasks> tasks = CrudManager.GetAllTasks();

                if (id > 2)
                    throw new Exception("Not found 404 !!");

                switch (id)
                {
                    case 1:
                        result.Users = users;
                        result.Tasks = null;
                        break;
                    case 2:
                        result.Tasks = tasks;
                        result.Users = null;
                        break;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Get->(id): {0}", ex.Message));
            }

            return result;
        }

        //// POST api/<InputTaskController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<InputTaskController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<InputTaskController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
