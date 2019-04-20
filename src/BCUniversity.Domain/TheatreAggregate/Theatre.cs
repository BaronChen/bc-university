using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.TheatreAggregate
{
    public class Theatre: AggregateRoot
    {
        public string Name { get; private set; }
        
        public int Capacity { get; private set; }
        
        public Theatre(string id, string name, int capacity) : base(id)
        {
            Name = name;
            Capacity = capacity;
        }
    }
}