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
        public float bulletSpeed = 10;     //Geschwindigkeit vom Bullet
        public float shootInterval = 2;    //Interval = zwischen welchen zeitabständen ein Bullet geschossen wird
        public float fireRadius = 0.5;     //Radius um den Gegner herum wo der bullet spawned (wenn der enemy sich bewegt, damit er sich nicht so selbst erschiestst

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
                Console.WriteLine(Convert.ToString(ammo)); //Durch Console.Log ersetzen!! (ABER NUR FUER TESTING!!) nach Testing rausnehmen. Ansonsten unnoetiger Prozess

            }





        }
    }
}
