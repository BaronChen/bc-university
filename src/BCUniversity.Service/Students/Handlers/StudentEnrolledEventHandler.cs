using System;
using System.Threading.Tasks;
using BCUniversity.Domain.Common.Events;
using BCUniversity.Domain.StudentAggregate.Events;

namespace BCUniversity.Service.Students.Handlers
{
    public class StudentEnrolledEventHandler: IHandler<StudentEnrolledEvent>
    {
        public async Task Handle(StudentEnrolledEvent domainEvent)
        {
            Console.WriteLine($"{domainEvent.StudentName} enrolled in {domainEvent.SubjectName}");
            
            await System.IO.File.WriteAllTextAsync($"./{domainEvent.StudentId}_{domainEvent.SubjectId}",
                $"{domainEvent.StudentName} enrolled in {domainEvent.SubjectName}");
        }
    }
}