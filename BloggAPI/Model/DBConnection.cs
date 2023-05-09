using System.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace BloggAPI.Model
{
    public class DBConnection
    {
        public List<Blogg> GetAllBloggs()
        {
            List<Blogg> bloggs= new List<Blogg>();

            var cmd = GetSqlCommand();

            cmd.CommandText = "SELECT * FROM Blogg";

            var reader = cmd.ExecuteReader();


            
            while (reader.Read())
            {
                var dateTimeString = reader["Date"].ToString();

                var blogg = new Blogg()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    Date = DateTime.Parse(dateTimeString)
                };
                bloggs.Add(blogg);

            }
            return bloggs;
        }
        public Blogg GetBloggById(int id)
        {
            var cmd = GetSqlCommand();

            cmd.CommandText = "SELECT * FROM Blogg Where Id = @id";
            cmd.Parameters.AddWithValue("id", id);

            var reader = cmd.ExecuteReader();



            while (reader.Read())
            {
                var dateTimeString = reader["Date"].ToString();

                var blogg = new Blogg()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Title = reader["Title"].ToString(),
                    Content = reader["Content"].ToString(),
                    Date = DateTime.Parse(dateTimeString)
                };
                return blogg;

            }
            return null;

        }
        public void SaveBlogg(Blogg blogg)
        {
            var cmd = GetSqlCommand();

            cmd.CommandText = "INSERT INTO Blogg(Title, Content, Date) VALUES (@title, @content, @Date)";
            
            cmd.Parameters.AddWithValue("title", blogg.Title);
            cmd.Parameters.AddWithValue("content", blogg.Content);
            cmd.Parameters.AddWithValue("date", blogg.Date);

            cmd.ExecuteNonQuery();


        }
        public void UpdateBlogg(int id, Blogg blogg) 
        {
            var cmd = GetSqlCommand();

            cmd.CommandText = "UPDATE Blogg SET Title=@title, Content=@content, Date=@date WHERE Id=@id";
            cmd.Parameters.AddWithValue("title", blogg.Title);
            cmd.Parameters.AddWithValue("content", blogg.Content);
            cmd.Parameters.AddWithValue("Date", blogg.Date);
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }
        public void DeleteBloggById(int id)
        {
            var cmd = GetSqlCommand();

            cmd.CommandText = "DELETE FROM Blogg WHERE Id=@id";

            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();

        }
        private SqlCommand GetSqlCommand()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=BloggApiDB;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = System.Data.CommandType.Text;

            return cmd;

        }
    }
}
