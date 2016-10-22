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
using System.Text.RegularExpressions;

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
        private bool CheckFirstAndLastName(string name)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Zа-яА-Я]+$") && name.Length<255)
            {
                return true;
            }
            else  return false;
        }
        private bool CheckDateOfBirth(string dateOfBirth)
        {
            try
            {

                string[] parts = dateOfBirth.Split('.');
                int day = Convert.ToInt32(parts[0]);
                int month = Convert.ToInt32(parts[1]);
                int year = Convert.ToInt32(parts[2]);


                if (Regex.IsMatch(dateOfBirth, @"^[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]$")
                    && day > 0 && day < 32 && month > 0 && month < 13 && year > 1900 && year < 2016)
                {
                    return true;
                }
                else return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        private bool CheckEmail (string email)
        {
            if (email.Contains("@") && email.Length < 255)
            {
                return true;
            }
            else return false;
        }
        private bool CheckPhoneNumber(string phoneNumber)
        {
            if (Regex.IsMatch(phoneNumber, @"^[0-9]+$") && phoneNumber.Length == 12)
            {
                return true;
            }
            else return false;
        }
    
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFirstAndLastName(FirstNameTextBox.Text))
            {
                FirstName_label.Content = "validate";
                FirstName_label.Foreground = Brushes.Green;
            }
            else 
            {
                FirstName_label.Content = "not validate, only letters and length<255";
                FirstName_label.Foreground = Brushes.Red;
            }
            if (CheckFirstAndLastName(LastNameTextBox.Text))
            {
                LastName_label.Content = "validate";
                LastName_label.Foreground = Brushes.Green;
            }
            else
            {
               LastName_label.Content = "not validate, only letters and length<255";
                LastName_label.Foreground = Brushes.Red;
            }
            if (CheckDateOfBirth(BirthDayTextBox.Text))
            {
                BirthDayLabel.Content = "validate";
                BirthDayLabel.Foreground = Brushes.Green;
            }
            else 
            {
                BirthDayLabel.Content = "not validate, format dd.mm.yyyyyear 0 < day < 32, \n 0 < month < 13, 1900 < year < current year,";
                BirthDayLabel.Foreground = Brushes.Red;
            }
            if (GenderTextBox.Text =="male" || GenderTextBox.Text=="female")
            {
                GenderLabel.Content = "validate";
                GenderLabel.Foreground = Brushes.Green;
            }
            else
            {
                GenderLabel.Content = "not validate, must be male or female";
                GenderLabel.Foreground = Brushes.Red;
            }
            if (CheckEmail(EmailTextBox.Text))
            {
                EmailLabel.Content = "validate";
               EmailLabel.Foreground = Brushes.Green;
            }
            else 
            {
                EmailLabel.Content = "not validate, must be @ and length <255";
                EmailLabel.Foreground = Brushes.Red;
            }
            if (CheckPhoneNumber(PhoneTextBox.Text))
            {
                PhoneNumberLabel.Content = "validate";
                PhoneNumberLabel.Foreground = Brushes.Green;
            }
            else 
            {
                PhoneNumberLabel.Content = "not validate must be only numbers and length=12";
                PhoneNumberLabel.Foreground = Brushes.Red;
            }
            if (CheckPhoneNumber(PhoneTextBox.Text))
            {
                PhoneNumberLabel.Content = "validate";
                PhoneNumberLabel.Foreground = Brushes.Green;
            }
            else
            {
                PhoneNumberLabel.Content = "not validate must be only numbers and length=12";
                PhoneNumberLabel.Foreground = Brushes.Red;
            }
            var textRange = new TextRange(AdditionalInfoBox.Document.ContentStart,AdditionalInfoBox.Document.ContentEnd);
            if (textRange.Text.Length<2000)
            {
                AdditionalInfoLabel.Content = "validate";
                AdditionalInfoLabel.Foreground = Brushes.Green;
            }
            else 
            {
                AdditionalInfoLabel.Content = "not validate";
                AdditionalInfoLabel.Foreground = Brushes.Red;
            }
               
        }
    }
}
