using ITHub.Notes.DAL.Interfaces;
using ITHub.Notes.Domain.DTOs;
using ITHub.Notes.Domain.Entities;
using ITHub.Notes.Services.Helpers.Mappers;
using ITHub.Notes.Services.Interfaces;

namespace ITHub.Notes.Services.Services
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _db;

        public NoteService(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<Response> CreateAsync(NoteDtoToCreate noteDto)
        {
            try
            {
                Note note = NoteMapper.ToCreate(noteDto);
                var createdNote = await _db.Notes.TryCreateAsync(note);

                if (createdNote == null)
                {
                    throw new Exception("Не удалось создать заметку");
                }

                return new Response(createdNote, "Заметка успешно создана", true);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, false);
            }
        }

        public async Task<Response> DeleteAsync(Note note)
        {
            try
            {
                var deletedNote = await _db.Notes.TryDeleteAsync(note);

                if (deletedNote == null)
                {
                    throw new Exception("Не удалось удалить заметку");
                }

                return new Response(deletedNote, "Заметка успешно удалена", true);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, false);
            }
        }

        public async Task<Response> GetAllAsync()
        {
            try
            {
                var allNotes = await _db.Notes.TryGetAllAsync();

                if (allNotes == null)
                {
                    throw new Exception("Не удалось найти заметки");
                }

                return new Response(allNotes, "Список заметок", true);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, false);
            }
        }

        public async Task<Response> GetByIdAsync(Guid id)
        {
            try
            {
                var note = await _db.Notes.TryGetByIdAsync(id);

                if (note == null)
                {
                    throw new Exception("Не удалось найти заметку");
                }

                return new Response(note, "Заметка успешно получена", true);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, false);
            }
        }

        public async Task<Response> UpdateAsync(NoteDtoToUpdate noteDto)
        {
            try
            {
                Note note = NoteMapper.ToUpdate(noteDto);
                var updatedNote = await _db.Notes.TryUpdateAsync(note);

                if (updatedNote == null) 
                {
                    throw new Exception("Не удалось обновить заметку");
                }

                return new Response(updatedNote, "Заметка успешно обновлена", true);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, false);
            }
        }
    }
}
