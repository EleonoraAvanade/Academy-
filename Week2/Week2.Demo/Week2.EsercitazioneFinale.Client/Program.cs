using System;
using System.Collections.Generic;
using Week2.EsercitazioneFinale.Lib;

namespace Week2.EsercitazioneFinale.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Create Bank Account =====");
            try { 
            var bankName = ConsoleHelper.GetData("Insert Bank Name");
            var accountNumber = ConsoleHelper.GetData("Insert Account No");

            Account accAntonia = new Account(bankName, accountNumber, 1000);

            bool quit = false;
            do
            {
                string command = ConsoleHelper.BuildMenu($"Main {bankName}", new List<string>
                {
                    "[ 1 ] - Deposit",
                    "[ 2 ] - Prelievo",
                    "[ 3 ] - Print Statement",
                    "[ q ] - Quit"
                });

                switch (command)
                {
                    case "1":
                        //add movement
                        var movDeposit = ConsoleHelper.NewMovement();
                        if(movDeposit != null)
                        {
                            //accAntonia = accAntonia + movDeposit;
                            accAntonia += movDeposit;
                        }
                        break;
                    case "2":
                        //add prelievo
                        var movPrelievo = ConsoleHelper.NewMovement();
                        if(movPrelievo != null)
                        {
                            accAntonia -= movPrelievo;
                        }
                        break;
                    case "3":
                        //print statement
                        Console.Clear();
                        Console.WriteLine(accAntonia.Statement());
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "q":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Choice another command");
                        break;
                }

            } while (!quit);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
