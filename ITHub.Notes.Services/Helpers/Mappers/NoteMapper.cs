using AutoMapper;
using ITHub.Notes.Domain.DTOs;
using ITHub.Notes.Domain.Entities;

namespace ITHub.Notes.Services.Helpers.Mappers
{
    internal class NoteMapper
    {
        public static Note ToUpdate(NoteDtoToUpdate noteDto)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<NoteDtoToUpdate, Note>()).CreateMapper();
            var note = mapper.Map<NoteDtoToUpdate, Note>(noteDto);

            return note;
        }

        public static Note ToCreate(NoteDtoToCreate noteDto)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<NoteDtoToCreate, Note>()).CreateMapper();
            var note = mapper.Map<NoteDtoToCreate, Note>(noteDto);

            return note;
        }
    }
}
