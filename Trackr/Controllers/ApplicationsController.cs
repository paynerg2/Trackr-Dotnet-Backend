using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trackr.ActionFilters;
using Trackr.Core.DTOs;
using Trackr.Data;
using Trackr.Interfaces;

namespace Trackr.Controllers
{
    [Route("api/applications")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ApplicationsController> _logger;
        private readonly IMapper _mapper;

        private const string GetApplicationRouteName = "GetApplication";

        public ApplicationsController(IUnitOfWork unitOfWork, ILogger<ApplicationsController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetApplications()
        {
            var applications = await _unitOfWork.Applications.GetAll();
            var result = _mapper.Map<List<ApplicationDTO>>(applications);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}", Name = GetApplicationRouteName)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetApplication(string id)
        {
            var application = await _unitOfWork.Applications.Get(a => a.Id == id, new List<string> { "Interviews" });
            var result = _mapper.Map<ApplicationDTO>(application);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateApplication([FromBody] CreateApplicationDTO applicationDTO)
        {
            var application = _mapper.Map<Application>(applicationDTO);
            await _unitOfWork.Applications.Insert(application);
            await _unitOfWork.Save();

            return CreatedAtRoute(GetApplicationRouteName, new { id = application.Id }, application);
        }

        [Authorize]
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateApplication(string id, [FromBody] UpdateApplicationDTO applicationDTO)
        {
            var application = await _unitOfWork.Applications.Get(a => a.Id == id);
            if (application == null)
            {
                return BadRequest("Application not found.");
            }

            application = _mapper.Map<Application>(applicationDTO);
            _unitOfWork.Applications.Update(application);
            await _unitOfWork.Save();

            return Accepted(application);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteApplication(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                _logger.LogError($"Error in {nameof(DeleteApplication)}");
                return BadRequest("ID value cannot be empty.");
            }

            var application = await _unitOfWork.Applications.Get(a => a.Id == id);
            if (application == null)
            {
                _logger.LogError($"Error in {nameof(DeleteApplication)}");
                return BadRequest("Application not found.");
            }

            await _unitOfWork.Applications.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
