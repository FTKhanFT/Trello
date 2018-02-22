using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Tasks;

namespace Trello.Rows
{
    class RowService : IRowService
    {
        private IRowDAO rowDAO;

        public IRowDAO RowDAO
        {
            set
            {
                rowDAO = value;
            }
        }

        public List<Row> getRows()
        {
            return rowDAO.getRows();
        }

        public RowService()
        {
            rowDAO = new RowDAO();
        }

        public bool ChangeName(string name, Row row)
        {
            if (row != null)
            {
                if (rowDAO.Find(row) != null)
                {
                    if (!String.IsNullOrWhiteSpace(name))
                    {
                        rowDAO.Update(name,row);
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

        public bool ChangeNameById(string name, int id)
        {
            if (rowDAO.FindById(id) != null)
            {
                if (!String.IsNullOrWhiteSpace(name))
                {
                    rowDAO.UpdateById(name, id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Row Create(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                Row row = new Row(name);
                rowDAO.Create(row);
                return row;
            }
            return null;
        }

        public bool Delete(Row row)
        {
            if (row != null)
            {
                if (rowDAO.Find(row) != null)
                {
                    rowDAO.Delete(row);
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            if (rowDAO.FindById(id) != null)
            {
                rowDAO.DeleteById(id);
                return true;
            }
            return false;
        }

        public List<Tasks.Task> PrintAllTask(Row row)
        {
            if (row != null && rowDAO.Find(row) != null)
            {
                return rowDAO.getTask(row);
            }
            return null;
        }
    }
}
