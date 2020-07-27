using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FullScratchCore.Models
{
    public class ByteSIConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double InputValue = (long)value;
            string OutputValue = string.Empty;

            string[] SICode = new string[] { "B", "KB", "MB", "GB", "TB" };

            for (int i = 0; i < SICode.Length; i++)
            {
                if (InputValue / 1024f < 1d)
                {
                    OutputValue = InputValue + SICode[i];
                    break;
                }
                else
                {
                    InputValue = Math.Round(InputValue / 1024d, 3, MidpointRounding.AwayFromZero);
                }

            }
            return OutputValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

