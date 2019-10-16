using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Collector
{
    interface IMeasuringDevice
    {
        // method declarations
        public decimal MetricValue()
        {
            // This method will return a decimal that represents the 
            // metric value of the most recent measurement that was captured

        }

        public decimal ImperialValue()
        {
            // This method will return a decimal that represents the imperial 
            // value of the most recent measurement that was captured

        }

        public void StartCollecting()
        {
            // This method will start the device running. 
            // It will begin collecting measurements and record them 

        }

        public void StopCollecting()
        {
            // This method will stop the device. 
            // It will cease collecting measurements

        }

        public int[] GetRawData()
        {
            // This method will retrieve a copy of all of the recent data 
            // that the measuring device has captured. The data will be returned 
            // as an array of integer values

        }
    }
}
