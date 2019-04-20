using System.Threading.Tasks;
using BCUniversity.Service.Dtos;
using BCUniversity.Service.Dtos.Requests;
using BCUniversity.Service.Subjects;
using Microsoft.AspNetCore.Mvc;

namespace BCUniversity.Api.University.Subjects
{
    [Route("/api/subjects")]
    public class SubjectsController : Controller
    {
        
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _subjectService.GetSubjects();

            return Ok(result);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]string id)
        {
            var result = await _subjectService.GetSubjectById(id);

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SubjectRequestDto requestDto)
        {
            var result = await _subjectService.CreateSubject(requestDto);
            return Ok(new { Id = result });
        }
        
        [HttpGet]
        [Route("{id}/lectures")]
        public async Task<IActionResult> GetLectures([FromRoute]string id)
        {
            var result = await _subjectService.GetLecturesForSubject(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/lectures")]
        public async Task<IActionResult> AddLecture([FromRoute]string id, [FromBody]LectureRequestDto requestDto)
        {
            await _subjectService.CreateLectureForSubject(id, requestDto);
            return Ok();
        }

    }
}