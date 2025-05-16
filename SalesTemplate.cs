using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyWpfApp
{
    public partial class SalesTemplate : Window
    {
        public SalesTemplate()
        {
            InitializeComponent();
        }

        // Event handler for CategoryComboBox SelectionChanged
        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Add your logic here
            MessageBox.Show("Category selection changed.");
        }

       
      

        // Event handler for MultiplierTextBox Pasting
        private void MultiplierTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            // Add your logic here (e.g., validate pasted content)
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                string pastedText = (string)e.DataObject.GetData(DataFormats.Text);
                if (!int.TryParse(pastedText, out _))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }




private void MultiplierTextBox_KeyDown(object sender, KeyEventArgs e)
{
    if (e.Key == Key.Enter)
    {
        // if (decimal.TryParse(MultiplierTextBox.Text, out decimal multiplier) && multiplier > 0)
        // {
        //     foreach (var product in _productList)
        //     {
        //         product.AdjustedQuantity = (int)(product.Quantity * multiplier);
        //     }

        //     ProductsDataGrid.ItemsSource = null;
        //     ProductsDataGrid.ItemsSource = _productList;
        // }
        // else
        // {
        //     MessageBox.Show("Please enter a valid decimal number greater than 0.");
        // }
    }
}


private void MultiplierTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
{
    // Regex regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
    // string proposedText = ((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, e.Text);
    // e.Handled = !regex.IsMatch(proposedText);

     e.Handled = !int.TryParse(e.Text, out _); // Allow only numeric input
}

// private void MultiplierTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
// {
//     if (e.DataObject.GetDataPresent(typeof(string)))
//     {
//         string text = (string)e.DataObject.GetData(typeof(string));
//         Regex regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
//         if (!regex.IsMatch(text))
//         {
//             e.CancelCommand();
//         }
//     }
//     else
//     {
//         e.CancelCommand();
//     }
// }






    }
}