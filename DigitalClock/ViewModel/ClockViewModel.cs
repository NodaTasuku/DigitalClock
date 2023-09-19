using System.ComponentModel;
using System.Windows.Threading;
using System;
using System.Net.Sockets;
using System.Net;

namespace DigitalClock.ViewModel
{
    class ClockViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// View Modelのルールとして実装しておくイベントハンドラ
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// ClockDataModelのインスタンスを保持するプロパティ
        /// </summary>
        public ClockDataModel _ClockData { get; set; }
        /// <summary>
        /// 時間を更新するためのタイマー
        /// </summary>
        private DispatcherTimer timer;
        public ClockViewModel()
        {
            _ClockData = new ClockDataModel();
            // タイマーを作成して設定
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // 1秒ごとに更新
            timer.Tick += Timer_Tick;
            // タイマーを開始
            timer.Start();
        }
        /// <summary>
        /// 日時を示すモデルを更新する関数
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // タイマーのTickイベントが発生したときに現在時刻を取得
            DateTime currentTime = DateTime.Now;
            //DateTime currentTime = GetNetworkTime();
            // 年、月、日、曜日、時、分、秒を設定
            YearData = currentTime.Year.ToString();
            MonthData = currentTime.Month.ToString("00");
            DayData = currentTime.Day.ToString("00");
            DayNameData = $"({currentTime:ddd})"; // 曜日の省略形を取得
            HourData = currentTime.Hour.ToString("00");
            MinuteData = currentTime.Minute.ToString("00");
            SecondData = currentTime.Second.ToString("00");
        }
        public DateTime GetNetworkTime()
        {
            const string ntpServer = "time.windows.com"; // NTPサーバーのアドレスを指定

            UdpClient client = new UdpClient(ntpServer, 123);
            byte[] data = new byte[48];
            data[0] = 0x1B;

            client.Send(data, data.Length);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            data = client.Receive(ref endPoint);

            ulong intPart = BitConverter.ToUInt32(data, 43);
            ulong fractPart = BitConverter.ToUInt32(data, 47);

            ulong milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            DateTime networkDateTime = new DateTime(1900, 1, 1).AddMilliseconds((long)milliseconds);
            return networkDateTime.ToLocalTime();
        }
        // バインドするデータ集
        #region Binding Data
        public string HourData
        {
            get { return _ClockData.HourData; }
            set
            {
                if (value != HourData)
                {
                    _ClockData.HourData = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HourData)));
                }
            }
        }
        public string MinuteData
        {
            get { return _ClockData.MinuteData; }
            set
            {
                if (value != MinuteData)
                {
                    _ClockData.MinuteData = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MinuteData)));
                }
            }
        }
        public string SecondData
        {
            get { return _ClockData.SecondData; }
            set
            {
                _ClockData.SecondData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondData)));
            }
        }
        public string YearData
        {
            get { return _ClockData.YearData; }
            set
            {
                if (value != YearData)
                {
                    _ClockData.YearData = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(YearData)));
                }
            }
        }
        public string MonthData
        {
            get { return _ClockData.MonthData; }
            set
            {
                if (value != MonthData)
                {
                    _ClockData.MonthData = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MonthData)));
                }
            }
        }
        public string DayData
        {
            get { return _ClockData.DayData; }
            set
            {
                if (value != DayData)
                {
                    _ClockData.DayData = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DayData)));
                }
            }
        }
        public string DayNameData
        {
            get { return _ClockData.DayNameData; }
            set
            {
                if (value != DayNameData)
                {
                    _ClockData.DayNameData = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DayNameData)));
                }
            }
        }
        #endregion
    }
}
