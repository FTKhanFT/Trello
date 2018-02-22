using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello
{
    class RandomID
    {
        private List<int> boardID; 
        private List<int> rowID; 
        private List<int> taskID;
        private static RandomID instance = null;

        public static RandomID GetInstance()
        {
            if(instance == null)
            {
                instance = new RandomID();
                return instance;
            }
            return instance;
        }

        public RandomID()
        {
            boardID = new List<int>();
            boardID.Add(0);
            rowID = new List<int>();
            rowID.Add(0);
            taskID = new List<int>();
            taskID.Add(0);
        }

        public int IdForBoard()
        {
            int id = boardID.LastOrDefault()+1;
            boardID.Add(id);
            return id;
        }

        public int IdForRow()
        {
            int id = rowID.LastOrDefault() + 1;
            rowID.Add(id);
            return id;
        }

        public int IdForTask()
        {
            int id = taskID.LastOrDefault() + 1;
            taskID.Add(id);
            return id;
        }
    }
}
