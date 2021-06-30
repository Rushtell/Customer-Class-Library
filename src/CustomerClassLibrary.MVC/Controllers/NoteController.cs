using CustomerClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerClassLibrary.MVC.Controllers
{
    public class NoteController : Controller
    {
        NotesRepository notesRepository { get; set; }

        public NoteController()
        {
            notesRepository = new NotesRepository();
        }

        // GET: Note
        public ActionResult Index(int id)
        {
            var notes = notesRepository.ReadCustomerNotes(id);
            ViewBag.CustomerID = id;
            return View(notes);
        }

        // GET: Note/Create
        public ActionResult Create(int id)
        {
            Note note = new Note() { CustomerId = id };
            return View(note);
        }

        // POST: Note/Create
        [HttpPost]
        public ActionResult Create(Note note)
        {
            try
            {
                if (note.Text != "" && note.Text != null)
                {
                    notesRepository.Create(note);
                }
                else
                {
                    ViewBag.Errors = new List<string>() { "Text cant be null" };
                    return View(note);
                }

                return Redirect($"~/Note/Index/{note.CustomerId}");
            }
            catch
            {
                return View(note);
            }
        }

        // GET: Note/Edit/5
        public ActionResult Edit(int id)
        {
            var note = notesRepository.Read(id);
            return View(note);
        }

        // POST: Note/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Note note)
        {
            try
            {
                var updatedNote = notesRepository.Read(id);

                if (note.Text != "" && note.Text != null)
                {
                    updatedNote.Text = note.Text;
                    notesRepository.Update(updatedNote);
                }
                else
                {
                    ViewBag.Errors = new List<string>() { "Text cant be null" };
                    return View(note);
                } 
                
                return Redirect($"~/Note/Index/{updatedNote.CustomerId}");
            }
            catch
            {
                return View(note);
            }
        }

        // GET: Note/Delete/5
        public ActionResult Delete(int id)
        {
            var note = notesRepository.Read(id);
            return View(note);
        }

        // POST: Note/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Note note)
        {
            try
            {
                var deletedNote = notesRepository.Read(id);
                notesRepository.Delete(id);

                return Redirect($"~/Note/Index/{deletedNote.CustomerId}");
            }
            catch
            {
                return View();
            }
        }
    }
}
