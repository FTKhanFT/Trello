using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Rows;


namespace Trello.Boards
{
    class BoardDAO : IBoardDAO
    {
        private List<Board> boards;

        public BoardDAO()
        {
            boards = new List<Board>();
        }

        public void Create(Board board)
        {
            boards.Add(board);
        }

        public void Delete(Board board)
        {
            boards.Remove(board);
        }

        public void DeleteById(int id)
        {
            boards.Remove(boards.Find(x => x.ID == id));
        }

        public Board Find(Board board)
        {
            return boards.Find(x=>x == board);
        }

        public Board FindById(int id)
        {
            return boards.Find(x => x.ID == id);
        }

        public List<Row> getRows(Board board)
        {
            return board.getRows();
        }

        public void UpdateColor(string color, Board board)
        {
            boards.Find(x => x == board).Color = color;
        }

        public void UpdateColorById(string color, int id)
        {
            boards.Find(x => x.ID == id).Color = color;
        }

        public void UpdateName(string name, Board board)
        {
            boards.Find(x => x == board).Name = name;
        }

        public void UpdateNameById(string name, int id)
        {
            boards.Find(x => x.ID == id).Name = name;
        }

        public List<Board> getBoards()
        {
            return boards;
        }
    }
}
