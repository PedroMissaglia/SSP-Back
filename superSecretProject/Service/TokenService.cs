using superSecretProject.Model;
using superSecretProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Service
{
    public class TokenService
    {
        public Token GetTokenDisp(String Aut)
        {
            TokenRepository repository = new TokenRepository();

            var tk = repository.GetAutNumero(Aut);

            if ( tk != null)
            {
                return tk;
            }
            else
            {
                throw new Exception("Token Inválido!");
            }

        }

        public bool VerificaToken(Token tk)
        {
            TokenRepository repository = new TokenRepository();

            if (repository.GetAutNumero(tk.Numero) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddToken(Token item)
        {
            TokenRepository repository = new TokenRepository();

            var userEmail = repository.GetAutNumero(item.Numero);

            if (userEmail != null)
            {
                throw new Exception("Token alredy exists");

            }
            else
            {
                //Gerar novo ID
                item.Id = Guid.NewGuid();
                repository.Add(item);

            }

        }


    }
}
