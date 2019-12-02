
namespace Data_Collector
{
    interface IMeasuringDevice
    {
        // method declarations
        decimal MetricValue(); // This method will return a decimal that represents the metric value of the most recent measurement that was captured.

        decimal ImperialValue(); // This method will return a decimal that represents the imperial value of the most recent measurement that was captured

        void StartCollecting(); // This method will start the device running.

        void StopCollecting(); // This method will stop the device.

        FixedSizeQueue<int> GetRawData(); // This method will retrieve a copy of all of the recent data 
    }
}
