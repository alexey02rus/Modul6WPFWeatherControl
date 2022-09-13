using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task1
{
    public enum PrecipitationEnum
    {
        Sunny,
        Cloudy,
        Rain,
        Snow
    }
    public enum WindDirectionEnum
    {
        N,
        NS,
        E,
        SE,
        S,
        SW,
        W,
        NW
    }
    class WeatherControl : DependencyObject
    {
        private PrecipitationEnum PrecipitationEnum { get; set; }
        private WindDirectionEnum WindDirectionEnum { get; set; }
        public string WindDirection { get;}
        private int windSpeed;
        //private int temp;

        public int WindSpeed
        {
            set
            {
                if (value >=0 && value <=200)
                {
                    windSpeed = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(windSpeed), $"Указанное значение должно находиться в пределах 0-200");
                }
            }
            get
            {
                return windSpeed;
            }
        }

        public WeatherControl(int temp, PrecipitationEnum precipitationEnum, WindDirectionEnum windDirectionEnum, int windSpeed)
        {
            Temp = temp;
            PrecipitationEnum = precipitationEnum;
            WindDirectionEnum = windDirectionEnum;
            WindSpeed = windSpeed;
            WindDirection = windDirectionEnum.ToString();
        }

        public static readonly DependencyProperty TempPropetry;
        public int Temp
        {
            get => (int)GetValue(TempPropetry);
            set => SetValue(TempPropetry, value);
        }
        static WeatherControl()
        {
            TempPropetry = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }
        private static bool ValidateTemp(object value)
        {
            if ((int)value>=-50&& (int)value<=50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            if ((int)baseValue >= -50 && (int)baseValue <= 50)
            {
                return baseValue;
            }
            else
            {
                return baseValue;
            }
        }
    }
}
