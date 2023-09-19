using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock.ViewModel
{
    /// <summary>
    /// 日時データを保持するモデルクラス
    /// </summary>
    class ClockDataModel
    {
        /// <summary>
        /// 月データ
        /// </summary>
        public string YearData { get; set; } = "2023";
        /// <summary>
        /// 月データ
        /// </summary>
        public string MonthData { get; set; } = "12";
        /// <summary>
        /// 日データ
        /// </summary>
        public string DayData { get; set; } = "31";
        /// <summary>
        /// 曜日データ
        /// </summary>
        public string DayNameData { get; set; } = "(月)";
        /// <summary>
        /// 時間データ
        /// </summary>
        public string HourData { get; set; } = "12";
        /// <summary>
        /// 分データ
        /// </summary>
        public string MinuteData { get; set; } = "00";
        /// <summary>
        /// 秒データ
        /// </summary>
        public string SecondData { get; set; } = "00";
    }
}
