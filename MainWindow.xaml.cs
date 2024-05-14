using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog122_L9_CheckBoxesAndRadioButtons
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


        // Part 1

        private void btnPart1_Click(object sender, RoutedEventArgs e)
        {

            lblDisplayInfo.Content = FullOrder();


        } // btnPart1_Click

        public string FullOrder()
        {

            // Name of the pizza place
            // The pizza size
            // The toppings
            string pizzaPlaceName = "Will's Pizza Place";

            string order = $"{pizzaPlaceName}\n\n";

            // Pizza Size
            order += PizzaSize();
            // Toppings
            order += Toppings();

            return order;
        } // Full Order

        // Size
        public string PizzaSize()
        {
            string size = "";
            // Radio Button
            if ((bool)rbSmall.IsChecked) // If small pizza is checked
            {
                size += "Size: Small\n";
            }
            else if ((bool)rbMedium.IsChecked) // If medium pizza is checked
            {
                size += "Size: Medium\n";
            }
            else
            {
                size += "Size: Large\n";
            }

            return size;
        }

        // Toppings
        public string Toppings()
        {
            string toppings = "";

            // Check Box
            CheckBox sausage = chkSausage;
            bool isSausage = (bool)sausage.IsChecked;

            if (isSausage)
            {
                // Adding this line to our order string
                toppings += $"Pizza has sausage\n";
            }
            else
            {
                // Adding this line to our order string
                toppings += $"Pizza does NOT has sausage\n";
            }

            // Ternary
            bool isPepperoni = (bool)chkPepperoni.IsChecked;

            // variable = condition ? if true : if false;

            toppings += (isPepperoni) ?
                "Pizza has Pepperoni\n" :
                "Pizza does not have Pepperoni\n";

            return toppings;
        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {

            List<RadioButton> themes = new List<RadioButton>();
            themes.Add(rbWhite);
            themes.Add(rbBlack);
            themes.Add(rbRed);
            themes.Add(rbBlue);

            foreach (RadioButton rb in themes)
            {
                if(rb != null)
                {
                    string chosenColor = rb.Content.ToString();

                    if (chosenColor == "White")
                    {
                        canvasParent.Background = new SolidColorBrush(Colors.White);
                    }
                    else if (chosenColor == "Black")
                    {
                        canvasParent.Background = new SolidColorBrush(Colors.Black);

                    }
                    else if (chosenColor == "Red")
                    {
                        canvasParent.Background = new SolidColorBrush(Colors.Red);
                    }
                    else if (chosenColor == "Blue")
                    {
                        canvasParent.Background = new SolidColorBrush(Colors.Blue);
                    }
                }
            }


        }
    } // class
}