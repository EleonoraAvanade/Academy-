using System;
using System.IO;

namespace Week1.AcademyWeek1.Watcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___ Watcher Files ___");
            FileSystemWatcher fsw = new FileSystemWatcher();

            //percorso da tenere monitorato
            fsw.Path = @"C:\Users\AntoniaSacchitella\Desktop\Academy\Week1";

            //definisco il filtro di controllo sui file .txt
            fsw.Filter = "*.txt";

            //fsw.NotifyFilter = NotifyFilters.LastWrite |
            //    NotifyFilters.LastAccess | NotifyFilters.FileName 
            //    | NotifyFilters.DirectoryName;

            //Abilito le notifiche 
            fsw.EnableRaisingEvents = true;

            //Iscrizione all'evento
            fsw.Created += GestoreEvento.HandleNewTextFile;

            Console.WriteLine("Premi q per uscire");
            while (Console.Read() != 'q');

        }
    }
}
