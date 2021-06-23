using CustomerClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClassLibrary.WebForms
{
	public partial class NotesList : System.Web.UI.Page
	{
        NotesRepository notesRepository { get; set; }

        public List<Note> listNotes { get; set; }

        public int pageNum { get; set; }

        public int customerId { get; set; }

        public int notesCount { get; set; }

        public NotesList()
        {
            notesRepository = new NotesRepository();
            listNotes = new List<Note>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Request.QueryString["customerId"];
            var noteIdReq = Request.QueryString["noteId"];
            var pageNum = Request.QueryString["page"];
            customerId = Convert.ToInt32(customerIdReq);
            if (pageNum == null)
            {
                Response?.Redirect($"NotesList?page=1&customerId={customerIdReq}");
            }
            this.pageNum = Convert.ToInt32(pageNum);
            if (noteIdReq != null)
            {
                notesRepository.Delete(Convert.ToInt32(noteIdReq));
            }
            var allListNotes = notesRepository.ReadCustomerNotes(Convert.ToInt32(customerIdReq));
            notesCount = allListNotes.Count;
            for (int i = 0; i < 15; i++)
            {
                int num = i + ((Convert.ToInt32(pageNum) - 1) * 15);
                if (num < notesCount)
                {
                    listNotes.Add(allListNotes[num]);
                }
            }
        }
    }
}