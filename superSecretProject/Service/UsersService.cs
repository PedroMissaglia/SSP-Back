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
                throw new Exception("Email já cadastrado porra");
                
            }
        }
        public Users Login(string email, string password)
        {
            UsersRepository repository = new UsersRepository();

            Users userEmail = repository.GetUsersEmail(email);

            return userEmail;
        }
        public Users Login(string email)
        {
            UsersRepository userRepository = new UsersRepository();

            var user = userRepository.GetUserEmail(email);
            return user;
        }
    }
}
