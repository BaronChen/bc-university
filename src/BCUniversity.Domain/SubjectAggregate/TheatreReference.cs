using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.SubjectAggregate
{
    public class TheatreReference: ValueObject
    {
        public string TheatreId { get; private set; }
        public string Name { get; private set; }
        
        public string Capacity { get; private set; }
        
        public TheatreReference(string theatreId, string name, string capacity)
        {
            TheatreId = theatreId;
            Name = name;
            Capacity = capacity;
        }
    }
}