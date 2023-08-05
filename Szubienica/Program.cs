
using Microsoft.Data.Sqlite;
using System.Globalization;

string RandomPassword()
{
    using (var connection = new SqliteConnection("Data Source=password.db"))
    {   
        
        connection.Open();
        Random rand = new Random();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
            SELECT Password
            FROM Passwords
            WHERE id = $id
             ";
        command.Parameters.AddWithValue("$id", rand.Next(1,4));
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var name = reader.GetString(0);

                return name;
            }
        }
        return null;
    }
}

HangMan hangMan = new HangMan(RandomPassword());
while (!hangMan.IsFinished())
{
    hangMan.rysowanie();
    hangMan.typowanie();


}

