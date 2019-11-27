using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using superSecretProject.Model;
using superSecretProject.Model.DTO;
using superSecretProject.Service;

namespace superSecretProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpPost("add/{usersid}")]
        public IActionResult Add_Task([FromRoute]Guid usersid, [FromBody]Tasks task)
        {
            try
            {
                TasksService TasksService = new TasksService();

                if (TasksService.AddTask(task, usersid)){
                    return Ok();
                }
                return StatusCode(422);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost("delete/{usersid}")]
        public IActionResult Del_Task([FromRoute]Guid usersid, [FromBody]Guid taskid)
        {
            try
            {
                TasksService TasksService = new TasksService();

                if (TasksService.DelTask(taskid, usersid))
                {
                    return Ok();
                }
                return StatusCode(422);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("list/{usersid}")]
        public IActionResult List_Task([FromRoute]Guid usersid)
        {
            try
            {
                TasksService TasksService = new TasksService();

                var task = TasksService.ListTask(usersid);
               
                if(task != null)
                {
                    return Ok(task);
                }
                else
                {
                    return StatusCode(422);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("upd/{usersid}")]
        public IActionResult Upd_Task([FromRoute]Guid usersid, [FromBody]Tasks task)
        {
            try
            {
                TasksService TasksService = new TasksService();

                if (TasksService.UpdateTasks(usersid, task))
                {
                    return Ok();
                }
                return StatusCode(422);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
