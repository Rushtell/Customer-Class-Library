using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data
{
    public class EFNotesRepository : IRepository<Note>
    {
        DataContext database { get; set; }

        public EFNotesRepository()
        {
            database = new DataContext();
        }

        public virtual int Create(Note entity)
        {
            database.Notes.Add(entity);
            database.SaveChanges();
            return entity.NoteId;
        }

        public virtual Note Read(int id)
        {
            return database.Notes.FirstOrDefault(e => e.NoteId == id);
        }

        public virtual Note Update(Note entity)
        {
            var note = database.Notes.Where(e => e.NoteId == entity.NoteId).FirstOrDefault();

            note.CustomerId = entity.CustomerId;
            note.Text = entity.Text;

            database.SaveChanges();
            return note;
        }
        
        public virtual bool Delete(int id)
        {
            try
            {
                database.Notes.Remove(database.Notes.FirstOrDefault(e => e.NoteId == id));
                database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual List<Note> ReadCustomerNotes(int id)
        {
            return database.Notes.Where(e => e.CustomerId == id).ToList();
        }

        public virtual bool DeleteAllByCustomerId(int id)
        {
            try
            {
                var listToDelete = database.Notes.Where(e => e.CustomerId == id).ToList();
                foreach (var item in listToDelete)
                {
                    database.Notes.Remove(item);
                }
                database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
