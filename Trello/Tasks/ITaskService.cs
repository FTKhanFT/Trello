using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Tasks
{
    interface ITaskService
    {
        bool ChangeContent(string text,Task task);

        bool ChangeContentById(string text, int id);

        Task Create(string name);

        bool Delete(Task task);

        bool DeleteById(int id);
    }
}
