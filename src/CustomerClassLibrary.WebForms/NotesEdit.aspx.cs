using CustomerClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
	public partial class NotesEdit : System.Web.UI.Page
	{
        NotesRepository notesRepository { get; set; }

        string customerIdReq { get; set; }

        string noteIdReq { get; set; }

        public NotesEdit()
        {
            notesRepository = new NotesRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            customerIdReq = Request.QueryString["customerId"];

            if (!IsPostBack)
            {
                noteIdReq = Request.QueryString["noteId"];

                LoadNote(noteIdReq);
            }
        }

        public void LoadNote(string noteIdReq)
        {
            if (noteIdReq != null)
            {
                var note = notesRepository.Read(Convert.ToInt32(noteIdReq));

                noteText.Text = note.Text;
            }
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                noteIdReq = Request.QueryString["noteId"];
            }

            var note = new Note()
            {
                CustomerId = Convert.ToInt32(customerIdReq),
                Text = noteText?.Text
            };

            if (noteIdReq != null)
            {
                note.NoteId = Convert.ToInt32(noteIdReq);
                notesRepository.Update(note);
            }
            else notesRepository.Create(note);

            Response?.Redirect($"NotesList?customerId={customerIdReq}");
        }
    }
}