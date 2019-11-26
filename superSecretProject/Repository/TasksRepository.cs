using superSecretProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Repository
{
    public class TasksRepository : ICRUD<Tasks>
    {
        public void Add(Tasks item)
        {
            using (Context context = new Context())
            {
                context.Tasks.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Tasks GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Tasks> GetItens()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Tasks item)
        {
            throw new NotImplementedException();
        }
    }
}
