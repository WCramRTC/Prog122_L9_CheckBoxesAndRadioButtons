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
using System.Windows.Shapes;

namespace Prog122_L9_CheckBoxesAndRadioButtons
{
    /// <summary>
    /// Interaction logic for ExampleCode.xaml
    /// </summary>
    public partial class ExampleCode : Window
    {
        public ExampleCode()
        {
            InitializeComponent();
        }

        // Part 1: Practice - Check Status Button Click
        private void CheckStatusButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder status = new StringBuilder();
            status.AppendLine("CheckBoxes:");
            status.AppendLine($"Option 1: {CheckBox1.IsChecked}");
            status.AppendLine($"Option 2: {CheckBox2.IsChecked}");
            status.AppendLine("RadioButtons:");
            status.AppendLine($"Option A: {RadioButton1.IsChecked}");
            status.AppendLine($"Option B: {RadioButton2.IsChecked}");

            StatusLabel.Content = status.ToString();
        }

        // Part 2: Real World - Create Order Button Click
        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            string orderName = OrderNameTextBox.Text;
            bool isOvernight = IsOvernightCheckBox.IsChecked == true;
            bool isPerishable = IsPerishableCheckBox.IsChecked == true;

            Order newOrder = new Order(orderName, isOvernight, isPerishable);
            OrderLabel.Content = newOrder.ToString();
        }

        // Part 3: Change Theme - Change Theme RadioButton Click
        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedTheme = sender as RadioButton;

            if (selectedTheme != null)
            {
                switch (selectedTheme.Content.ToString())
                {
                    case "Theme 1":
                        this.Background = new SolidColorBrush(Colors.LightBlue);
                        break;
                    case "Theme 2":
                        this.Background = new SolidColorBrush(Colors.LightGreen);
                        break;
                    case "Theme 3":
                        this.Background = new SolidColorBrush(Colors.LightCoral);
                        break;
                    case "Theme 4":
                        this.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
                        break;
                }
            }
        }

        // Part 4: Binary Converter - Convert To Binary Button Click
        private void ConvertToBinary_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberInputTextBox.Text, out int number) && number >= 1 && number <= 255)
            {
                for (int i = 0; i < 8; i++)
                {
                    CheckBox bitCheckBox = (CheckBox)FindName($"Bit{i}");
                    if (bitCheckBox != null)
                    {
                        bitCheckBox.IsChecked = (number & (1 << i)) != 0;
                    }
                }

                BinaryOutputLabel.Content = Convert.ToString(number, 2).PadLeft(8, '0');
            }
            else
            {
                BinaryOutputLabel.Content = "Invalid input. Please enter a number between 1 and 255.";
            }
        }

        // Part 4: Binary Converter - Convert From Binary Button Click
        private void ConvertFromBinary_Click(object sender, RoutedEventArgs e)
        {
            int number = 0;
            for (int i = 0; i < 8; i++)
            {
                CheckBox bitCheckBox = (CheckBox)FindName($"Bit{i}");
                if (bitCheckBox != null && bitCheckBox.IsChecked == true)
                {
                    number += (1 << i);
                }
            }

            DecimalOutputLabel.Content = number.ToString();
        }
    }

    // Part 2: Real World - Order Class
    public class Order
    {
        public string OrderName { get; set; }
        public bool IsOvernight { get; set; }
        public bool IsPerishable { get; set; }

        public Order(string orderName, bool isOvernight, bool isPerishable)
        {
            OrderName = orderName;
            IsOvernight = isOvernight;
            IsPerishable = isPerishable;
        }

        public override string ToString()
        {
            return $"Name: {OrderName}\nOvernight Delivery: {IsOvernight}\nPerishable: {IsPerishable}";
        }
    }
}

