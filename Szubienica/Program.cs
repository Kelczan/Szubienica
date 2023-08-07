
using Microsoft.Data.Sqlite;
using System.Data;
using System.Globalization;
using System.Xml.Linq;

int KatCount(int kat)
{
    using (var connection = new SqliteConnection("Data Source=password.db"))
    {

        connection.Open();
        Random rand = new Random();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
            SELECT count (Passwords_id) FROM Passwords
            WHERE Kat_id = $id
             ";
        command.Parameters.AddWithValue("$id", kat);
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);

                return int.Parse(name);
            }
        }
        return 0;
    }
}
string RandomPassword(int kat_id, int count)
{
    using (var connection = new SqliteConnection("Data Source=password.db"))
    {   
        
        connection.Open();
        Random rand = new Random();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
            SELECT Password FROM(
            SELECT row_number() OVER (ORDER BY Passwords_id ASC) AS rownumber, Password FROM Passwords
            WHERE Kat_id = $kat_id)
            WHERE rownumber = $row
             ";
        command.Parameters.AddWithValue("$row", rand.Next(1,count));
        command.Parameters.AddWithValue("$kat_id", kat_id);
        
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

int SelectKat()
{
    int i = 0;
    while (i < 1 || i > 4)
    {
        Console.WriteLine(@"Wybierz kategorie:/n 
                        1: Zwierzęta/n
                        2: Przedmioty/n
                        3: Kraje/n
                        4: Wyzwyska/n");
        int.TryParse(Console.ReadLine(),out i);
        Console.Clear();
    }
    return i;
}

int kat = SelectKat();
HangMan hangMan = new HangMan(RandomPassword(kat,KatCount(kat)));
while (!hangMan.IsFinished())
{
    hangMan.rysowanie();
    hangMan.typowanie();


}

