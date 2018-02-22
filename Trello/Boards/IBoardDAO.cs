using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Rows;


namespace Trello.Boards
{
    interface IBoardDAO
    {
        List<Board> getBoards();
            
        void Create(Board board);

        void Delete(Board board);

        void DeleteById(int id);

        Board Find(Board board);

        Board FindById(int id);

        List<Row> getRows(Board board);

        void UpdateColor(string color, Board board);

        void UpdateColorById(string color, int id);

        void UpdateName(string name, Board board);

        void UpdateNameById(string name, int id);
    }
}
