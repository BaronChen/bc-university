using System.Threading.Tasks;
using BCUniversity.Service.Dtos.Requests;
using BCUniversity.Service.Theatres;
using Microsoft.AspNetCore.Mvc;

namespace BCUniversity.Api.University.Theatres
{
    [Route("/api/theatres")]
    public class TheatresController: Controller
    {
        private ITheatreService _theatreService;

        public TheatresController(ITheatreService theatreService)
        {
            _theatreService = theatreService;
        }
        
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _theatreService.GetTheatres();

            return Ok(result);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]string id)
        {
            var result = await _theatreService.GetTheatre(id);

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TheatreRequestDto requestDto)
        {
            var result = await _theatreService.CreateTheatre(requestDto);
            return Ok(new { Id = result });
        }
    }
}