using System;

namespace EARLY_ONE
{
    /// <summary>
    /// ����Ԥ��ʵ����
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// ����
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// ���£����϶ȣ�
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// ժҪ
        /// </summary>
        public string Summary { get; set; }
    }
}
