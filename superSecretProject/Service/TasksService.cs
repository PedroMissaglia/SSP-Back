using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using superSecretProject.Model;
using superSecretProject.Model.DTO;
using superSecretProject.Repository;

namespace superSecretProject.Service
{
    public class TasksService
    {
        public bool AddTask(Tasks task, Guid id)
        {
            if (task.Name == null || task.Date == null || id == null)
            {
                return false;
            }
            else
            {
                TasksRepository repository = new TasksRepository();

                //Gerar novo ID
                task.Id = Guid.NewGuid();
                repository.Add(task);


                var tasks = repository.GetItem(task.Id);

                if (tasks != null)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }

        }


        public bool DelTask(Guid taskId, Guid id)
        {
            TasksRepository repository = new TasksRepository();

            var tasks = repository.GetItem(taskId);

            if (tasks != null)
            {
                repository.Delete(taskId);

                var tasks2 = repository.GetItem(taskId);

                if (tasks2 == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        public List<Tasks> ListTask(Guid id)
        {
            UsersService userservice = new UsersService();

            var Usertasks = userservice.GetUserId(id);

            if (Usertasks != null)
            {
                TasksRepository repository = new TasksRepository();
                
                return repository.GetListTask(id);

            }
            else
            {
                throw new Exception("User null.");
            }

        }

    }
}
