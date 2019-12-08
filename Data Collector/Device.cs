using System;
using System.Threading;

namespace Data_Collector
{
    class Device
    {
        private Timer timer;    // declare timer object
        private int data = 0;   // declare variable to hold randomly generated value for GetMeasurement() to return 
        Random rand = new Random();     // create new instance of Random to geneate measurements

        // constructor
       
        public Device() 
        {
            //myData.Limit = 10;
            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(2).TotalMilliseconds);

        }

        // method declarations

        public int GetMeasurement()
        {
            return data;
        }

        private async void timer_Tick(object state)
        {
            // randomly generate new random number and update variable data
            //data = rand.Next(1, 11);
            //myData.Enqueue(data);
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            {
                data = rand.Next(1, 11);
                //myData.Enqueue(data);
            });
        }

    }
}
