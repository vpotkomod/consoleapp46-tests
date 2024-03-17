using System;

namespace ConsoleApp129
{
    /// <summary>
    ///  создает собственные исключения
    /// </summary>
    internal class MyException : ApplicationException
    {
        /// <summary>
        /// создает собственное исключение
        /// </summary>
        /// <param name="message">выводящаяся ошибка</param>
        public MyException(string aang) : base(aang) { }
    }
}