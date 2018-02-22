using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Tasks;

namespace Trello.Rows
{
    interface IRowDAO
    {
        void Create(Row row);

        void Delete(Row row);

        void DeleteById(int id);

        Row Find(Row row);

        Row FindById(int id);

        List<Tasks.Task> getTask(Row row);

        List<Row> getRows();

        void Update(string name, Row row);

        void UpdateById(string name, int id);
    }
}
