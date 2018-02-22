using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Tasks;

namespace Trello.Rows
{
    class RowDAO : IRowDAO
    {
        private List<Row> rows;

        public RowDAO()
        {
            rows = new List<Row>();
        }

        public void Create(Row row)
        {
            rows.Add(row);
        }

        public List<Row> getRows()
        {
            return rows;
        }

        public void Delete(Row row)
        {
            rows.Remove(row);
        }

        public void DeleteById(int id)
        {
            rows.Remove(rows.Find(x => x.ID == id));
        }

        public Row Find(Row row)
        {
            return rows.Find(x => x == row);
        }

        public Row FindById(int id)
        {
            return rows.Find(x => x.ID == id);
        }

        public List<Tasks.Task> getTask(Row row)
        {
            return row.getTasks();
        }

        public void Update(string name, Row row)
        {
            rows.Find(x => x == row).Name = name;
        }

        public void UpdateById(string name, int id)
        {
            rows.Find(x => x.ID == id).Name = name;
        }
    }
}
