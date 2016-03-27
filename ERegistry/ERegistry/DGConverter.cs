using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ERegistry
{
    public class DGConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Windows.Controls.DataGridCell cell = (System.Windows.Controls.DataGridCell)value;
            string header = (cell.Column as System.Windows.Controls.DataGridTextColumn).Header.ToString();
            string reg = "";

            if (cell.Column.Header.ToString() == "Reg" && cell.BindingGroup.Items.Count > 0)
            {
                reg = (cell.BindingGroup.Items[0] as Day).Reg.ToString();
                switch (reg)
                {
                    case "  ":
                        return new SolidColorBrush(Utils.ConvertStringToColor("05E27E"));//"259B24"));
                    default:
                        return new SolidColorBrush(Utils.ConvertStringToColor("ff6e7d"));//"E51C23"));
                }
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
