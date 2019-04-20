using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.Exceptions;
using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Domain.TheatreAggregate;

namespace BCUniversity.Domain.DomainService
{
    public class UniversityDomainService: IUniversityDomainService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITheatreRepository _theatreRepository;

        public UniversityDomainService(
            IStudentRepository studentRepository,
            ISubjectRepository subjectRepository,
            ITheatreRepository theatreRepository
        )
        {
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _theatreRepository = theatreRepository;
        }

        public async Task EnrolStudentToSubject(string studentId, string subjectId)
        {
            var student = await _studentRepository.GetById(studentId);
            var subject = await _subjectRepository.GetById(subjectId);

            if (student == null || subject == null)
            {
                throw new DomainValidationException("Invalid studentId or subjectId");
            }

            if (subject.HasCapacity())
            {
                student.EnrolInSubject(new SubjectEnrolment(subjectId, subject.Name, subject.GetTotalHours()));
            }
        }
    }
}