using superSecretProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Repository
{
    public class TokenRepository : ICRUD<Token>
    {
        public void Add(Token item)
        {
            using (Context context = new Context())
            {
                context.Token.Add(item);
                context.SaveChanges();
            }
           
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Token GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Token> GetItens()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Token item)
        {
            throw new NotImplementedException();
        }

        public Token GetAutNumero(string Token)
        {
            using (Context context = new Context())
            {
                return context.Token.Where(x => x.Numero == Token).FirstOrDefault();
            }

        }

    }
}
