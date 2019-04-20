using System;

namespace BCUniversity.Service.Exceptions
{
    public class ResourceNotFoundException: Exception
    {
        public ResourceNotFoundException(string msg) : base(msg)
        {
            
        }
    }
}