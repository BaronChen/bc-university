using System;

namespace BCUniversity.Service.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string msg) : base(msg)
        {
            
        }
    }
}