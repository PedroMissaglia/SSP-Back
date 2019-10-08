using Alexandria.Model.DTO;
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
        public Users Login(string email)
        {
            UsersRepository userRepository = new UsersRepository();

            var user = userRepository.GetUserEmail(email);
            return user;
        }

        public void AddUser(Users item)
        {
            UsersRepository repository = new UsersRepository();

            var userEmail = repository.GetUserEmail(item.Email);

            if (userEmail == null)
            {
                throw new Exception("User alredy exists");

            }
            else
            {

                AutenticacaoService AuthsService = new AutenticacaoService();
                var auth = item.AutenticacaoId;
                var aut = AuthsService.VerificaAutenticacao(auth.ToString());

                if (aut != null)
                {

                    //Gerar novo ID
                    item.Id = Guid.NewGuid();
                    item.AutenticacaoId = aut.Id;
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

                user.Password = repository.MD5Decrypt(user.Password);

                repository.Update(id, user);
                return true;
            }
            else
            {
                throw new Exception("Usuário não encontrado.");
            }
        }
    }
}
