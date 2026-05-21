using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //Unbedingt anfuegen!!

namespace shotgun_logik
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
        public double fireRadius = 0.5;     //Radius um den Gegner herum wo der bullet spawned (wenn der enemy sich bewegt, damit er sich nicht so selbst erschiestst

        bool equipt = true;
        int ammo = 120;



            while (equipt == false)
            {
                Thread.Sleep(1000);

                if (ammo == 100 || 80 || 60 || 40 || 20)
                {
                    Console.WriteLine("Reloading..."); //Durch Console.Log ersetzen!!
                    Thread.Sleep(5000);
                }

                ammo--;


                Console.WriteLine(Convert.ToString(ammo)); //Durch Console.Log ersetzen!! (ABER NUR FUER TESTING!!) nach Testing rausnehmen. Ansonsten unnoetiger Prozess

            }





        }
    }
}
