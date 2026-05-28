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

        public GameObject Bullet;
        public Transform firePoint;
        public float shootInterval = 1;    //Interval = zwischen welchen zeitabständen ein Bullet geschossen wird
        public float fireRadius = 0.5;     //Radius um den Gegner herum wo der bullet spawned (wenn der enemy sich bewegt, damit er sich nicht so selbst erschiestst

        bool equipt = true;
        int ammo = 250;



            while (equipt == false)
            {
                Thread.Sleep(250);

                

                if (ammo == 200 || 150 || 100 || 50 ) //Magazin = 50 Bullets //effizienteren weg finden verdammt
                {
                    Console.WriteLine("Reloading..."); //Durch Console.Log ersetzen!!
                    Thread.Sleep(3500);

                }


                ammo--;
                
                if (ammo == 0){
                break;
                }

                Console.WriteLine(Convert.ToString(ammo)); //Durch Console.Log ersetzen!! (ABER NUR FUER TESTING!!) nach Testing rausnehmen. Ansonsten unnoetiger Prozess

            }





        }
    }
}
