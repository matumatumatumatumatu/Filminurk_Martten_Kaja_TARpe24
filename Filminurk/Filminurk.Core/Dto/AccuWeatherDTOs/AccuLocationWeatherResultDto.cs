using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.Dto.AccuWeatherDTOs
{
    public class AccuLocationWeatherResultDto
    {
        public string CityName { get; set; } = string.Empty;
        public string CityCode {  get; set; } = string.Empty;
        public string EffectiveDate { get; set; } = string.Empty;
        public long EffectiveEpochDate {  get; set; }
        public int Severity { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public long EndEpochDate { get; set; }
        public string DailyForecastsDate { get; set; } = string.Empty;
        public int DailyForecastsEpochDate { get; set; }
        public double TempMinValue { get; set; }
        public string TempMinUnit { get; set; } = string.Empty;
        public string TempMinUnitType { get; set; }
        public double TempMaxValue { get; set; }
        public string TempMaxUnit { get; set; } = string.Empty;
        public string TempMaxUnitType { get; set; }
        public int DayIcon {  get; set; }
        public string DayIconPhrase {  get; set; } = string.Empty;
        public bool DayHasPrecipitation { get; set; }
        public string DayPrecipitation { get; set; } = string.Empty;
        public string DayPrecipitationIntensity { get; set; } = string.Empty;
        public int NightIcon { get; set; }
        public string NightIconPhrase { get; set; } = string.Empty;
        public bool NightHasPrecipitation { get; set; }
        public string NightPrecipitation { get; set; } = string.Empty;
        public string NightPrecipitationIntensity { get; set; } = string.Empty;
        public string MobileLink { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;


    }
}
