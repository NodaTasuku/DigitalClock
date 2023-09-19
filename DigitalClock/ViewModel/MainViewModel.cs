namespace DigitalClock.ViewModel
{
    class MainViewModel
    {
        public ClockViewModel ClockViewModel { get; set; }
        public MainViewModel()
        {
            ClockViewModel = new ClockViewModel();
        }
    }
}
