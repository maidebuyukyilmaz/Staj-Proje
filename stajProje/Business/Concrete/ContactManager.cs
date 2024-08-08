using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DTO.DTOs.ContactDtos;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager(IContactRepository _contactRepository, IMapper _mapper) : IContactService
    {
        public async Task<bool> TCreateContactAsync(CreateContactDto createContactDto)
        {
           var contact=_mapper.Map<Contact>(createContactDto);
            return await _contactRepository.CreateAsync(contact);
        }

        public async Task<bool> TDeleteContactAsync(int id)
        {
            return await _contactRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ContactDto>> TGetAllContactsAsync()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ContactDto>>(contacts);
        }

        public async Task<ContactDto> TGetContactByIdAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            return _mapper.Map<ContactDto>(contact);
        }
    }
}
