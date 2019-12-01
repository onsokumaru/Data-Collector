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
        public MainPage()
        {
            this.InitializeComponent();
            dataCollector = new MeasureLengthDevice();
            displayData = new MainDataDisplay
            {
                Measurement = dataCollector.MostRecentMeasure
            };

            ImperialRB.IsChecked = true;
            bool collectingData = true;

        }

        private void getCurrentDataBtn_Click(object sender, RoutedEventArgs e)
        {
            currentValueOutputTBlk.Text = dataCollector.MostRecentMeasure.ToString();
        }
    }
}
