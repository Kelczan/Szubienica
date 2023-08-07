
using Microsoft.Data.Sqlite;
using System.Data;
using System.Globalization;
using System.Xml.Linq;

int Kat()
{
    using (var connection = new SqliteConnection("Data Source=password.db"))
    {

        connection.Open();
        Random rand = new Random();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
            SELECT * FROM Kategorie
             ";
        Console.WriteLine("Wybierz Kategorie");
        using (var reader = command.ExecuteReader())
        {
            int i = 0;
            while(reader.Read())
            {   
                string str = reader.GetString(0) + ": "+reader.GetString(1);
                Console.WriteLine(str);
                i++;
                
            }
            return i;
        }
       
    }
    

}
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
string RandomPassword(int kat_id)
{
    using (var connection = new SqliteConnection("Data Source=password.db"))
    {   
        
        connection.Open();
        Random rand = new Random();
        var command = connection.CreateCommand();
        command.CommandText =
        @"
            SELECT Password FROM(
            SELECT row_number() OVER (ORDER BY Passwords_id ASC) AS rownumber, Password FROM Kategorie
			INNER JOIN Passwords
			ON Passwords.Kat_id=Kategorie.Kat_id
			WHERE Kategorie.Kat_id = $kat_id
			)
			WHERE rownumber = $row
 
 
             ";
        command.Parameters.AddWithValue("$row", rand.Next(1,KatCount(kat_id)));
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
    
    int i=0;
    int j = 0;
    while (j < 1 || j > i)
    {
        i = Kat();
        int.TryParse(Console.ReadLine(),out j);
        
        Console.Clear();
    }
    return j;
}

int kat = SelectKat();
HangMan hangMan = new HangMan(RandomPassword(kat));
while (!hangMan.IsFinished())
{
    hangMan.rysowanie();
    hangMan.typowanie();


}

