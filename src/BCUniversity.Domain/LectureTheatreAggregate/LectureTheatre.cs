using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.LectureTheatreAggregate
{
    public class LectureTheatre: AggregateRoot
    {
        public string Name { get; private set; }
        
        public int Capacity { get; private set; }
        
        public LectureTheatre(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
    }
}