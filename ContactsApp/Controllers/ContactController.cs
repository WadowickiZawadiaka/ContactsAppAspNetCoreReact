using AutoMapper;
using ContactsApp.Application.Contact.Queries.GetContactByEncodedName;
using ContactsApp.Application.Contacts.Commands.CreateContact;
using ContactsApp.Application.Contacts.Commands.EditContact;
using ContactsApp.Application.Contacts.Commands.RemoveContact;
using ContactsApp.Application.Contacts.Queries.GetAllContacts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetAll",Name = "GetAllContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllContactsAsync()
        {
            var contacts = await _mediator.Send(new GetAllContactsQuery());

            return Ok(contacts);
        }

        [HttpPost("Create", Name = "CreateContact")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateContactAsync([FromBody] CreateContactCommand command)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    await _mediator.Send(command);
                    return StatusCode(201); //Created successfully
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet("{encodedName}/Details", Name = "GetContactByEncodedName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetContactByEncodedNameAsync(string encodedName)
        {
            var dto = await _mediator.Send(new GetContactByEncodedNameQuery(encodedName));

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPut("{encodedName}/Edit", Name = "EditContactByEncodedName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditContactByEncodedNameAsync(string encodedName, [FromBody] EditContactCommand command)
        {
            try
            {
                var dto = await _mediator.Send(new GetContactByEncodedNameQuery(encodedName));
                if (dto == null)
                {
                    return NotFound();
                }

                _mapper.Map(command, dto);

                await _mediator.Send(command);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{contactId}/Delete", Name = "DeleteContactById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteContactByIdAsync(int contactId)
        {
            try
            {
                var command = new RemoveContactCommand { ContactId = contactId };
                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
