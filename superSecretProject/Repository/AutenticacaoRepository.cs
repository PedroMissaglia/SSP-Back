using superSecretProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Repository
{
    public class AutenticacaoRepository : ICRUD<Autenticacao>
    {
        public void Add(Autenticacao item)
        {
            using (Context context = new Context())
            {
                context.Autenticacao.Add(item);
                context.SaveChanges();
            }
           
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Autenticacao GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Autenticacao> GetItens()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Autenticacao item)
        {
            throw new NotImplementedException();
        }

        public Autenticacao GetAutNumero(string autenticacao)
        {
            using (Context context = new Context())
            {
                return context.Autenticacao.Where(x => x.Numero == autenticacao).FirstOrDefault();
            }

        }

    }
}
