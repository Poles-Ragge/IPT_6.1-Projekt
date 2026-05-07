using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //Unbedingt anfuegen!!

namespace gewehr_logik
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Info
            /*
             * using System.Threading; hinzufuegen damit man Thread.Sleep(); bekommt. Damit kann man einen Delay machen
             * */

            bool equipt = true;
            int ammo = 120;



            while (equipt == false)
            {
                Thread.Sleep(650);

                if (ammo == 60)
                {
                    Console.WriteLine("Reloading..."); //Durch Console.Log ersetzen!!
                    Thread.Sleep(4500);

                }


                ammo--;
                Console.WriteLine(Convert.ToString(ammo));

            }





        }
    }
}
