using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Service.Dtos;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Theatres
{
    public interface ITheatreService
    {
        Task<IEnumerable<TheatreDto>> GetTheatres();

        Task<string> CreateTheatre(TheatreRequestDto requestDto);
        
        Task<TheatreDto> GetTheatre(string id);

    }
}