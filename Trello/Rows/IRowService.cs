using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Tasks;

namespace Trello.Rows
{
    interface IRowService
    {
        bool ChangeName(string name,Row row);

        bool ChangeNameById(string name,int id);

        Row Create(string name);

        bool Delete(Row row);

        bool DeleteById(int id);

        List<Row> getRows();

        List<Tasks.Task> PrintAllTask(Row row);
    }
}
