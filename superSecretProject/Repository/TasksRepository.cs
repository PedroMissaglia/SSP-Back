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
            var tasks = GetItem(id);

            using (Context context = new Context())
            {
                if (tasks != null)
                {
                    context.Tasks.Remove(tasks);
                    context.SaveChanges();
                }
            }
        }

        public Tasks GetItem(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Tasks.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public List<Tasks> GetListTask(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Tasks.Where(x => x.UsersId == id).ToList();
            }
        }


        public List<Tasks> GetItens()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Tasks item)
        {
            var task = GetItem(id);

            using (Context context = new Context())
            {
                if (task != null)
                {

                    task.Name = item.Name;
                    task.Date = item.Date;

                    context.Update(task);
                    context.SaveChanges();
                }
            }
        }
    }
}
