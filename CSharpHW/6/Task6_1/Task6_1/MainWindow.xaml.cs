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

namespace Task6_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random;
        private int number;
        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            number = random.Next(1,10);
        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (number == Convert.ToInt32(textbox.Text))
                {
                    Result.Content = "you guessed the number";
                }
                else
                    Result.Content = String.Format("\nyou did'nt guess the number {0}", number);
                number = random.Next(1, 10);
            }
            catch(FormatException ex)
            {
                MessageBox.Show("not correct input");
            }
        }

      
    }
}
