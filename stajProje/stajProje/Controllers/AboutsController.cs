using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DTO.DTOs.AboutDtos;
using Entities.concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Markup;

namespace stajProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAuthorAboutService _authorAboutService) : ControllerBase
    {
        [Authorize(Roles ="Author")]
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var result = await _authorAboutService.TCreateAboutAsync(createAboutDto);
            if (result)
            {
                return Ok("About created successfully.");
            }
            return BadRequest("Failed to create about.");
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var result = await _authorAboutService.TDeleteAboutAsync(id);
            if (result)
            {
                return Ok("About deleted successfully.");
            }
            return NotFound("Failed to delete about.");
        }

        [HttpGet("by-author/{authorId}")]
        public async Task<IActionResult> GetAboutByAuthorId(int authorId)
        {
            var about = await _authorAboutService.TGetAboutByAuthorIdAsync(authorId);
            if (about != null)
            {
                return Ok(about);
            }
            return NotFound("About not found.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var about = await _authorAboutService.TGetAboutByIdAsync(id);
            if (about != null)
            {
                return Ok(about);
            }
            return NotFound("About not found.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
            var abouts = await _authorAboutService.TGetAllAboutAsync();
            return Ok(abouts);
        }
        [Authorize(Roles = "Author")]
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var result = await _authorAboutService.TUpdateAboutAsync(updateAboutDto);
            if (result)
            {
                return Ok("About updated successfully.");
            }
            return BadRequest("Failed to update about.");
        }
    }
}

