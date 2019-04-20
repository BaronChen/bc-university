using System;
using BCUniversity.Domain.Common;
using BCUniversity.Domain.Exceptions;

namespace BCUniversity.Domain.TheatreAggregate
{
    public class Theatre: AggregateRoot
    {
        public string Name { get; private set; }
        
        public int Capacity { get; private set; }
        
        public Theatre(string id, string name, int capacity) : base(id)
        {
            Name = name;
            if (capacity <= 0)
            {
                throw new DomainValidationException("Invalid capacity for theatre");
            }
            Capacity = capacity;
        }
    }
}