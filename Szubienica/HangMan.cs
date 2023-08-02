using System;

public class HangMan
{
	private string _haslo;
    String zgadniete = "";
    int hp = 4;
    public HangMan(string haslo)
	{
		_haslo = haslo;
	}
    
    public void typowanie()
    {
        bool missed = true;
        bool fail = false;
        string quess = Console.ReadLine();
        if (quess.Length > 0)
        {
            for (int i = 0; i < _haslo.Length; i++)
            {

                if (_haslo[i] == quess[0])
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
                zgadniete = zgadniete + quess[0];
            }
        }
    }
    public bool rysowanie()
    {
        int much = 0;
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ilość żyć: " + hp + "\n\n\n");
        bool missed;
        for (int i = 0; i < _haslo.Length; i++)
        {
            missed = true;
            for (int j = 0; j < zgadniete.Length; j++)
            {
                if (_haslo[i] == zgadniete[j])
                {
                    missed = false;
                    Console.Write(zgadniete[j]);
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

}
