using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Rows;

namespace Trello.Boards
{
    class Board : IBoard
    {
        string color,name;
        int id;
        List<Row> rows;

        public int ID { get=>id ;}
        public string Color { get=>color; set=>color = value; }
        public string Name { get => name; set => name = value; }

        public Board(string name,string color)
        {
            rows = new List<Row>();
            this.id = RandomID.GetInstance().IdForBoard();
            this.name = name;
            this.color = color;
        }

        public List<Row> getRows()
        {
            return rows;
        }
        public void addRow(Rows.Row row)
        {
            rows.Add(row);
        }
    }
}
