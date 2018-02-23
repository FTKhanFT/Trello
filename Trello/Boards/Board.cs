using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Rows;

namespace Trello.Boards
{
    public class Board : IBoard
    {
        string color,name;
        int id;
        List<Row> rows;

        public int ID { get=>id ;}
        public string Color { get=>color; set=>color = value; }
        public string Name { get => name; set => name = value; }
        public List<Row> Rows { get => rows; set => rows = value; }

        public Board(string name,string color)
        {
            rows = new List<Row>();
            this.id = RandomID.GetInstance().IdForBoard();
            this.name = name;
            this.color = color;
        }

        public List<Row> getRows()
        {
            return Rows;
        }
        public void addRow(Rows.Row row)
        {
            Rows.Add(row);
        }
    }
}
