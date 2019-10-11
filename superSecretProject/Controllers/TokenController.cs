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
    public class TokenController : ControllerBase
    {
        [HttpPost("auth")]
        public IActionResult Auth([FromBody]Token auth)
        {
            try
            {
                TokenService AuthsService = new TokenService();

                AuthsService.GetTokenDisp(auth.Numero);

                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost("addauth")]
        public IActionResult AddAuth([FromBody]Token auth)
        {
            try
            {
                TokenService AuthsService = new TokenService();

                AuthsService.AddToken(auth);

                var aut = AuthsService.GetTokenDisp (auth.Numero);


                //Caso achar retorna 200 e o usuario
                if (aut != null)
                {
                    IdDTO autId = new IdDTO(aut.Id);
                    return Ok(autId);
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
