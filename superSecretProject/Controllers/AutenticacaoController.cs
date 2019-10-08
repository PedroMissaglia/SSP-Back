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
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost("auth")]
        public IActionResult Auth([FromBody]Autenticacao auth)
        {
            try
            {
                AutenticacaoService AuthsService = new AutenticacaoService();

                AuthsService.VerificaAutenticacaoDisp(auth.Numero);

                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost("addauth")]
        public IActionResult AddAuth([FromBody]Autenticacao auth)
        {
            try
            {
                AutenticacaoService AuthsService = new AutenticacaoService();

                //Busca usuario por email e senha
                var aut = AuthsService.VerificaAutenticacaoDisp(auth.Numero);

                //Caso achar retorna 200 e o usuario
                if (aut)
                {
                    IdDTO usuId = new IdDTO(auth.Id);
                    return Ok(usuId);
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
