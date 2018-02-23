using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Boards;
using Trello.Rows;
using Trello.Tasks;

namespace Trello
{
    class Trello
    {
        List<Board> boards;
        IBoardService boardService;
        IRowService rowService;
        ITaskService taskService;

        private Trello()
        {
            boards = new List<Board>();
            if (File.Exists(@"./datas.json"))
            {
                boards = Json.Deserializer(boards,@"./datas.json");
            }
            boardService = new BoardService();
            rowService = new RowService();
            taskService = new TaskService();
            boardService.getBoards().AddRange(boards);
            foreach (var item in boards)
            {
                rowService.getRows().AddRange(item.getRows());
            }
            
        }

        private static Trello trello = null;

        public static Trello GetTrello()
        {
            if (trello == null)
            {
                trello = new Trello();
            }

            return trello;
        }

        public IBoardService BoardService
        {
            get
            {
                return boardService;
            }
        }

        public IRowService RowService
        {
            get
            {
                return rowService;
            }
        }

        public ITaskService TaskService
        {
            get
            {
                return taskService;
            }
        }

        public Board addBoard(string name, string color)
        {
            var board = boardService.Create(name, color);
            boards.Add(board);
            return board;
        }

        public Board getBoardId(int id)
        {
            return boardService.getBoards().Find(x => x.ID == id);
        }

        public void DeleteBoardById(int id)
        {
            boards.Remove(boardService.getBoards().Find(x => x.ID == id));
            boardService.DeleteById(id);
        }

        public void ChangeBoardColor(string color, int id)
        {
            boards.Find(x => x.ID == id).Color = color;
            boardService.ChangeColorById(color, id);
        }

        public void ChangeBoardName(string name, int id)
        {
            boards.Find(x => x.ID == id).Name = name;
            boardService.ChangeNameById(name, id);
        }

        public List<Board> getBoards()
        {
            return boards;
        }

        public Row addRow(Board board, string name)
        {
            var row = rowService.Create(name);
            board.addRow(row);
            return row;
        }
        public Row addRow(int id, string name)
        {
            var row = rowService.Create(name);
            boards.Find(x => x.ID == id).addRow(row);
            return row;
        }

        public void DeleteRow(int boardId, int id)
        {
            getBoardId(boardId).getRows().Remove(getBoardId(boardId).getRows().Find(x => x.ID == id));
            rowService.DeleteById(id);
        }

        public void ChangeRowName(Board board, string name, int id)
        {
            rowService.ChangeNameById(name, id);
            board.getRows().Find(x => x.ID == id).Name = name;
        }

        public List<Row> getRowsForBoard(int id)
        {
            return getBoardId(id).getRows();
        }

        public List<Row> getAllRows()
        {
            return rowService.getRows();
        }

        public Row GetRowById(int id)
        {
            return rowService.getRows().Find(x => x.ID == id);
        }

        public List<Tasks.Task> GetTasksForRow(int id)
        {
            return GetRowById(id).getTasks();
        }

        public Tasks.Task AddTask(Row row, string name)
        {
            var task = taskService.Create(name);
            row.getTasks().Add(task);
            return task;
        }

        public void ChangeTaskContent(Row row, string content, int id)
        {
            taskService.ChangeContentById(content, id);
            row.getTasks().Find(x => x.ID == id).Name = content;
        }

        public void DeleteTask(Row row, int id)
        {
            row.getTasks().Remove(row.getTasks().Find(x => x.ID == id));
            taskService.DeleteById(id);
        }

        public void DragAndDrop(int firstRowId, int secondRowId, int taskId)
        {
            var firstRow = GetRowById(firstRowId);
            var secondRow = GetRowById(secondRowId);
            secondRow.addTask(firstRow.getTasks().Find(x => x.ID == taskId));
            DeleteTask(firstRow, taskId);
        }
    }
}