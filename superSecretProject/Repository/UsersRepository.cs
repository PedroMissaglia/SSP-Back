using superSecretProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Repository
{
    public class UsersRepository : ICRUD<Users>
    {
        public void Add(Users item)
        {
            using (Context context = new Context())
            {
                context.Users.Add(item);
                context.SaveChanges();
            }
           
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Users GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetItens()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Users item)
        {
            throw new NotImplementedException();
        }

        public Users GetUsersEmail(string email)
        {
            using (Context context = new Context())
            {
                return context.Users.Where(x => x.Email == email).FirstOrDefault();
            }

        }
        public Users GetUserEmail(string email)
        {
            using (Context context = new Context())
            {
                return context.Users.Where(x => x.Email == email).FirstOrDefault();
            }
        }
    }
}
