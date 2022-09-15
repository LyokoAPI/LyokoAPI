using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyokoAPI.Exceptions
{
    public abstract class LapiException : Exception
    {
        public abstract void Resolve(string parameter = "");
    }
}
