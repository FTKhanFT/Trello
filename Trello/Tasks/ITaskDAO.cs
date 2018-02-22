using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Tasks
{
    interface ITaskDAO
    {
        void Create(Task task);

        void Delete(Task task);

        void DeleteById(int id);

        Task Find(Task task);

        Task FindById(int id);

        void Update(string name, Task task);

        void UpdateById(string name, int id);
    }
}
