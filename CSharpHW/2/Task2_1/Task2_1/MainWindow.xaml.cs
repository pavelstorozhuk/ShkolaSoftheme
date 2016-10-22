using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    enum NumericType:int
    {
        Byte,
        sByte,
        Short,
        uShort,
        Int,
        uInt,
        Long,
        uLong,
        Double,
        Float,
        Decimal
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumericTypeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            switch ((NumericType)NumericTypeComboBox.SelectedIndex)
            {
                case NumericType.Byte: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1}\nDefault ={2}", byte.MaxValue, byte.MinValue, default(byte));
                    
                    break;
                case NumericType.sByte: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1}\nDefault ={2}", sbyte.MaxValue, sbyte.MinValue, default(sbyte));
                    break;
                case NumericType.Short: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1}\nDefault ={2}", short.MaxValue, short.MinValue, default(short));
                    break;
                case NumericType.uShort: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1}\nDefault ={2}", ushort.MaxValue, ushort.MinValue, default(ushort));
                    break;
                
                case NumericType.Int: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1}\nDefault ={2}", int.MaxValue, int.MinValue, default(int));
                    break;
                case NumericType.uInt: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1}\nDefault ={2}", uint.MaxValue, uint.MinValue, default(uint));
                    break;
                case NumericType.Long: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1}\nDefault ={2}", long.MaxValue, long.MinValue, default(long));
                    break;
                case NumericType.uLong: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1}\nDefault ={2}", ulong.MaxValue, ulong.MinValue, default(ulong));
                    break;
                case NumericType.Double: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1} \nDefault ={2}", double.MaxValue, double.MinValue, default(double));
                    break;
                case NumericType.Float: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1} \nDefault ={2}", float.MaxValue, float.MinValue, default(float));
                    break;
                case NumericType.Decimal: Result.Content = String.Format("MaxValue = {0}\nMinValue = {1} \nDefault ={2}", decimal.MaxValue, decimal.MinValue, default(decimal));
                    break;
            }
        }
    }
}
