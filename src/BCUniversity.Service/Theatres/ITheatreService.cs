using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Theatres
{
    public interface ITheatreService
    {
        Task<IEnumerable<Theatre>> GetTheatres();

        Task<string> CreateTheatre(TheatreRequestDto requestDto);
        
        Task<Theatre> GetTheatre(string id);

    }
}