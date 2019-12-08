using System;
using System.Text;
using System.Threading;

namespace Data_Collector
{
    class MeasureLengthDevice : IMeasuringDevice
    {
        // fields
        const double CENTIMETERS_IN_AN_INCH = 2.54;
        private enum unitsOfMeasure { imperial, metric };
        private unitsOfMeasure unitsToUse;
        //private unitsOfMeasure UnitsToUse
        //{
        //    get { return this.unitsToUse; }
        //    set { this.unitsToUse = value; }
        //}
        // changing dataCaptured to Fixed size queue instead of int array - to make updating easier as well as getting raw data
        // private int[] dataCaptured;
        FixedSizeQueue<int> dataCaptured;

        private int mostRecentMeasure = 0;
        public int MostRecentMeasure
        {
            get { return this.mostRecentMeasure; }
        }
        private Device dev;
        private Timer timer;

        // construcrtors
        public MeasureLengthDevice()
        {
            // virtual device to provide measurements
            dev = new Device();
            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(4).TotalMilliseconds);
            unitsToUse = unitsOfMeasure.imperial;
            mostRecentMeasure = dev.GetMeasurement();
            dataCaptured = new FixedSizeQueue<int>();
            dataCaptured.Limit = 10;
            //dataCaptured.Enqueue(mostRecentMeasure);
        }



        // methods
        public string History => PrintValues(dataCaptured);


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
            if(unitsToUse != unitsOfMeasure.imperial)
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
            if (unitsToUse != unitsOfMeasure.metric)
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
            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(4).TotalMilliseconds);
        }

        public void StopCollecting()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public FixedSizeQueue<int> GetRawData()
        {
            throw new NotImplementedException();
        }

        public string PrintValues(FixedSizeQueue<int> myQueue)
        {
            StringBuilder myString = new StringBuilder();
            foreach (var i in myQueue.q)
            {
                myString.Append(i.ToString() + " ");
            }

            return myString.ToString();
        }

        public void setUnitImperial()
        {
            this.unitsToUse = unitsOfMeasure.imperial;
        }

        public void setUnitMetric()
        {
            this.unitsToUse = unitsOfMeasure.metric;
        }
    }
}
