using System;

namespace ConsoleApp129
{
    internal class MyException : ApplicationException
    {
        public MyException(string aang) : base(aang) { }
    }
}