using DTO.DTOs.CategoryDtos;
using DTO.DTOs.ContactDtos;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IContactService
    {
        Task<bool> TCreateContactAsync(CreateContactDto createContactDto);
       
        Task<bool> TDeleteContactAsync(int id);
        Task<ContactDto> TGetContactByIdAsync(int id);
        Task<IEnumerable<ContactDto>> TGetAllContactsAsync();
    }
}
