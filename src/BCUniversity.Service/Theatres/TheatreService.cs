using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Service.Dtos;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Theatres
{
    public class TheatreService : ITheatreService
    {
        private readonly ITheatreRepository _theatreRepository;

        public TheatreService(ITheatreRepository theatreRepository)
        {
            _theatreRepository = theatreRepository;
        }

        public async Task<IEnumerable<TheatreDto>> GetTheatres()
        {
            return (await _theatreRepository.ListAll()).Select(x => x.ToTheatreDto()).ToList();
        }

        public async Task<string> CreateTheatre(TheatreRequestDto requestDto)
        { 
            var theatre = new Theatre(null, requestDto.Name, requestDto.Capacity);
          
            var id = await _theatreRepository.Save(theatre);

            return id;
        }

        public async Task<TheatreDto> GetTheatre(string id)
        {
            return (await _theatreRepository.GetById(id)).ToTheatreDto();
        }
    }
}