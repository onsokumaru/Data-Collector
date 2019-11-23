using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Collector
{
    class Device
    {
        public Device() { } // maybe not necessary, I think c# atuo creates a default constructor
        // method declarations

        public int GetMeasurement()
        {
            // This method will return a random integer between 1 and 10 as a
            // measurement of some imaginary object.

            Random rand = new Random();
            return rand.Next(1, 11);
            
        }
    }
}
