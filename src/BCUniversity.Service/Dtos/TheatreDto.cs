using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Service.Dtos.Requests;

namespace BCUniversity.Service.Dtos
{
    public class TheatreDto : TheatreRequestDto
    {
        public string Id { get; set; }
    }
    
    public static class ConvertToTheatreDtoExtensions
    {
        public static TheatreDto ToTheatreDto(this Theatre theatre)
        {
            return new TheatreDto()
            {
                Id = theatre.Id,
                Name = theatre.Name,
                Capacity = theatre.Capacity
            };
        }
    }
}