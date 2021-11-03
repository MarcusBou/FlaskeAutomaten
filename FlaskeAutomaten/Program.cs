using System;

namespace FlaskeAutomaten
{
    class Program
    {
        static void Main(string[] args)
        {
            flaskeAutomatManager fam = new flaskeAutomatManager();
            fam.Threads();
        }
    }
}
