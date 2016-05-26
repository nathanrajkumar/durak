using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    [Serializable]
    public class NotSuitedException : Exception
    {
        public NotSuitedException() 
            : base () { }

        public NotSuitedException(string message)
            : base (message) { }
        
    }
}
