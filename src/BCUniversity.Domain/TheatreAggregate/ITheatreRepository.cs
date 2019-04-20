using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.Common;

namespace BCUniversity.Domain.TheatreAggregate
{
    public interface ITheatreRepository: IRepository<Theatre>
    {
        Task<IEnumerable<Theatre>> GetByIds(IEnumerable<string> ids);
    }
}