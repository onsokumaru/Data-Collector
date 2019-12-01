using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.ApplicationModel.Core;

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
        private int mostRecentMeasure = 0;
        private Device dev;
        private Timer timer;

        // construcrtors
        public MeasureLengthDevice()
        {
            // virtual device to provide measurements
            dev = new Device();
            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(15).TotalMilliseconds);
            unitsToUse = (int)unitsOfMeasure.imperial;
            mostRecentMeasure = dev.GetMeasurement();
            dataCaptured = new FixedSizeQueue<int>();
            dataCaptured.Limit = 10;
            dataCaptured.Enqueue(mostRecentMeasure);
        }

        // methods
        private async void timer_Tick(object state)
        {
            // timer to get new measurement from Devide via GetMeasurement and Enqueue in dataCaptured FixedSizeQueue
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () => {
                mostRecentMeasure = dev.GetMeasurement();
                dataCaptured.Enqueue(mostRecentMeasure);
            });
        }
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

        public FixedSizeQueue<int> GetRawData()
        {
            throw new NotImplementedException();
        }
    }
}
