using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using superSecretProject.Model;
using superSecretProject.Model.DTO;
using superSecretProject.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace superSecretProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("signup")]
        public IActionResult SignUpUser([FromBody]Users users)
        {
            try
            {
                UsersService usersService = new UsersService();

                usersService.VerificaEmail(users);

                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpPost("login")]
        public IActionResult LoginAsCommonUser([FromBody]UserDTO user)
        {
            try
            {
                UsersService UsersService = new UsersService();

                //Busca usuario por email e senha
                var usu = UsersService.Login(user.Email);
                object use = null;


                //Caso achar retorna 200 e o usuario
                if (usu != null)
                {
                    IdDTO usuId = new IdDTO(usu.Id);

                    use = UsersService.Login(user.Email, user.Password);
                    if (use != null)
                        return Ok(usuId);

                    else { return StatusCode(412); }
                }
                else
                {

                    return StatusCode(422);
                    //caso contrario retorna 412

                }
            }
            catch (Exception e)
            {

                throw e;
            }


        }
    }
}
