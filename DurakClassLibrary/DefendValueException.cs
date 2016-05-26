using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakClassLibrary
{
    [Serializable]
    public class DefendValueException : Exception
    {
        public DefendValueException() 
            : base () { }

        public DefendValueException(string message)
            : base (message) { }
    }
}
