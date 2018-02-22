using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Tasks
{
    class TaskDAO : ITaskDAO
    {
        private List<Task> tasks;

        public TaskDAO()
        {
            tasks = new List<Task>();
        }

        public void Create(Task task)
        {
            tasks.Add(task);
        }

        public void Delete(Task task)
        {
            tasks.Remove(task);
        }

        public void DeleteById(int id)
        {
            tasks.Remove(tasks.Find(x => x.ID == id));
        }

        public Task Find(Task task)
        {
            return tasks.Find(x => x == task);
        }

        public Task FindById(int id)
        {
            return tasks.Find(x => x.ID == id);
        }

        public void Update(string name, Task task)
        {
            tasks.Find(x => x == task).Name = name;
        }

        public void UpdateById(string name, int id)
        {
            tasks.Find(x => x.ID == id).Name = name;
        }
    }
}
