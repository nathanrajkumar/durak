using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    public class NotSameRankException : Exception
    {
        public NotSameRankException() 
            : base () { }

        public NotSameRankException(string message)
            : base (message) { }
    }
}
