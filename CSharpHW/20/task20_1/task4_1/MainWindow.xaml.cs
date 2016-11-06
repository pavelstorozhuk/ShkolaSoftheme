using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task4_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       
    
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registrationForm = new RegistrationForm()
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                BirthDay = BirthDayTextBox.Text,
                Gender = GenderTextBox.Text,
                Email = EmailTextBox.Text,
                PhoneNumber = PhoneTextBox.Text,
                AdditionalInfo = new TextRange(AdditionalInfoBox.Document.ContentStart, AdditionalInfoBox.Document.ContentEnd).Text
            };
            var results = new List<ValidationResult>();
            var context = new ValidationContext(registrationForm);

            if (!Validator.TryValidateObject(registrationForm, context, results, true))
            {
                foreach (var error in results)
                {
                  MessageBox.Show(error.ErrorMessage);
                }
            }

        }
    }
}
