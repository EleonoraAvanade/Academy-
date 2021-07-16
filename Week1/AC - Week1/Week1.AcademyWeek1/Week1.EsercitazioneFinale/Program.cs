using System;
using System.IO;

namespace Week1.EsercitazioneFinale
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = @"C:\Users\AntoniaSacchitella\Desktop\Academy\Week1";
            fsw.Filter = "spese.txt";

            fsw.EnableRaisingEvents = true;

            fsw.Created += Monitoraggio.HandleNewFile;

            Console.WriteLine("Premi q per uscire");
            while (Console.Read() != 'q') ;
        }
    }
}
