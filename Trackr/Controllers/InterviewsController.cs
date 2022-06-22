using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trackr.ActionFilters;
using Trackr.Core.DTOs;
using Trackr.Data;
using Trackr.Interfaces;

namespace Trackr.Controllers
{
    [Route("api/interviews")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<InterviewsController> _logger;
        private readonly IMapper _mapper;

        private const string GetInterviewRouteName = "GetInterview";

        public InterviewsController(IUnitOfWork unitOfWork, ILogger<InterviewsController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetInterviews()
        {
            var interviews = await _unitOfWork.Interviews.GetAll();
            var result = _mapper.Map<List<InterviewDTO>>(interviews);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}", Name = GetInterviewRouteName)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetInterview(string id)
        {
            var interview = await _unitOfWork.Interviews.Get(i => i.Id == id);
            var result = _mapper.Map<List<InterviewDTO>>(interview);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateInterview([FromBody] CreateInterviewDTO interviewDTO)
        {
            var interview = _mapper.Map<Interview>(interviewDTO);
            await _unitOfWork.Interviews.Insert(interview);
            await _unitOfWork.Save();

            return CreatedAtRoute(GetInterviewRouteName, new { id = interview.Id }, interview);
        }

        [Authorize]
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateInterview(string id, [FromBody] UpdateInterviewDTO interviewDTO)
        {
            var interview = await _unitOfWork.Interviews.Get(i => i.Id == id);
            if (interview == null)
            {
                return BadRequest("Interview not found.");
            }

            interview = _mapper.Map<Interview>(interviewDTO);
            _unitOfWork.Interviews.Update(interview);
            await _unitOfWork.Save();

            return Accepted(interview);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteInterview(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                _logger.LogError($"Error in {nameof(DeleteInterview)}");
                return BadRequest("ID value cannot be empty.");
            }

            var interview = await _unitOfWork.Interviews.Get(i => i.Id == id);
            if (interview == null)
            {
                _logger.LogError($"Error in {nameof(DeleteInterview)}");
                return BadRequest("Interview not found.");
            }

            await _unitOfWork.Interviews.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
