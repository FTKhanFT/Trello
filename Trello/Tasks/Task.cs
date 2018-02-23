using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Tasks
{
    public class Task:ITask
    {
        string name;
        int id;
       
        public int ID { get => id; }
        public string Name { get => name; set => name = value; }

        public Task(string name)
        {
            this.id = RandomID.GetInstance().IdForTask();
            this.name = name;
        }
        
    }
}
