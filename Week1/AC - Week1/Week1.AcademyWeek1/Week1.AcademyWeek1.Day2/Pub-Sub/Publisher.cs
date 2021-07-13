using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.AcademyWeek1.Day2.Pub_Sub
{
    public class Publisher
    {
        //Proprietà
        public string PublisherName { get; set; }

        //Costruttori
        public Publisher() { }
        public Publisher(string publisherName)
        {
            PublisherName = publisherName;
        }

        //Evento
        public event Notify OnPublish;

        //Delegate
        public delegate void Notify(Publisher p, Notification notification);

        public void Publish()
        {
            if(OnPublish != null)
            {
                Notification notificationObj = new Notification()
                {
                    NotificationMessage = "nuova notifica da",
                    NotificationDate = DateTime.Now
                };
                OnPublish(this, notificationObj);
            }
        }


    }
}
