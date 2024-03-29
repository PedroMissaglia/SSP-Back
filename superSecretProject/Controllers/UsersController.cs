﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexandria.Model.DTO;
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

        //Método para Adicionar Usuário
        [HttpPost("signup")]
        public IActionResult SignUpUser([FromBody]Users user)
        {
            try
            {
                UsersService userservice = new UsersService();

                userservice.AddUser(user);

                var usu = userservice.GetUserEmail(user.Email);


                //Caso achar retorna 200 e o usuario
                if (usu != null)
                {
                    IdDTO usuId = new IdDTO(usu.Id);
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

        //Método para acesso ao sistema.
        [HttpPost("login")]
        public IActionResult LoginAsCommonUser([FromBody]UserDTO user)
        {
            try
            {
                UsersService UsersService = new UsersService();

                //Busca usuario por email e senha
                var usu = UsersService.GetUserbyEmail(user.Email);
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

        //Método para recuperação da senha
        [HttpPost("forgotPassword")]
        public IActionResult SendEmail([FromBody]EmailDTO Email)
        {
            try
            {
                UsersService userservice = new UsersService();

                userservice.Email(Email.Email);

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Método para recuperação dO ID do usuário
        [HttpPost("getIdUser")]
        public IActionResult getIdUser([FromBody]EmailDTO item)
        {
            try
            {
                UsersService userservice = new UsersService();

                var usu = userservice.GetUserbyEmail(item.Email);

                //Caso achar retorna 200 e o usuario
                if (usu != null)
                {
                    IdDTO usuId = new IdDTO(usu.Id);

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



        //Método para alterar os dados do usuário
        [HttpPost("updateUsers/{usersid}")]
        public IActionResult UpdateUsers([FromRoute]Guid usersid, [FromBody]UsersUpdateDTO users)
        {
            try
            {
                UsersService userservice = new UsersService();

                if (userservice.GetUserId(usersid) != null)
                {
                    if (userservice.UpdateUsers(usersid, users))
                    {
                        var usu = userservice.GetUserId(usersid);

                        return Ok(usu);
                    }
                    return StatusCode(412);
                }

                else
                {
                    return StatusCode(405);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPost("newPassword")]
        public IActionResult NewPassword([FromBody]NewPasswordDTO item)
        {
            try
            {
                UsersService usersservice = new UsersService();

                usersservice.UpdatePasswordUser(item);


                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
        [HttpPost("newPasswordByProfile")]
        public IActionResult NewPassword([FromBody]NewPasswordByProfileDTO item)
        {
            try
            {
                UsersService usersservice = new UsersService();



                usersservice.UpdatePasswordByProfile(item);


                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Método para consultar os dados do usuário
        [HttpGet("getUsers/{usersid}")]
        public IActionResult GetUsers([FromRoute]Guid usersid)
        {
            try
            {
                UsersService userservice = new UsersService();

                if (userservice.GetUserId(usersid) != null)
                {
                    var usu = userservice.GetUserId(usersid);

                    return Ok(usu);
                }
                else
                {
                    return StatusCode(405);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }

}
