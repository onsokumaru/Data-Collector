using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Timers;

namespace Data_Collector
{
    class Device
    {
        private Timer timer;    // declare timer object
        private int data = 0;   // declare variable to hold randomly generated value for GetMeasurement() to return 
        FixedSizeQueue<int> myData = new FixedSizeQueue<int>(); // see class declaration for description
        Random rand = new Random();     // create new instance of Random to geneate measurements

        // constructor
       
        public Device() 
        {
            myData.Limit = 10;
            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(15).TotalMilliseconds);
            //// create timer event - getting error that Timer does not have constructor that takes 4 arguments
            //// going to try something different
            //timer = new Timer(15000);
            //// fire elapsed event when timer expires
            //timer.Elapsed += OnTimedEvent;
            //timer.AutoReset = true;
            //timer.Enabled = true;

        }

        // method declarations

        public int GetMeasurement()
        {
            return data;
        }

        public string History => PrintValues(myData);

        public string PrintValues(FixedSizeQueue<int> myQueue)
        {
            StringBuilder myString = new StringBuilder();
            foreach ( var i in myQueue.q)
            {
                myString.AppendLine(i.ToString());
            }

            return myString.ToString();
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
                myData.Enqueue(data);
            });
        }

        //private void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{
        //    // example from docs.microsoft.com
        //    data = rand.Next(1, 11);
        //    myData.Enqueue(data);
            
        //}

        // method to stop timer
        //public void TimerStop()
        //{
        //    timer.Stop();
        //}

        //// method to start timer if the timer is stopped
        //public void TimerStart()
        //{
        //    timer.Start();
        //}
    }
}
