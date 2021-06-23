using System;
using System.Collections.Generic;
using Xunit;

namespace CustomerClassLibrary.Data.Test
{
    public class DataNotesRepositoryTests
    {
        [Fact]
        public void TestCreate()
        {
            var notesRepository = new NotesRepository();
            notesRepository.Create( new Note() { CustomerId = 2, Text = "Hello" });
        }

        [Fact]
        public void TestRead()
        {
            var notesRepository = new NotesRepository();
            notesRepository.Read(2);
        }

        [Fact]
        public void ReadCustomerNotes()
        {
            var notesRepository = new NotesRepository();
            notesRepository.ReadCustomerNotes(2);
        }

        [Fact]
        public void TestUpdate()
        {
            var notesRepository = new NotesRepository();
            notesRepository.Update(new Note() { NoteId = 3, CustomerId = 5, Text = "ByeBye" });
        }

        [Fact]
        public void TestDelete()
        {
            var notesRepository = new NotesRepository();
            notesRepository.Delete(6);
        }
    }
}
