using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Service.Theatres.Dtos;

namespace BCUniversity.Service.Theatres
{
    public interface ITheatreService
    {
        Task<IEnumerable<Theatre>> GetTheatres();

        Task<string> CreateTheatre(TheatreRequestDto requestDto);
        
        Task<Theatre> GetTheatre(string id);

    }
}