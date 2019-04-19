using BCUniversity.Infrastructure.Common;
using BCUniversity.Service.Subject;
using Microsoft.EntityFrameworkCore;

namespace BCUniversity.Infrastructure.Subject
{
    public class SubjectRepository: RepositoryBase<Domain.SubjectAggregate.Subject>, ISubjectRepository
    {
        public SubjectRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}