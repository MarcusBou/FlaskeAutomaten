using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    class Bottle
    {
        private string name;
        public string Name {  get {  return name; }  }
        public Bottle(string nam)
        {
            name = nam;
        }
    }
}
