using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Tasks;

namespace Trello.Rows
{
    class Row:IRow
    {
        string  name;
        int id;
        List<Tasks.Task> tasks;

        public int ID { get => id; }
        public string Name { get => name; set => name = value; }

        public Row(string name)
        {
            tasks = new List<Tasks.Task>();
            this.id = RandomID.GetInstance().IdForRow();
            this.name = name;
        }

        public List<Tasks.Task> getTasks()
        {
            return tasks;
        }
        public void addTask(Tasks.Task task)
        {
            tasks.Add(task);
        }
    }
}