
using System.Globalization;

void typowanie (string haslo,ref string zgad,ref int hp)
{
    bool missed = true;
    bool fail = false;
    string zgadniete = zgad;
    string quess = Console.ReadLine ();
    if (quess.Length > 0)
    {
        for (int i = 0; i < haslo.Length; i++)
        {

            if (haslo[i] == quess[0])
            {
                missed = false;
                fail = false;
                for (int j = 0; j < zgadniete.Length; j++)
                {
                    
                    if (zgadniete[j] == quess[0])
                    {
                        fail = true;
                        break;
                    }

                }
            }
        }
        if (fail || missed)
        {
            hp--;
        }
        if (!fail)
        {
            zgad = zgad + quess[0];
        }
    }
}
bool rysowanie(string haslo, int hp, string quessed)
{
    int much= 0;
    Console.Clear();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ilość żyć: " + hp+"\n\n\n");
    bool missed;
    for (int i = 0; i < haslo.Length; i++)
    {
        missed = true;
        for (int j = 0; j < quessed.Length; j++)
        {
            if (haslo[i] == quessed[j])
            {
                missed = false;
                Console.Write(quessed[j]);
                break;
            }
            
        }
         if (missed) 
        {
            Console.Write("*");
            much++;
        }
    }
    Console.WriteLine();
    // Console.WriteLine(quessed);
    if (much > 0)
    {
        Console.WriteLine("Zgadnij litere, tylko pierwszy znak sie liczy:");
        return false;
    }
    else 
    {
        Console.WriteLine("Victory!!");     
        return true;
    }

}
String haslo = "EtoChuj";
String zgadniete= "";
int hp = 4;
bool finish = false;
do
{
    if (hp<0)
    {
        break;
    }
    finish = rysowanie(haslo, hp, zgadniete);

    typowanie(haslo, ref zgadniete, ref hp);



} while (finish == false);

