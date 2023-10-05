using AutoMapper;
using ITHub.Notes.Domain.DTOs;
using ITHub.Notes.Domain.Entities;

namespace ITHub.Notes.Services.Helpers.Mappers
{
    internal class NoteMapper
    {
        public static Note ToUpdate(NoteUpdateDto noteDto)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<NoteUpdateDto, Note>()).CreateMapper();
            var note = mapper.Map<NoteUpdateDto, Note>(noteDto);

            return note;
        }

        public static Note ToCreate(NoteCreateDto noteDto)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<NoteCreateDto, Note>()).CreateMapper();
            var note = mapper.Map<NoteCreateDto, Note>(noteDto);

            return note;
        }
    }
}
