using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.SubjectAggregate.ValueObjects
{
    public class TheatreReference: ValueObject
    {
        public string TheatreId { get; private set; }

        public TheatreReference(string theatreId)
        {
            TheatreId = theatreId;
        }
    }
}