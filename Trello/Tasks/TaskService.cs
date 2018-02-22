using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Tasks
{
    class TaskService : ITaskService
    {
        private ITaskDAO taskDAO;

        public ITaskDAO TaskDAO
        {
            set
            {
                taskDAO = value;
            }
        }

        public TaskService()
        {
            taskDAO = new TaskDAO();
        }

        public bool ChangeContent(string text, Task task)
        {
            if (task != null)
            {
                if (taskDAO.Find(task) != null)
                {
                    if (!String.IsNullOrWhiteSpace(text))
                    {
                        taskDAO.Update(text, task);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            return false;
        }

        public bool ChangeContentById(string text, int id)
        {
            if (taskDAO.FindById(id) != null)
            {
                if (!String.IsNullOrWhiteSpace(text))
                {
                    taskDAO.UpdateById(text, id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Task Create(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                Task task = new Task(name);
                taskDAO.Create(task);
                return task;
            }
            return null;
        }

        public bool Delete(Task task)
        {
            if (task != null)
            {
                if (taskDAO.Find(task) != null)
                {
                    taskDAO.Delete(task);
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            if (taskDAO.FindById(id) != null)
            {
                taskDAO.DeleteById(id);
                return true;
            }
            return false;
        }
    }
}
