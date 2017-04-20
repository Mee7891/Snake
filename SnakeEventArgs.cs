using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class SnakeEventArgs: EventArgs
    {
        public string Message { get; private set; }

        public SnakeEventArgs(string message)
        { Message = message; }

        public SnakeEventArgs() { }
    }
}
