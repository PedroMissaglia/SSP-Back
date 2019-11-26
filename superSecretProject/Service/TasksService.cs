using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using superSecretProject.Model;

namespace superSecretProject.Service
{
    public class TasksService
    {
        internal void AddTask(Tasks task, Guid id)
        {
            if (task.Name == null && task.time == null && task.date == null)
            {
                throw new Exception("Tarefa inválida. Verifique se todos os campos estão preenchidos.");
            }

        }
    }
}
