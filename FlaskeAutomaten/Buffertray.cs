using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    class Buffertray
    {
        private Bottle[] bottleTray;
        public Bottle[] BottleTray {  get {  return bottleTray; }  }
        
        public Buffertray(int length)//in Constructor it creates new botlletray with determined length
        {
            this.bottleTray = new Bottle[length];
        }

        public void Enqueue(Bottle bottle)//with enqueue. it takes the last position. and moves all bottles forward
        {
            bottleTray[bottleTray.Length - 1] = bottle;
            moveBootle();
        }

        public Bottle Dequeue()//Dequeue returns a bottle and make first value zero;
        {
            Bottle newBottle = this.bottleTray[0];
            this.bottleTray[0] = null;
            moveBootle();
            return newBottle;
        }

        public void moveBootle()//moves bottles down the line
        {

            for (int i = bottleTray.Length - 1; i >= 0; i--)
            {
                if (bottleTray[i] == null)
                {
     
                    if ((i + 1) != bottleTray.Length)
                    {
                        bottleTray[i] = bottleTray[i + 1];
                        bottleTray[i + 1] = null;
                    }
                }
            }

        }
    }
}
