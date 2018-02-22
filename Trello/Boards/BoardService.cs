using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Rows;

namespace Trello.Boards
{
    class BoardService : IBoardService
    {
        private IBoardDAO boardDAO;

        public BoardService()
        {
            boardDAO = new BoardDAO();
        }

        public IBoardDAO BoardDAO
        {
            set
            {
                boardDAO = value;
            }
        }

        public bool ChangeColor(string color, Board board)
        {
            if (board != null)
            {
                if (boardDAO.Find(board) != null)
                {
                    if (!String.IsNullOrWhiteSpace(color))
                    {
                        boardDAO.UpdateColor(color, board);
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

        public bool ChangeColorById(string color, int id)
        {
            if (boardDAO.FindById(id) != null)
            {
                if (!String.IsNullOrWhiteSpace(color))
                {
                    boardDAO.UpdateColorById(color, id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool ChangeName(string name, Board board)
        {
            if (board != null)
            {
                if (boardDAO.Find(board) != null)
                {
                    if (!String.IsNullOrWhiteSpace(name))
                    {
                        boardDAO.UpdateName(name, board);
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
            if (boardDAO.FindById(id) != null)
            {
                if (!String.IsNullOrWhiteSpace(name))
                {
                    boardDAO.UpdateNameById(name, id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Board Create(string name, string color)
        {
            if (!String.IsNullOrWhiteSpace(name) && !String.IsNullOrWhiteSpace(color))
            {
                Board board = new Board(name, color);
                boardDAO.Create(board);
                return board;
            }
            return null;
        }

        public List<Board> getBoards()
        {
            return boardDAO.getBoards();
        }

        public bool Delete(Board board)
        {
            if (board != null)
            {
                if (boardDAO.Find(board) != null)
                {
                    boardDAO.Delete(board);
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            if (boardDAO.FindById(id) != null)
            {
                boardDAO.DeleteById(id);
                return true;
            }
            return false;
        }

        public List<Row> PrintAllRows(Board board)
        {
            if (board != null && boardDAO.Find(board) != null)
            {
                return boardDAO.getRows(board);
            }
            return null;
        }
    }
}
