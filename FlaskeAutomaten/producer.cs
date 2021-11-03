using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    class producer
    {
        private string[] names = new string[] { "Soda", "Beer" };
        Random rand = new Random();

        public Bottle GetBottle()//chooses randomly between the two and returns bottle
        {
            int typeChooser = rand.Next(0, names.Length);
            return new Bottle(names[typeChooser]);
        }
    }
}
