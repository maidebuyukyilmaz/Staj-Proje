using Business.Abstract;
using DTO.DTOs.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace stajProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController (IContactService _contactService): ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var result = await _contactService.TCreateContactAsync(createContactDto);
            if (result)
            {
                return Ok("Contact created successfully.");
            }
            return BadRequest("Failed to create contact.");
        }
        [Authorize(Roles ="admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactService.TDeleteContactAsync(id);
            if (result)
            {
                return Ok("Contact deleted successfully.");
            }
            return NotFound("Failed to delete contact.");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactService.TGetAllContactsAsync();
            return Ok(contacts);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _contactService.TGetContactByIdAsync(id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound("Contact not found.");
        }
    }
}
