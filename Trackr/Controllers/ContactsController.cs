using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trackr.Data;
using Trackr.Interfaces;
using Trackr.Models;

namespace Trackr.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ContactsController> _logger;
        private readonly IMapper _mapper;

        private const string GetContactRouteName = "GetContact";

        public ContactsController(IUnitOfWork unitOfWork, ILogger<ContactsController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _unitOfWork.Contacts.GetAll();
            var result = _mapper.Map<List<ContactDTO>>(contacts);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}", Name = GetContactRouteName)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContact(string id)
        {
            var contact = await _unitOfWork.Contacts.Get(c => c.Id == id);
            var result = _mapper.Map<ContactDTO>(contact);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDTO contactDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateContact)})");
                return BadRequest(ModelState);
            }

            var contact = _mapper.Map<Contact>(contactDTO);
            await _unitOfWork.Contacts.Insert(contact);
            await _unitOfWork.Save();

            return CreatedAtRoute(GetContactRouteName, new { id = contact.Id }, contact);

        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateContact(string id, [FromBody] UpdateContactDTO contactDTO)
        {
            if(!ModelState.IsValid || String.IsNullOrEmpty(id))
            {
                return BadRequest(ModelState);
            }

            var contact = await _unitOfWork.Contacts.Get(c => c.Id == id);
            if (contact == null)
            {
                return BadRequest("Contact not found.");
            }

            contact = _mapper.Map<Contact>(contactDTO);
            _unitOfWork.Contacts.Update(contact);
            await _unitOfWork.Save();

            return Accepted(contact);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteContact(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                _logger.LogError($"Error in {nameof(DeleteContact)}");
                return BadRequest("ID value cannot be empty.");
            }

            var contact = await _unitOfWork.Contacts.Get(c => c.Id == id);
            if (contact == null)
            {
                _logger.LogError($"Error in {nameof(DeleteContact)}");
                return BadRequest("Contact not found.");
            }

            await _unitOfWork.Contacts.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
