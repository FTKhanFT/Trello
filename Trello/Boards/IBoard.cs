using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Boards
{
    interface IBoard
    {
        int ID { get; }
        string Color { get; set; }
        string Name { get; set; }
    }
}