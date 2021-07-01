using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CustomerClassLibrary.Data
{
    public class NotesRepository : BaseRepository, IRepository<Note>
    {
        public int Create(Note note)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "INSERT INTO [Notes] (CustomerId, Note) " +
                    "VALUES( @CustomerId, @Note); " +
                    "SELECT CAST(scope_identity() AS int)", connection);


                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = note.CustomerId
                };

                var noteParam = new SqlParameter("@Note", SqlDbType.Text)
                {
                    Value = note.Text
                };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(noteParam);

                return (int)command.ExecuteScalar();
            }
        }

        public Note Read(int id)
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
                        return new Note()
                        {
                            NoteId = id,
                            CustomerId = Convert.ToInt32(reader["CustomerId"]?.ToString()),
                            Text = reader["Note"]?.ToString()
                        };
                    }
                    return null;
                }
            }
        }

        public List<Note> ReadCustomerNotes(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * FROM [Notes]" +
                    "WHERE CustomerId = @CustomerId", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(customerIdParam);

                using (var reader = command.ExecuteReader())
                {
                    List<Note> notes = new List<Note>();
                    while (reader.Read())
                    {
                        notes.Add(new Note()
                        {
                            NoteId = Convert.ToInt32(reader["NoteId"]?.ToString()),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]?.ToString()),
                            Text = reader["Note"]?.ToString()
                        });
                    }
                    return notes;
                }
            }
        }

        public Note Update(Note note)
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
                    Value = note.NoteId
                };

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = note.CustomerId
                };

                var noteParam = new SqlParameter("@Note", SqlDbType.Text)
                {
                    Value = note.Text
                };

                command.Parameters.Add(noteIdParam);
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(noteParam);

                command.ExecuteNonQuery();
                return note;
            }
        }

        public bool Delete(int id)
        {
            try
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public void DeleteAllByCustomerId(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE FROM [Notes]" +
                    "WHERE CustomerId = @CustomerId", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(customerIdParam);

                command.ExecuteNonQuery();
            }
        }
    }
}
