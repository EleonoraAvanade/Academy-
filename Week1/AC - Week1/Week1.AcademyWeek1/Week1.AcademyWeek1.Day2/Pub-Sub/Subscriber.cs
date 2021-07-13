using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.AcademyWeek1.Day2.Pub_Sub
{
    public class Subscriber
    {
        //Proprietà
        public string SubscriberName { get; set; }

        //Metodo di subscribe
        public void Subscribe(Publisher p)
        {
            p.OnPublish += OnNotificationReceived;
        }

        //Metodo di unsubscribe
        public void Unsubscribe(Publisher p)
        {
            p.OnPublish -= OnNotificationReceived;
        }

        //Metodo che gestisce l'esecuzione dell'evento
        private void OnNotificationReceived(Publisher p, Notification notification)
        {
            Console.WriteLine("Ciao " + SubscriberName + ", " + notification.NotificationMessage
                + " " + p.PublisherName + " ha pubblicato qualcosa il"
                + notification.NotificationDate);
        }
    }
}
