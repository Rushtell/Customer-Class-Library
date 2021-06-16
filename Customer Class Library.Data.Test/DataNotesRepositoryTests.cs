using System;
using System.Collections.Generic;
using Xunit;

namespace Customer_Class_Library.Data.Test
{
    public class DataNotesRepositoryTests
    {
        [Fact]
        public void TestCreate()
        {
            var notesRepository = new NotesRepository();
            notesRepository.Create(new List<string>()
            {
                "Hello",
                "World"
            }, 2);
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
            notesRepository.Update(3, "ByeBye", 5);
        }

        [Fact]
        public void TestDelete()
        {
            var notesRepository = new NotesRepository();
            notesRepository.Delete(6);
        }
    }
}
