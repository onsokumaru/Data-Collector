
namespace Data_Collector
{
    class MainDataDisplay
    {
        private int measurement;
        private string history;
        public int Measurement
        {
            get { return this.measurement; }
            set { this.measurement = value; }
        }
        public string History
        {
            get { return this.history; }
            set { this.history = value; }
        }
    }
}
