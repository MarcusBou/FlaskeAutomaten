using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    class Consumer
    {
        private string name;
        private string type;
        private Buffertray tray;

        public string Name {  get {  return name; } set {  name = value; }  }
        public string Type {  get {  return type; } }
        public Buffertray Tray {  get {  return tray; } }

        public Consumer(string nam, string typ, Buffertray buffer)
        {
            this.name = nam;
            this.type = typ;
            this.tray = buffer;
        }

        public void ConsumeBottle(Bottle bottle)
        {
            Console.WriteLine($"Consumer {this.name} consumes {bottle.Name}");
        }
    }
}
