using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Data_Collector
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MeasureLengthDevice dataCollector = null;
        MainDataDisplay displayData = null;
        Timer appTimer = null;
        public MainPage()
        {
            this.InitializeComponent();
            appTimer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(4).TotalMilliseconds);
            dataCollector = new MeasureLengthDevice();
            displayData = new MainDataDisplay
            {
                Measurement = dataCollector.MostRecentMeasure,
                History = dataCollector.History
            };

            ImperialRB.IsChecked = true;
            //bool collectingData = true;

        }

        private void getCurrentDataBtn_Click(object sender, RoutedEventArgs e)
        {
            currentValueOutputTBlk.Text = dataCollector.MostRecentMeasure.ToString();
            dataHistoryTBox.Text = dataCollector.History;
        }

        private async void timer_Tick(object state)
        {
            // timer to get new measurement from Devide via GetMeasurement and Enqueue in dataCaptured FixedSizeQueue
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () => {
                currentValueOutputTBlk.Text = dataCollector.MostRecentMeasure.ToString();
                dataHistoryTBox.Text = dataCollector.History.ToString();
            });
        }
    }
}
