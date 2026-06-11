using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading

namespace Enemy_logic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AN KHALIL: Kommentare "//" LÖSCHEN
            // Variabeln anpassen!!!

            // Die() === Die-check -> Checkt ob der Enemy bereit zum sterben ist


            bool ts = false; // Fuer Unittest - NICHT ANFASSEN!!!
            int speed = 5;

            int hp = 100; // Standartwert Schaden
            int schaden = Convert.ToInt32(Console.ReadLine());

            void damage()
            {
                hp -= schaden;
                Console.Write(hp); //Ersetze mit Debug.log wenn gebraucht

                if (hp == 0)
                {
                    Die();
                    Debug.Log("Enemy DEAD");
                    Console.WriteLine("Enemy Dead"); //Entfernen

                }

            }
            
            private void OnCollisionEnter2D(Collision2D collision)
            {

                if (collision.gameObject.CompareTag("Damage"))
            {




            } }

            // Schauen ob es funktioniert
            // Console.ReadKey();
            // damage();
            // Console.ReadKey();
            // damage();

            Private void Die()
            {
                if (hp == 0) {
                    Console.Log("Enemy is dead!") 
                }
                
            }



        }
    }
}
