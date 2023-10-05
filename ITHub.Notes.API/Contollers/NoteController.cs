using ITHub.Notes.Domain.DTOs;
using ITHub.Notes.Domain.Entities;
using ITHub.Notes.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITHub.Notes.API.Contollers
{
    [Route("api/v1")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("note/{id}")]
        public async Task<IResult> GetById(Guid id)
        {
            var result = await _noteService.GetByIdAsync(id);

            if (result.Status == false)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }

        [HttpGet("notes")]
        public async Task<IResult> GetAll()
        {
            var result = await _noteService.GetAllAsync();

            if(result.Status == false)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }

        [HttpPost("note")]
        public async Task<IResult> Create(NoteCreateDto noteDto)
        {
            var result = await _noteService.CreateAsync(noteDto);

            if (result.Status == false)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }

        [HttpPut("note")]
        public async Task<IResult> Update(NoteUpdateDto noteDto)
        {
            var result = await _noteService.UpdateAsync(noteDto);

            if (result.Status == false)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }

        [HttpDelete("note")]
        public async Task<IResult> Delete(Note note)
        {
            var result = await _noteService.DeleteAsync(note);

            if (result.Status == false)
            {
                return Results.BadRequest(result);
            }

            return Results.Ok(result);
        }
    }
}
