using System;

namespace Week2.SimCard
{
    class Program
    {
        static void Main(string[] args)
        {
            Sim.Offerta offerta = new Sim.Offerta("Special", 100, 1000, 1000);
            Sim sim = new Sim("1234567890", 2.0, new ClientePrivato("", "", DateTime.Now, Sesso.F));

            
        }
    }
}
