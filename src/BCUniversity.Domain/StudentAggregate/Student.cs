using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.StudentAggregate
{
    public class Student: AggregateRoot
    {
        public string Name { get; private set; }
        
        public Student(string name)
        {
            Name = name;
        }
    }
}