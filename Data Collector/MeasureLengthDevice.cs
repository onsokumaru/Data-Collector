using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Collector
{
    class MeasureLengthDevice : IMeasuringDevice
    {
        // fields
        const double CENTIMETERS_IN_AN_INCH = 2.54;
        // private UnitsEnumeration unitsToUse; // not sure about this - could be just the naming
        private enum unitsOfMeasure { imperial, metric };
        private int unitsToUse;
        // changing dataCaptured to Fixed size queue instead of int array - to make updating easier as well as getting raw data
        // private int[] dataCaptured;
        FixedSizeQueue<int> dataCaptured;
        private int mostRecentMeasure;
        private Device dev;

        // construcrtors
        public MeasureLengthDevice()
        {
            // virtual device to provide measurements
            dev = new Device();
            unitsToUse = (int)unitsOfMeasure.imperial;
            mostRecentMeasure = dev.GetMeasurement();
            dataCaptured = new FixedSizeQueue<int>();
            dataCaptured.Limit = 10;
            dataCaptured.Enqueue(mostRecentMeasure);
        }

        // methods
        public decimal MetricValue()
        {
            //throw new NotImplementedException();
            if(unitsToUse == (int)unitsOfMeasure.imperial)
            {
                return (decimal)(mostRecentMeasure * CENTIMETERS_IN_AN_INCH);
            }
            else
            {
                return (decimal)mostRecentMeasure;
            }
        }

        public decimal ImperialValue()
        {
            //throw new NotImplementedException();
            if (unitsToUse == (int)unitsOfMeasure.metric)
            {
                return (decimal)mostRecentMeasure; 
            }
            else
            {
                return (decimal)(mostRecentMeasure * CENTIMETERS_IN_AN_INCH); 
            }
        }

        public void StartCollecting()
        {
            //throw new NotImplementedException();
            //dev.TimerStart();
        }

        public void StopCollecting()
        {
            //throw new NotImplementedException();
            //dev.TimerStop();
        }

        public int[] GetRawData()
        {
            //throw new NotImplementedException();
        }
    }
}
