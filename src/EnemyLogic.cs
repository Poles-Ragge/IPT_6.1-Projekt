using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_logic
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int hp = 100; // Standartwert Schaden
            int schaden = Convert.ToInt32(Console.ReadLine());

            void damage()
            {
                hp -= schaden;
                Console.Write(hp);

                if (hp == 0)
                {
                    //Die();
                    // Debug.Log("Enemy DEAD");
                    Console.WriteLine("Enemy Dead");

                }

            }
            /*
            private void OnCollisionEnter2D(Collision2D collision)
            {

                if (collision.gameObject.CompareTag("Damage"))
            {




            } }*/

            // Schauen ob es funktioniert
            Console.ReadKey();
            damage();
            Console.ReadKey();
            damage();



        }
    }
}
