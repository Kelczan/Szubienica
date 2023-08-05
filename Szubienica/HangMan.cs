using System;
using System.ComponentModel;

public class HangMan
{
	private string _haslo;
    string zgadniete = "";
    int hp = 4;
    public HangMan(string haslo)
	{
		_haslo = haslo;
	}
    public bool IsFinished()
    {
        bool win=false;
        if (hp > 0)
        {
            foreach (char c in _haslo.ToLower())
            {
                if (!zgadniete.Contains(c))
                    return false;
            }
            win = true;
        }
        rysowanie();
        if (win)
        {
            Console.WriteLine("You Win!");
        }
        else Console.WriteLine("You Lose!");
        return true;
    }
    private bool checkletter(char ch)
    {
        foreach (char c in _haslo.ToLower()) 
        {
            if (c == ch)  // sprawdzenie czy litera jest w haśle
            {
                foreach (char c2 in zgadniete.ToLower())
                {
                    if (c2 == ch)
                    {
                        return false; //sprawdzenie czy litera się nie powtarza
                    }
                }
                return true;
            }
        }
        return false;
    }

    public void typowanie()
    {
        bool missed = true;
        bool fail = false;
        string quess = Console.ReadLine();
        if (quess.Length > 0)
        {
            if (checkletter(quess.ToLower()[0]))
            {
                zgadniete += quess.ToLower()[0];
            }
            else
            {
                hp--;
            }
        }
    }
    public void rysowanie()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ilość żyć: " + hp + "\n\n");
        bool missed;
        for (int i = 0; i < _haslo.Length; i++)
        {
            missed = true;
            for (int j = 0; j < zgadniete.Length; j++)
            {
                if (_haslo.ToLower()[i] == zgadniete.ToLower()[j])
                {
                    missed = false;
                    Console.Write(_haslo[i]);
                    break;
                }

            }
            if (missed)
            {
                Console.Write("*");
            }
        }
        Console.WriteLine();
    }

}
