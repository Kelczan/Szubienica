
using System.Globalization;



HangMan hangMan = new HangMan("Pajac");
while (!hangMan.IsFinished())
{
    hangMan.rysowanie();
    hangMan.typowanie();


}

