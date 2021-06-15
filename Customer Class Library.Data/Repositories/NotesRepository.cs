using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Customer_Class_Library.Data
{
    public class NotesRepository : BaseRepository
    {
        public void Create(List<string> notes, int id)
        {
            foreach (var note in notes)
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    var command = new SqlCommand(
                        "INSERT INTO [Notes] (CustomerId, Note) " +
                        "VALUES( @CustomerId, @Note)", connection);


                    var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                    {
                        Value = id
                    };

                    var noteParam = new SqlParameter("@Note", SqlDbType.Text)
                    {
                        Value = note
                    };

                    command.Parameters.Add(customerIdParam);
                    command.Parameters.Add(noteParam);

                    command.ExecuteNonQuery();
                }
            }
        }

        public string Read(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * FROM [Notes]" +
                    "WHERE NoteId = @NoteId", connection);

                var noteIdParam = new SqlParameter("@NoteId", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(noteIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["Note"]?.ToString();
                    }
                    return null;
                }
            }
        }

        public void Update(int idNote, string note, int idCustomer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "UPDATE [Notes] " +
                    "SET CustomerId = @CustomerId, Note = @Note " +
                    "WHERE NoteId = @NoteId", connection);

                var noteIdParam = new SqlParameter("@NoteId", SqlDbType.Int)
                {
                    Value = idNote
                };

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = idCustomer
                };

                var noteParam = new SqlParameter("@Note", SqlDbType.Text)
                {
                    Value = note
                };

                command.Parameters.Add(noteIdParam);
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(noteParam);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE FROM [Notes]" +
                    "WHERE NoteId = @NoteId", connection);

                var noteIdParam = new SqlParameter("@NoteId", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(noteIdParam);

                command.ExecuteNonQuery();
            }
        }
    }
}
