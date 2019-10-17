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
        private UnitsEnumeration unitsToUse; // not sure about this - could be just the naming
        private int[] dataCaptured;
        private int mostRecentMeasure;

        // construcrtors

        // methods
        public decimal MetricValue()
        {
            throw new NotImplementedException();
        }

        public decimal ImperialValue()
        {
            throw new NotImplementedException();
        }

        public void StartCollecting()
        {
            throw new NotImplementedException();
        }

        public void StopCollecting()
        {
            throw new NotImplementedException();
        }

        public int[] GetRawData()
        {
            throw new NotImplementedException();
        }
    }
}
