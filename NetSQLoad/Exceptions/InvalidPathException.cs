using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSQLoad.Exceptions
{
    internal class InvalidPathException : Exception
    {
        public InvalidPathException() { }

        public InvalidPathException(string message) : base(message) { }
    }
}
