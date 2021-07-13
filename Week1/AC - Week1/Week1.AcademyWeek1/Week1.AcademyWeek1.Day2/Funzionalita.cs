using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.AcademyWeek1.Day2.Pub_Sub;

namespace Week1.AcademyWeek1.Day2
{
    public class Funzionalita
    {
        public static int MySum(int a, int b)
        {
            return a + b;
        }

        public static int ReturnZero(int c, int d)
        {
            return 0;
        }

        #region Eventi
        public static void DemoEventi()
        {
            //Creazione dei publisher
            Publisher youtube = new Publisher("YouTube");
            Publisher instagram = new Publisher("Instagram");

            //Creazione dei subscriber
            Subscriber sub1 = new Subscriber()
            {
                SubscriberName = "Antonia"
            };
            Subscriber sub2 = new Subscriber()
            {
                SubscriberName = "Mario"
            };
            Subscriber sub3 = new Subscriber()
            {
                SubscriberName = "Giovanni"
            };

            //Metodo di sottoscrizione
            sub1.Subscribe(youtube);
            sub1.Subscribe(instagram);

            sub2.Subscribe(youtube);

            sub3.Subscribe(instagram);

            youtube.Publish();

            Console.WriteLine("-------------");

            instagram.Publish();

            Console.WriteLine("--------------");

            sub1.Unsubscribe(youtube);

            youtube.Publish();

            

        }
        #endregion
    }
}
