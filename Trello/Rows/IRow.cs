﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Rows
{
    interface IRow
    {
        int ID { get; }
        string Name { get; set; }
    }
}
