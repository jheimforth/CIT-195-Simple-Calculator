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

namespace AssignmentCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _units;
        public MainWindow()
        {
            InitializeComponent();
            InitializeWindowElements();
        }

        private void InitializeWindowElements()
        {
            TextBox_Distance.Focus();
            _units = "Miles";
            UpdateUnits();
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double speed;
            bool validInput = false;

            if (ValidateInputs())
            {
                speed = double.Parse(TextBox_Distance.Text) / double.Parse(TextBox_Time.Text);
                Label_CalculatedSpeed.Content = speed;

                

            }
        }

        private bool ValidateInputs()
        {
            bool validInput = true;
            if (
                !double.TryParse(TextBox_Distance.Text, out double distance) ||
                !double.TryParse(TextBox_Time.Text, out double time)
                )
            {
                MessageBox.Show("Please Enter Numbers and NOT Letters in the boxes");
                validInput = false;
                ResetInputs();
            }

            return validInput;
        }

        private void RadioButton_Units_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                UpdateUnits();
            }
        }

        private void ResetInputs()
        {
            TextBox_Distance.Text = "";
            TextBox_Time.Text = "";
            Label_CalculatedSpeed.Content = "";
            TextBox_Distance.Focus();
        }
        private void UpdateUnits()
        {
            if (RadioButton_Miles.IsChecked == true)
            {
                _units = "Miles";
                Label_Speed.Content = "Speed(MPH)";
            }
            else if (RadioButton_Kilometers.IsChecked == true)
            {
                _units = "Kilometers";
                Label_Speed.Content = "Speed(KMPH)";
            }
            Label_Distance.Content = "Distance(" + _units + ")";
           
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();

            helpWindow.ShowDialog();
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            ResetInputs();
        }
    }
}
