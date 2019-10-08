using superSecretProject.Model;
using superSecretProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Service
{
    public class AutenticacaoService
    {
        public Autenticacao VerificaAutenticacao(String Aut)
        {
            AutenticacaoRepository repository = new AutenticacaoRepository();

            var Auth = repository.GetAutNumero(Aut);

            if (Auth != null)
            {
                return Auth;
            }
            else
            {
                throw new Exception("Autenticaçaõ Inválida.");
            }

        }

    }
}
