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
        [HttpPost("add")]
        public IActionResult Add_Task([FromRoute]Guid usersid, [FromBody]Tasks task)
        {
            try
            {
                TasksService TasksService = new TasksService();

                if (TasksService.AddTask(task)){
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
