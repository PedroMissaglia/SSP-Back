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
        public bool VerificaAutenticacaoDisp(String Aut)
        {
            AutenticacaoRepository repository = new AutenticacaoRepository();

            if (repository.GetAutNumero(Aut) != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
