using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace even_odd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bestimmt ob eine Nummer gerade oder Ungerade ist. 
            // Benutzung: Debugging / Generell Logik Vorlage

            int num = 0;
            num = Convert.ToInt32(Console.ReadLine()); //just insert, rm when use and replace it w/ smt else

            if (num % 2 == 0)
            {
                Console.Write("even"); //Ersetzen oder loeschen
                // Hier Einfuegen
            }
            else
            {
                Console.Write("odd"); // Ersetzen oder loeschen
                // Hier Einfuegen
            }

        }
    }
}
