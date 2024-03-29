﻿using Alexandria.Model.DTO;
using superSecretProject.Model;
using superSecretProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Service
{
    public class UsersService
    {
        public void VerificaEmail(Users users)
        {
            UsersRepository repository = new UsersRepository();
            if (repository.GetUsersEmail(users.Email) != null)
            {
                throw new Exception("Email já cadastrado.");
                
            }
        }
        public Users Login(string email, string password)
        {
            UsersRepository repository = new UsersRepository();

            Users userEmail = repository.GetUser(email, password);

            return userEmail;
        }
        public Users GetUserbyEmail(string email)
        {
            UsersRepository userRepository = new UsersRepository();

            return userRepository.GetUserEmail(email);
         
        }

        public void AddUser(Users item)
        {
            UsersRepository repository = new UsersRepository();

            var userEmail = repository.GetUserEmail(item.Email);

            if (userEmail != null)
            {
                throw new Exception("User alredy exists");

            }
            else
            {

                TokenService AuthsService = new TokenService();
                var auth = item.TokenId;
                var aut = AuthsService.GetTokenDisp(auth.ToString());

                if (aut != null)
                {

                    //Gerar novo ID
                    item.Id = Guid.NewGuid();
                    item.TokenId = aut.Id;
                    item.Password = repository.MD5Encrypt(item.Password);
                    repository.Add(item);

                }
                else
                {
                    throw new Exception("Usuário não autenticado.");
                }

            }

        }
        
        // função para retornar usuário completo
        public Users GetUserEmail(string email)
        {
            UsersRepository repository = new UsersRepository();

            var usu = repository.GetUserEmail(email);

            if (usu == null)
            {
                throw new Exception("User does not exists");
            }
            return usu;
        }

        public Boolean UpdateUsers(Guid id, UsersUpdateDTO item)
        {
            UsersRepository repository = new UsersRepository();

            var user = repository.GetItem(id);

            if (user != null)
            {
                if (!String.IsNullOrEmpty(item.Name) && item.Name != user.Name)
                {
                    user.Name = item.Name;
                }
                if (!String.IsNullOrEmpty(item.Email) && item.Email != user.Email)
                {
                    user.Email = item.Email;
                }
                if (!String.IsNullOrEmpty(item.CPF) && item.CPF != user.CPF)
                {
                    user.CPF = item.CPF;
                }
                if (item.Birthdate != user.Birthdate && item.Birthdate.ToString() != "01/01/0001 00:00:00")
                {
                    user.Birthdate = item.Birthdate;
                }
                if (!(item.TokenId == Guid.Empty))
                {
                    TokenService AuthsService = new TokenService();

                    var auth = item.TokenId;
                    var aut = AuthsService.GetTokenDisp(auth.ToString());


                    if (aut != null)
                    {
                        user.TokenId = aut.Id;
                    }

                        
                }

                user.Password = repository.MD5Decrypt(user.Password);

                repository.Update(id, user);
                return true;
            }
            else
            {
                throw new Exception("Usuário não encontrado.");
            }
        }
        public bool Email(string email)
        {

            UsersRepository repository = new UsersRepository();

            if (repository.GetUserEmail(email) != null)
            {

                repository.SendEmail(email);

                return true;

            }

            return false;
        }

        //Método para retornar o Usuário pelo Id
        public Users GetUserId(Guid id)
        {
            UsersRepository userRepository = new UsersRepository();

            var user = userRepository.GetItem(id);
            return user;
        }


        public void UpdatePasswordUser(NewPasswordDTO item)
        {
            UsersRepository repository = new UsersRepository();
            var userId = repository.GetItem(item.Id);

            if (userId != null && item.New_Password.CompareTo(item.Confirm_Password) == 0)
            {
                userId.Password = item.Confirm_Password;
                repository.Update(userId.Id, userId);
            }
            else
            {
                throw new Exception("Passwords do not match.");
            }

        }

        
        public void UpdatePasswordByProfile(NewPasswordByProfileDTO item)
        {
            UsersRepository repository = new UsersRepository();
            var userId = repository.GetItem(item.Id);

            if (userId != null ) 
            {
                var pass = repository.MD5Decrypt(userId.Password);

                if (item.Atl_Password == pass ) 
                {
                    if (item.New_Password.CompareTo(item.Confirm_Password) == 0)
                    {
                        userId.Password = item.Confirm_Password;
                        repository.Update(userId.Id, userId);
                    }
                    else
                    {
                        throw new Exception("Passwords do not match.");
                    }
                }
                else
                {
                    throw new Exception("Password previuos do not match.");
                }

            }
            else
            {
                throw new Exception("User not found.");
            }

        }



    }
}
