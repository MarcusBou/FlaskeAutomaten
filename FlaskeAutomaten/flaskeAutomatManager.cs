using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FlaskeAutomaten
{
    class flaskeAutomatManager
    {
        private static int bottleTraySize = 10;

        private static Buffertray mainTray = new Buffertray(bottleTraySize);
        private static Buffertray sodaTray = new Buffertray(bottleTraySize);
        private static Buffertray beerTray = new Buffertray(bottleTraySize);

        producer producer = new producer();
        Consumer beerConsum = new Consumer("Beer Collector", "Beer", beerTray);
        Consumer sodaConsum = new Consumer("Soda Collector", "Soda", sodaTray);

        public void Threads()
        {
            Thread p1 = new Thread(production);
            Thread s1 = new Thread(takeToSplitter);
            Thread c1 = new Thread(ConsumeFromTray);
            Thread c2 = new Thread(ConsumeFromTray);

            p1.Name = "Producer";
            s1.Name = "Splitter";
            c1.Name = "Soda";
            c2.Name = "Beer";

            p1.Start();
            s1.Start();
            c1.Start(beerConsum);
            c2.Start(sodaConsum);
        }

        public void production()
        {
            while (true)
            {
                while (mainTray.BottleTray[bottleTraySize - 1] == null)
                {
                    mainTray.Enqueue(producer.GetBottle());
                }
            }
        }

        public void takeToSplitter()
        {
            while (true)
            {
                while (mainTray.BottleTray[0] != null)
                {
                    if (mainTray.BottleTray[0].Name == beerConsum.Type)
                    {
                        Console.WriteLine($"[Sorter] sends to {beerConsum.Name}");
                        beerTray.Enqueue(mainTray.Dequeue());
                        Thread.Sleep(500);
                    }
                    else if (mainTray.BottleTray[0].Name == sodaConsum.Type)
                    {
                        Console.WriteLine($"[Sorter] sends to {sodaConsum.Name}");
                        sodaTray.Enqueue(mainTray.Dequeue());
                        Thread.Sleep(200);
                    }
                }
            }
        }

        public void ConsumeFromTray(object cons)
        {
            Consumer consumer = (Consumer)cons;
            while (true)
            {
                while (consumer.Tray.BottleTray[0] != null)
                {
                    consumer.ConsumeBottle(consumer.Tray.Dequeue());
                    Thread.Sleep(500);
                }
            }
        }
    }
}
