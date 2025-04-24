using System.Collections.ObjectModel;
using System.Data.Odbc;
using System.Windows;
using System.Windows.Controls;
using GDS_Test_data.Models;
using GDS_Test_data.Helpers;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace MyWpfApp
{
    public partial class NewFileControl : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        // public ObservableCollection<Product.ProductList> Products { get; set; }
        public ObservableCollection<SelectedProduct> SelectedProducts { get; set; } = new ObservableCollection<SelectedProduct>();

        public NewFileControl()
        {
            InitializeComponent();
            PName.FontFamily = new FontFamily("SunTommy y Tamil");
            Products = new ObservableCollection<Product>();
            ProductsDataList.ItemsSource = Products;
            // Hook key navigation for suggestion list
            ProductsDataList.PreviewKeyDown += ProductsDataList_PreviewKeyDown;
            // ProductsDataGrid.PreviewKeyDown += ProductsDataGrid_PreviewKeyDown;
            ProductsDataGrid.PreviewKeyDown += ProductsDataGrid_PreviewKeyDown;
            ProductTextBox.PreviewKeyDown += ProductTextBox_PreviewKeyDown;

            // // Hook key navigation for DataGrid
            // ProductsDataGrid.KeyDown += ProductsDataGrid_KeyDown;


        }

        private void TxtBox_Clear()
        {
            ProductTextBox.Clear();
            RateTextBox.Clear();
            QuantityTextBox.Clear();
        }

        private SelectedProduct _selectedRowToUpdate;

        private void ProductsDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ProductsDataGrid.SelectedItem is SelectedProduct selected)
                {
                    ProductTextBox.Text = selected.PName;
                    RateTextBox.Text = selected.Rate2.ToString("0.00");
                    QuantityTextBox.Text = selected.Quantity.ToString();
                    _selectedRowToUpdate = selected;

                    ProductTextBox.FontFamily = new FontFamily("SunTommy y Tamil");
                    // Optional: move focus to Quantity or another control
                    QuantityTextBox.Focus();
                    QuantityTextBox.Select(QuantityTextBox.Text.Length, 0); //To move the cursor to the end of the text
                    e.Handled = true; // To prevent the default DataGrid behavior
                }


                // var selectedItem = ProductsDataGrid.SelectedItem;
                // if (selectedItem != null)
                // {
                //     dynamic item = selectedItem;
                //     ProductTextBox.Text = item.PName != null ? item.PName.ToString() : string.Empty;
                //     RateTextBox.Text = item.Rate2 != null ? item.Rate2.ToString() : string.Empty;
                //     QuantityTextBox.Text = item.Quantity != null ? item.Quantity.ToString() : string.Empty;
                //     ProductTextBox.FontFamily = new FontFamily("SunTommy y Tamil");
                //     // Optional: move focus to Quantity or another control
                //     QuantityTextBox.Focus();
                //     QuantityTextBox.Select(QuantityTextBox.Text.Length, 0); //To move the cursor to the end of the text
                //     e.Handled = true; // To prevent the default DataGrid behavior
            }




        }




        

        // private void ProductsDataGrid_KeyDown(object sender, KeyEventArgs e)
        // {
        //     if (e.Key == Key.Enter)
        //     {
        //         if (ProductsDataGrid.SelectedItem is SelectedProduct selected)
        //         {
        //             ProductTextBox.Text = selected.PName;
        //             RateTextBox.Text = selected.Rate2.ToString("0.00");
        //             QuantityTextBox.Text = selected.Quantity.ToString();
        //             _selectedRowToUpdate = selected;

        //             ProductTextBox.Focus();
        //             e.Handled = true;
        //         }
        //     }
        // }



        private void ProductsDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var selectedItem = ProductsDataGrid.SelectedItem;
                if (selectedItem != null)
                {
                    dynamic item = selectedItem;

                    ProductTextBox.Text = item.PName != null ? item.PName.ToString() : string.Empty;
                    RateTextBox.Text = item.Rate2 != null ? item.Rate2.ToString() : string.Empty;
                    QuantityTextBox.Text = item.Quantity != null ? item.Quantity.ToString() : string.Empty;


                    ProductTextBox.FontFamily = new FontFamily("SunTommy y Tamil");
                    // Optional: move focus to Quantity or another control
                    QuantityTextBox.Focus();
                }

                e.Handled = true; // To prevent the default DataGrid behavior
            }
        }

        private void ProductsDataGrid_MouseDoubleClick(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ProductsDataGrid.SelectedItem is SelectedProduct selected)
                {
                    ProductTextBox.Text = selected.PName;
                    RateTextBox.Text = selected.Rate2.ToString("0.00");
                    QuantityTextBox.Text = selected.Quantity.ToString();
                    _selectedRowToUpdate = selected;

                    ProductTextBox.Focus();
                    e.Handled = true;
                }
            }
        }

        private void ProductTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (ProductsDataList.Visibility == Visibility.Visible &&
                (e.Key == Key.Up || e.Key == Key.Down))
            {
                ProductsDataList.Focus();
                e.Handled = true;

                if (Products.Any())
                {
                    ProductsDataList.SelectedIndex = 0;
                    ProductsDataList.ScrollIntoView(ProductsDataList.SelectedItem);
                }
            }
        }

        private void ProductTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = ProductTextBox.Text;

            if (!string.IsNullOrEmpty(searchText))
            {
                ProductsDataList.Visibility = Visibility.Visible; // Show when text is typed
                LoadProductData(searchText);
                // ProductsDataList.SelectedIndex = 0; 

                // if (Products.Any())
                // {
                //     ProductsDataList.SelectedIndex = 0;
                //     ProductsDataList.ScrollIntoView(ProductsDataList.SelectedItem);
                // }

                // Selection must be set AFTER LoadProductData updates the collection
                if (Products.Any())
                {
                    ProductsDataList.SelectedIndex = 0;
                    ProductsDataList.ScrollIntoView(ProductsDataList.SelectedItem);
                }


            }
            else
            {
                ProductsDataList.Visibility = Visibility.Collapsed; // Hide when text is cleared
                Products.Clear(); // Clear the grid if the search text is empty
            }
        }

        public void LoadProductData(string productSearchText)
        {
            string connectionString = "Driver={SQL Server};Server=.;Database=rs_gst_27;Trusted_Connection=True;";
            string query = @"
                SELECT TOP 50
                    pname, Rate2, mrp 
                FROM Product
                WHERE active = '1.0' AND pcode LIKE ? 
                ORDER BY pcode ASC";

            OdbcParameter[] parameters = new OdbcParameter[]
            {
                new OdbcParameter("@pcode", productSearchText + "%")
            };

            var productsFromDb = DatabaseHelper.GetEntitiesFromDatabase<Product>(connectionString, query, parameters);

            // Update the ObservableCollection
            Products.Clear();
            foreach (var product in productsFromDb)
            {
                Products.Add(product);
            }



        }


        // private void QtyTxtBox_KeyDown(object sender, KeyEventArgs e)
        // {
        //     if (e.Key == Key.F8)
        //     {
        //         ProductTextBox.Focus();
        //     }
        //     if (e.Key == Key.Enter)
        //     {
        //         if (!string.IsNullOrWhiteSpace(ProductTextBox.Text) &&
        //             decimal.TryParse(RateTextBox.Text, out decimal rate) &&
        //             decimal.TryParse(QuantityTextBox.Text, out decimal quantity))
        //         {
        //             PNameNative.FontFamily = new FontFamily("SunTommy y Tamil");
        //             // Add new product to the DataGrid



        //             string rateText = RateTextBox.Text; // Input from Rate TextBox
        //             string quantityText = QuantityTextBox.Text; // Input from Quantity TextBox


        //             ProductsDataGrid.Items.Add(new Product
        //             {
        //                 PName = ProductTextBox.Text,
        //                 Rate2 = Convert.ToDecimal(RateTextBox.Text),
        //                 Quantity = quantity,
        //                 Total = PerformCalculation(rateText, quantityText) // Assign the calculated total
        //             });
        //             // Clear the text boxes
        //             TxtBox_Clear();
        //             ProductTextBox.FontFamily = new FontFamily("Segoe UI");
        //             ProductTextBox.Focus();
        //             //  ProductsDataList.Clear();
        //             //    ProductsDataList.Visibility = Visibility.Collapsed;
        //             // ProductsDataList.ItemsSource = null; // Clears the DataGrid
        //             // Optionally update the grand total or other calculations
        //             UpdateGrandTotal();

        //             // Mark the event as handled to prevent further propagation
        //             e.Handled = true;
        //         }
        //         else
        //         {
        //             // Allow other keys to pass through
        //             e.Handled = false;

        //             MessageBox.Show("Please enter valid Product Name, Rate, and Quantity.");
        //         }
        //     }
        // }



        private void QtyTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (decimal.TryParse(RateTextBox.Text, out decimal rate) &&
                    int.TryParse(QuantityTextBox.Text, out int qty) &&
                    !string.IsNullOrWhiteSpace(ProductTextBox.Text))
                {
                    if (_selectedRowToUpdate != null)
                    {
                        // Editing an existing row
                        _selectedRowToUpdate.PName = ProductTextBox.Text;
                        _selectedRowToUpdate.Rate2 = rate;
                        _selectedRowToUpdate.Quantity = qty;

                        _selectedRowToUpdate = null;
                    }
                    else
                    {
                        // Check if product already exists
                        var existingProduct = SelectedProducts
                            .FirstOrDefault(p => p.PName.Equals(ProductTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        // Try to find the product in the SelectedProducts list


                        if (existingProduct != null)
                        {
                            // Update quantity and optionally rate
                            existingProduct.Quantity += qty;
                            existingProduct.Rate2 = rate; // Optionally keep same rate or update
                        }
                        else
                        {
                            // Get original product's category
                            // var original = Products.FirstOrDefault(p => p.pname == ProductTextBox.Text);

                            // var product = new SelectedProduct
                            // {
                            //     PName = ProductTextBox.Text,
                            //     Rate2 = rate,
                            //     Quantity = qty,
                            //     Category = original?.Category ?? ""
                            // };

                            // SelectedProducts.Add(product);

                            // Add new product to the DataGrid
                            // ProductsDataGrid.Items.Add(new Product
                            // {
                            //     PName = ProductTextBox.Text,
                            //     Rate2 = rate,
                            //     Quantity = qty,
                            //     Total = PerformCalculation(rate, qty) // Assign the calculated total
                            // });
                            var product = new SelectedProduct
                            {
                                PName = ProductTextBox.Text,
                                Rate2 = rate,
                                Quantity = qty
                                // Only if Category exists in Product class: Category = category
                            };

                            ProductsDataGrid.Items.Add(product);
                            SelectedProducts.Add(product);

                        }
                    }

                    // ProductsDataGrid.Items.Refresh(); // Refresh DataGrid display
                    PNameNative.FontFamily = new FontFamily("SunTommy y Tamil");
                    UpdateGrandTotal();
                    SortProducts(); // Sort after changes

                    // Clear inputs
                    ProductTextBox.Clear();
                    RateTextBox.Clear();
                    QuantityTextBox.Clear();
                    ProductTextBox.Focus();
                    ProductsDataGrid.Items.Refresh();
                    ProductTextBox.FontFamily = new FontFamily("Segoe UI");
                }
            }
        }




        // private void ProductsDataList_PreviewKeyDown(object sender, KeyEventArgs e)
        // {
        //     if (e.Key == Key.Enter && ProductsDataList.SelectedItem != null)
        //     {
        //         var selectedProduct = ProductsDataList.SelectedItem as Product;
        //         if (selectedProduct != null)
        //         {
        //             ProductTextBox.FontFamily = new FontFamily("SunTommy y Tamil");
        //             ProductTextBox.Text = selectedProduct.pname;
        //             // ProductTextBox.Text = selectedProduct.pname;
        //             // RateTextBox.Text = ((decimal)selectedProduct.Rate2).ToString("0.00");
        //             RateTextBox.Text = selectedProduct.Rate2.Value.ToString("0.00");
        //             QuantityTextBox.Focus(); // Focus the next input if needed
        //             e.Handled = true;
        //         }
        //     }


        // }



        private void ProductsDataList_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Products.Count == 0) return;

            int currentIndex = ProductsDataList.SelectedIndex;

            if (e.Key == Key.Down)
            {
                if (currentIndex < Products.Count - 1)
                {
                    ProductsDataList.SelectedIndex = currentIndex + 1;
                    ProductsDataList.ScrollIntoView(ProductsDataList.SelectedItem);
                }
                e.Handled = true;
            }
            else if (e.Key == Key.Up)
            {
                if (currentIndex > 0)
                {
                    ProductsDataList.SelectedIndex = currentIndex - 1;
                    ProductsDataList.ScrollIntoView(ProductsDataList.SelectedItem);
                }
                e.Handled = true;
            }
            else if (e.Key == Key.Enter && ProductsDataList.SelectedItem is Product selected)
            {
                // Handle Enter key to select the product
                var selectedProduct = ProductsDataList.SelectedItem as Product;
                ProductTextBox.FontFamily = new FontFamily("SunTommy y Tamil");
                ProductTextBox.Text = selectedProduct.pname;
                RateTextBox.Text = selectedProduct.Rate2.Value.ToString("0.00");
                QuantityTextBox.Focus(); // Focus the next input if needed
                ProductsDataList.Visibility = Visibility.Collapsed;
                e.Handled = true;
            }
        }



        private decimal PerformCalculation(decimal rateText, int quantityText)
        {
            // Convert inputs to appropriate types
            decimal parsedRate = Convert.ToDecimal(rateText);
            int parsedQuantity = Convert.ToInt32(quantityText);

            // Call the calculation method
            return CalculateTotal(parsedRate, parsedQuantity);

        }

        // Separate method for calculation
        private decimal CalculateTotal(decimal rate, int quantity)
        {
            // Perform the calculation and round off to the nearest whole number
            return Math.Round(rate * quantity);
        }



        private void SortProducts()
        {
            var sorted = Products.OrderBy(p => p.Category == "Discount" || p.Category == "Rice" ? 1 : 0)
                                 .ThenBy(p => p.pname)
                                 .ToList();
            Products.Clear();
            foreach (var item in sorted)
                Products.Add(item);
        }

        // private void UpdateGrandTotal()
        // {
        //     decimal grandTotal = 0;
        //     foreach (Product product in ProductsDataGrid.Items)
        //     {
        //         if (product.Rate2.HasValue) // Check if Rate2 is not null
        //         {
        //             grandTotal += (decimal)product.Rate2.Value * (decimal)product.Quantity; // Explicit cast
        //         }
        //         else
        //         {
        //             grandTotal += 0; // Add 0 if Rate2 is null
        //         }
        //     }
        //     // GrandTotalTextBlock.Text = $"Grand Total: {grandTotal:C}";
        //     GrandTotalTextBlock.Text = $"{grandTotal:C}";

        // }

        private void UpdateGrandTotal()
        {
            decimal grandTotal = 0;

            foreach (var item in ProductsDataGrid.Items)
            {
                if (item is Product product)
                {
                    // Handle nullable values for Rate2 and Quantity
                    decimal rate = product.Rate2 ?? 0;
                    decimal qty = product.Quantity ?? 0;
                    grandTotal += rate * qty;
                }
            }

            GrandTotalTextBlock.Text = $"{grandTotal:C}";
        }


    }
}