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
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using log4net;


namespace MyWpfApp
{
    public partial class NewFileControl : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        // public ObservableCollection<Product.ProductList> Products { get; set; }
        // public ObservableCollection<SelectedProduct> LoadedProducts { get; set; } = new ObservableCollection<SelectedProduct>();
        // public ObservableCollection<SelectedProduct> LoadedProducts { get; set; }

        public ObservableCollection<SelectedProduct> LoadedProducts { get; set; } = new ObservableCollection<SelectedProduct>();
        public string UnitName = string.Empty;

        public NewFileControl()
        {
            InitializeComponent();
            this.DataContext = this; // if using code-behind
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
                // if (ProductsDataGrid.SelectedItem !=null)
                if (ProductsDataGrid.SelectedItem is SelectedProduct selected)
                {
                    ProductsDataList.Visibility = Visibility.Collapsed; // Hide when text is cleared
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
            if (e.Key == Key.Delete)
            {
                if (ProductsDataGrid.SelectedItem is SelectedProduct selected1)

                {
                    LoadedProducts.Remove(selected1); // ObservableCollection auto-updates UI
                }
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

        // private void RateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        // {
        //     if (RateComboBox.SelectedItem != null)
        //     {
        //         _selectedRowToUpdate.Rate2 = (decimal)RateComboBox.SelectedItem;
        //     }
        // }



        // private void RateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        // {
        //     if (RateComboBox.SelectedItem != null)
        //     {
        //         if (decimal.TryParse(RateComboBox.SelectedItem.ToString(), out decimal selectedRate))
        //         {
        //             // Check if _selectedRowToUpdate is null before accessing it
        //             if (_selectedRowToUpdate == null)
        //             {
        //                 _selectedRowToUpdate = new SelectedProduct();
        //             }

        //             _selectedRowToUpdate.Rate2 = selectedRate;
        //         }
        //         else
        //         {
        //             if (_selectedRowToUpdate == null)
        //             {
        //                 _selectedRowToUpdate = new SelectedProduct();
        //             }

        //             _selectedRowToUpdate.Rate2 = 0;
        //         }
        //     }
        // }


        private Product _currentProduct; // <<--- ADD THIS LINE

        // private void RateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        // {

        //     // Assuming the ListBox is bound to a list of Product objects
        //     _currentProduct = RateComboBox.SelectedItem as Product;

        //     if (RateComboBox.SelectedItem != null)
        //     {
        //         if (_selectedRowToUpdate == null)
        //         {
        //             _selectedRowToUpdate = new SelectedProduct();
        //         }

        //         string selectedLabel = RateComboBox.SelectedItem.ToString();

        //         if (selectedLabel == "Rate1" && !string.IsNullOrWhiteSpace(_currentProduct?.Caption2))
        //         {
        //             if (decimal.TryParse(_currentProduct.Caption2, out decimal caption2Rate))
        //                 _selectedRowToUpdate.Rate2 = caption2Rate;
        //         }
        //         else if (selectedLabel == "CaseRate" && !string.IsNullOrWhiteSpace(_currentProduct?.Caption1))
        //         {
        //             if (decimal.TryParse(_currentProduct.Caption1, out decimal caption1Rate))
        //                 _selectedRowToUpdate.Rate2 = caption1Rate;
        //         }
        //         else if (selectedLabel == "Rate2" && !string.IsNullOrWhiteSpace(_currentProduct?.Caption3))
        //         {
        //             if (decimal.TryParse(_currentProduct.Caption3, out decimal caption3Rate))
        //                 _selectedRowToUpdate.Rate2 = caption3Rate;
        //         }
        //         else
        //         {
        //             // Default fallback if nothing matches
        //             _selectedRowToUpdate.Rate2 = 0;
        //         }
        //     }
        // }



        // private void RateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        // {

        //     if (RateComboBox.SelectedItem != null && _currentSelectedProduct != null)

        //     {
        //         string selectedValue = RateComboBox.SelectedItem.ToString();

        //         decimal rateToSet = 0;

        //         // Match based on selected label
        //         if (selectedValue == _currentSelectedProduct.Caption2) // Rate1
        //         {
        //             if (decimal.TryParse(_currentSelectedProduct.Rate1.ToString(), out decimal caption2Rate))
        //                 rateToSet = caption2Rate;
        //         }
        //         else if (selectedValue == _currentSelectedProduct.Caption1) // CaseRate
        //         {
        //             if (decimal.TryParse(_currentSelectedProduct.CaseRate.ToString(), out decimal caption1Rate))
        //                 rateToSet = caption1Rate;
        //         }
        //         else if (selectedValue == _currentSelectedProduct.Caption3) // Rate2
        //         {
        //             if (decimal.TryParse(_currentSelectedProduct.Rate2.ToString(), out decimal caption3Rate))
        //                 rateToSet = caption3Rate;
        //         }

        //         // Set the RateTextBox value
        //         RateTextBox.Text = rateToSet.ToString("0.00");

        //         // Also update _selectedRowToUpdate if needed
        //         if (_selectedRowToUpdate != null)
        //         {
        //             _selectedRowToUpdate.Rate2 = rateToSet;
        //         }
        //         RateTextBox.Visibility = Visibility.Visible;
        //         RateComboBox.Visibility = Visibility.Collapsed;


        //     }
        // }



        // private void RateComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        // {
        //     if (e.Key == Key.Enter)
        //     {
        //         ApplySelectedRateFromComboBox();
        //         e.Handled = true; // Prevent default sound/beep
        //     }
        // }

        private void ApplySelectedRateFromComboBox()
        {
            if (RateComboBox.SelectedItem != null && _currentSelectedProduct != null)
            {
                string selectedValue = RateComboBox.SelectedItem.ToString();
                decimal rateToSet = 0;

                // Match based on selected label
                if (selectedValue == _currentSelectedProduct.Caption2) // Rate1
                {
                    if (decimal.TryParse(_currentSelectedProduct.Rate1.ToString(), out decimal caption2Rate))
                        rateToSet = caption2Rate;
                }
                else if (selectedValue == _currentSelectedProduct.Caption1) // CaseRate
                {
                    if (decimal.TryParse(_currentSelectedProduct.CaseRate.ToString(), out decimal caption1Rate))
                        rateToSet = caption1Rate;
                }
                else if (selectedValue == _currentSelectedProduct.Caption3) // Rate2
                {
                    if (decimal.TryParse(_currentSelectedProduct.Rate2.ToString(), out decimal caption3Rate))
                        rateToSet = caption3Rate;
                }

                // Set the RateTextBox value
                RateTextBox.Text = rateToSet.ToString("0.00");

                // Update the selected row if needed
                if (_selectedRowToUpdate != null)
                {
                    _selectedRowToUpdate.Rate2 = rateToSet;
                }

                RateTextBox.Visibility = Visibility.Visible;
                RateComboBox.Visibility = Visibility.Collapsed;
            }
        }





        public void LoadProductData(string productSearchText)
        {
            string connectionString = "Driver={SQL Server};Server=.;Database=rs_gst_27;Trusted_Connection=True;";
            string query = @"
                 SELECT TOP 50 pname, Rate2, mrp , CAPTION1,caserate,CAPTION2,rate1,CAPTION3
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



        // private void QtyTxtBox_KeyDown(object sender, KeyEventArgs e)
        // {
        //     if (e.Key == Key.Enter)
        //     {
        //         if (decimal.TryParse(RateTextBox.Text, out decimal rate) &&
        //             int.TryParse(QuantityTextBox.Text, out int qty) &&
        //             !string.IsNullOrWhiteSpace(ProductTextBox.Text))
        //         {
        //             if (_selectedRowToUpdate != null)
        //             {
        //                 // Editing an existing row
        //                 _selectedRowToUpdate.PName = ProductTextBox.Text;
        //                 _selectedRowToUpdate.Rate2 = rate;
        //                 _selectedRowToUpdate.Quantity = qty;

        //                 _selectedRowToUpdate = null;
        //                 var product = new SelectedProduct
        //                     {
        //                         PName = ProductTextBox.Text,
        //                         Rate2 = rate,
        //                         Quantity = qty
        //                         // Only if Category exists in Product class: Category = category
        //                     };

        //                     ProductsDataGrid.Items.Add(product);
        //             }
        //             else
        //             {
        //                 // Check if product already exists
        //                 var existingProduct = SelectedProducts
        //                     .FirstOrDefault(p => p.PName.Equals(ProductTextBox.Text, StringComparison.OrdinalIgnoreCase));
        //                 // Try to find the product in the SelectedProducts list


        //                 if (existingProduct != null)
        //                 {
        //                     // Update quantity and optionally rate
        //                     existingProduct.Quantity += qty;
        //                     existingProduct.Rate2 = rate; // Optionally keep same rate or update
        //                 }
        //                 else
        //                 {
        //                     // Get original product's category
        //                     // var original = Products.FirstOrDefault(p => p.pname == ProductTextBox.Text);

        //                     // var product = new SelectedProduct
        //                     // {
        //                     //     PName = ProductTextBox.Text,
        //                     //     Rate2 = rate,
        //                     //     Quantity = qty,
        //                     //     Category = original?.Category ?? ""
        //                     // };

        //                     // SelectedProducts.Add(product);

        //                     // Add new product to the DataGrid
        //                     // ProductsDataGrid.Items.Add(new Product
        //                     // {
        //                     //     PName = ProductTextBox.Text,
        //                     //     Rate2 = rate,
        //                     //     Quantity = qty,
        //                     //     Total = PerformCalculation(rate, qty) // Assign the calculated total
        //                     // });
        //                     var product = new SelectedProduct
        //                     {
        //                         PName = ProductTextBox.Text,
        //                         Rate2 = rate,
        //                         Quantity = qty
        //                         // Only if Category exists in Product class: Category = category
        //                     };

        //                     ProductsDataGrid.Items.Add(product);
        //                     SelectedProducts.Add(product);

        //                 }
        //             }

        //             // ProductsDataGrid.Items.Refresh(); // Refresh DataGrid display
        //             PNameNative.FontFamily = new FontFamily("SunTommy y Tamil");
        //             UpdateGrandTotal();
        //             SortProducts(); // Sort after changes

        //             // Clear inputs
        //             ProductTextBox.Clear();
        //             RateTextBox.Clear();
        //             QuantityTextBox.Clear();
        //             ProductTextBox.Focus();
        //             ProductsDataGrid.Items.Refresh();
        //             ProductTextBox.FontFamily = new FontFamily("Segoe UI");
        //         }
        //     }
        // }


        private void QtyTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {


                int qty = 0;

                // Check and parse quantity input with '+' handling
                if (QuantityTextBox.Text.Contains("+"))
                {
                    var parts = QuantityTextBox.Text.Split('+');
                    foreach (var part in parts)
                    {
                        if (int.TryParse(part.Trim(), out int val))
                        {
                            qty += val;
                        }
                        else
                        {
                            qty = 0;
                            break;
                        }
                    }
                }
                else
                {
                    int.TryParse(QuantityTextBox.Text.Trim(), out qty);
                }



                if (decimal.TryParse(RateTextBox.Text, out decimal rate) &&
                     qty > 0 &&
                    !string.IsNullOrWhiteSpace(ProductTextBox.Text))
                {
                    string pname = ProductTextBox.Text.Trim();
                    string qtyInput = QuantityTextBox.Text;




                    if (_selectedRowToUpdate != null)
                    {
                        // Overwrite quantity and rate for the selected row
                        _selectedRowToUpdate.PName = pname;
                        _selectedRowToUpdate.Rate2 = rate;
                        _selectedRowToUpdate.Quantity = qty;

                        _selectedRowToUpdate = null; // Clear edit mode
                    }
                    else
                    {
                        // // Look for existing product
                        // var existingProduct = LoadedProducts
                        //     .FirstOrDefault(p => p.PName.Equals(pname, StringComparison.OrdinalIgnoreCase));

                        SelectedProduct existingProduct = null;

                        // if (!string.IsNullOrWhiteSpace(pname))
                        // {
                        //     existingProduct = LoadedProducts
                        //         .FirstOrDefault(p => !string.IsNullOrEmpty(p.PName) &&
                        //                              p.PName.Equals(pname, StringComparison.OrdinalIgnoreCase));
                        // }
                        if (LoadedProducts.Count > 0 &&

                         LoadedProducts != null && !string.IsNullOrWhiteSpace(pname))
                        {
                            existingProduct = LoadedProducts
                                .FirstOrDefault(p => !string.IsNullOrEmpty(p.PName) &&
                                                     p.PName.Equals(pname, StringComparison.OrdinalIgnoreCase));
                        }


                        if (existingProduct != null)
                        {
                            // Add to existing quantity if found
                            existingProduct.Quantity += qty;
                            existingProduct.Rate2 = rate; // Optional: overwrite or retain
                        }

                        else
                        {
                            // Ensure LoadedProducts is initialized
                            if (LoadedProducts == null)
                                LoadedProducts = new ObservableCollection<SelectedProduct>();

                            // Check if qtyInput contains '+'
                            if (SeparateRowsCheckBox.IsChecked == true)
                            {
                                // Split the input by '+' and add separate rows
                                var quantities = qtyInput.Split('+');
                                foreach (var q in quantities)
                                {
                                    if (int.TryParse(q.Trim(), out int singleQty))
                                    {
                                        var product = new SelectedProduct
                                        {
                                            PName = pname,
                                            Rate2 = rate,
                                            Quantity = singleQty
                                        };
                                        LoadedProducts.Add(product);
                                        ProductsDataGrid.ItemsSource = LoadedProducts;

                                    }
                                }
                            }
                            else
                            {
                                // Add a single combined row
                                var newProduct = new SelectedProduct
                                {
                                    PName = pname,
                                    Rate2 = rate,
                                    Quantity = qty,
                                    Unit = UnitName // e.g., "kg" or "gram"
                                };
                                LoadedProducts.Add(newProduct);
                                ProductsDataGrid.ItemsSource = LoadedProducts;
                            }
                        }
                    }

                    // Font for native display (Tamil)
                    // PNameNative.FontFamily = new FontFamily("SunTommy y Tamil");

                    // Update UI
                    UpdateGrandTotal();
                    SortProducts();
                    ProductsDataGrid.Items.Refresh();

                    // Clear inputs
                    ProductTextBox.Clear();
                    RateTextBox.Clear();
                    QuantityTextBox.Clear();
                    ProductTextBox.Focus();
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

        private Product _currentSelectedProduct;

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
            else if (e.Key == Key.Enter && ProductsDataList.SelectedItem is Product productFromList)
            {


                // This code is added for ratetextbox to dropdown like kg,gm
                // if (ProductsDataList.SelectedItem is Product selectedProduct)
                // {
                //     ProductTextBox.Text = selectedProduct.PName;

                //     if (!string.IsNullOrWhiteSpace(selectedProduct.Caption1) &&
                //         !string.IsNullOrWhiteSpace(selectedProduct.Caption2))
                //     {
                //         RateTextBox.Visibility = Visibility.Collapsed;
                //         RateComboBox.Visibility = Visibility.Visible;

                //         var rateOptions = new List<decimal>();
                //         if (decimal.TryParse(selectedProduct.Caption1, out decimal caption1Decimal))
                //             rateOptions.Add(caption1Decimal);

                //         if (decimal.TryParse(selectedProduct.Caption2, out decimal caption2Decimal))
                //             rateOptions.Add(caption2Decimal);

                //         RateComboBox.ItemsSource = rateOptions;
                //         RateComboBox.SelectedIndex = 0;
                //     }
                //     else
                //     {
                //         RateTextBox.Visibility = Visibility.Visible;
                //         RateComboBox.Visibility = Visibility.Collapsed;
                //         RateTextBox.Text = selectedProduct.Rate2?.ToString("0.00") ?? "0.00";
                //     }

                //     QuantityTextBox.Text = selectedProduct.Quantity?.ToString() ?? "0";

                //     _selectedRowToUpdate = new SelectedProduct
                //     {
                //         PName = selectedProduct.PName,
                //         Rate2 = selectedProduct.Rate2 ?? 0,
                //         Quantity = selectedProduct.Quantity ?? 0
                //     };


                //     // Handle Enter key to select the product
                //     ProductTextBox.FontFamily = new FontFamily("SunTommy y Tamil");
                //     ProductTextBox.Text = productFromList.pname;
                //     RateTextBox.Text = productFromList.Rate2?.ToString("0.00") ?? "0.00";
                //     QuantityTextBox.Focus();
                //     ProductsDataList.Visibility = Visibility.Collapsed;
                //     e.Handled = true;
                // }


                ProductTextBox.FontFamily = new FontFamily("SunTommy y Tamil");
                ProductTextBox.Text = productFromList.pname;

                if (!string.IsNullOrWhiteSpace(productFromList.Caption1) &&
                    !string.IsNullOrWhiteSpace(productFromList.Caption2))
                {
                    RateTextBox.Visibility = Visibility.Collapsed;
                    RateComboBox.Visibility = Visibility.Visible;



                    _currentSelectedProduct = productFromList;



                    if (productFromList != null)
                    {
                        // Check if Caption1, Caption2, Caption3 have different values
                        bool hasDifferentCaptions =
                            !string.IsNullOrWhiteSpace(productFromList.Caption1) &&
                            !string.IsNullOrWhiteSpace(productFromList.Caption2) &&
                            !string.IsNullOrWhiteSpace(productFromList.Caption3) &&
                            (!productFromList.Caption1.Equals(productFromList.Caption2, StringComparison.OrdinalIgnoreCase) ||
                             !productFromList.Caption1.Equals(productFromList.Caption3, StringComparison.OrdinalIgnoreCase) ||
                             !productFromList.Caption2.Equals(productFromList.Caption3, StringComparison.OrdinalIgnoreCase));

                        if (hasDifferentCaptions)
                        {
                            // Show ComboBox
                            RateTextBox.Visibility = Visibility.Collapsed;
                            RateComboBox.Visibility = Visibility.Visible;

                            var rateOptions = new List<string>();

                            if (!string.IsNullOrWhiteSpace(productFromList.Caption2)) // Rate1 = Caption2
                            {
                                rateOptions.Add(productFromList.Caption2);
                                UnitName = productFromList.Caption2;
                            }
                            if (!string.IsNullOrWhiteSpace(productFromList.Caption1)) // CaseRate = Caption1
                            {
                                rateOptions.Add(productFromList.Caption1);
                                UnitName = productFromList.Caption1;
                            }

                            if (!string.IsNullOrWhiteSpace(productFromList.Caption3)) // Rate2 = Caption3
                            {
                                rateOptions.Add(productFromList.Caption3);
                                UnitName = productFromList.Caption3;

                            }

                            RateComboBox.ItemsSource = rateOptions;
                            RateComboBox.SelectedIndex = 0;
                            RateComboBox.FontFamily = new FontFamily("SunTommy y Tamil");
                            RateComboBox.Focus();
                            //  e.Handled = false;
                        }
                        else
                        {
                            // Show TextBox
                            RateTextBox.Visibility = Visibility.Visible;
                            RateComboBox.Visibility = Visibility.Collapsed;
                            UnitName = productFromList.Caption3;
                            // Default to Rate2
                            RateTextBox.Text = productFromList.Rate2?.ToString("0.00") ?? "0.00";

                            QuantityTextBox.Focus();

                        }
                    }





                }
                else
                {
                    RateTextBox.Visibility = Visibility.Visible;
                    RateComboBox.Visibility = Visibility.Collapsed;
                    RateTextBox.Text = productFromList.Rate2?.ToString("0.00") ?? "0.00";
                }

                //QuantityTextBox.Text = productFromList.Quantity?.ToString() ?? "0";

                // _selectedRowToUpdate = new SelectedProduct
                // {
                //     PName = productFromList.PName,
                //     Rate2 = productFromList.Rate2 ?? 0,
                //     Quantity = productFromList.Quantity ?? 0
                // };

                RateComboBox.Focus();
                ProductsDataList.Visibility = Visibility.Collapsed;
                e.Handled = true;




            }


        }



        // private void PrintButton_Click(object sender, RoutedEventArgs e)
        // {


        //     try
        //     {
        //         ReportDocument report = new ReportDocument();
        //     }
        //     catch (Exception ex)
        //     {
        //         MessageBox.Show("Crystal error: " + ex.ToString());
        //     }




        //     try
        //     {
        //         // Load report file from folder
        //         string reportPath = @"E:\oryes\trading\oryes2-gst\report\salesbill.rpt"; // Update to your folder path
        //         ReportDocument reportDocument = new ReportDocument();
        //         reportDocument.Load(reportPath);

        //         // Optional: set database login if needed
        //         // reportDocument.SetDatabaseLogon("user", "password");

        //         // Send directly to printer
        //         reportDocument.PrintToPrinter(1, false, 0, 0); // 1 copy, no collate, start page 0, end page 0

        //         MessageBox.Show("Report sent to printer successfully.");
        //     }
        //     catch (Exception ex)
        //     {
        //         MessageBox.Show("Printing failed: " + ex.Message);
        //     }
        // }


        // private void Window_KeyDown(object sender, KeyEventArgs e)
        // {
        //     if (e.Key == Key.F8)
        //     {
        //         RateTextBox.Clear();
        //         ProductTextBox.Clear();
        //         QuantityTextBox.Clear();
        //         ProductTextBox.Focus();
        //     }
        // }


        // private void RateComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        // {
        //     if (e.Key == Key.Enter && RateComboBox.SelectedItem != null)
        //     {
        //         string selectedRateText = RateComboBox.SelectedItem.ToString();

        //         if (decimal.TryParse(selectedRateText, out decimal rate))
        //         {
        //             RateTextBox.Text = rate.ToString("0.00");

        //             // Optional: if you are editing a row
        //             if (_selectedRowToUpdate != null)
        //             {
        //                 _selectedRowToUpdate.Rate2 = rate;
        //             }
        //         }

        //         // Move focus to QuantityTextBox after setting rate (optional)
        //         QuantityTextBox.Focus();
        //     }
        // }


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
            var sorted = LoadedProducts.OrderBy(p => p.Category == "Discount" || p.Category == "RICE" ? 1 : 0)
                                 .ThenBy(p => p.PName)
                                 .ToList();
            LoadedProducts.Clear();
            foreach (var item in sorted)
                LoadedProducts.Add(item);
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

            foreach (SelectedProduct product in ProductsDataGrid.Items)
            {
                //  decimal rate = product.Rate2 ?? 0;
                //                 decimal qty = product.Quantity ?? 0;
                // grandTotal += rate * qty;
            }
            foreach (var item in ProductsDataGrid.Items)
            {
                if (item is SelectedProduct product)
                {
                    // Handle nullable values for Rate2 and Quantity
                    decimal rate = product.Rate2;
                    decimal qty = product.Quantity;
                    grandTotal += rate * qty;
                }
            }

            // GrandTotalTextBlock.Text = $"{grandTotal:C}";
            GrandTotalTextBlock.Text = grandTotal.ToString("C", new System.Globalization.CultureInfo("en-IN"));


        }



        // private void LoadProductsButton_Click(object sender, RoutedEventArgs e)
        // {
        //     // string selectedCategory = CategoryComboBox.SelectedItem as string;
        //     string selectedCategory ="Sambar_Masala";
        //      string connStr = "Driver={SQL Server};Server=.;Database=rs_gst_27;Trusted_Connection=True;";
        //     if (!string.IsNullOrEmpty(selectedCategory))
        //     {
        //         List<Product> products = GetProductsByCategory(selectedCategory,connStr);
        //         ProductsDataGrid.ItemsSource = products;
        //         PNameNative.FontFamily = new FontFamily("SunTommy y Tamil");
        //     }
        // }





        private void masalaComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // var selectedItem = (masalaComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                // MessageBox.Show($"You selected: {selectedItem}");
                var selectedItem = masalaComboBox.SelectedItem as ComboBoxItem;
                if (selectedItem != null)
                {
                    string displayText = selectedItem.Content.ToString();   // Tamil text
                    string selectedCategory = selectedItem.Tag.ToString();             // Actual value
                                                                                       // MessageBox.Show($"Display Text: {displayText}\nValue: {Mvalue}");
                                                                                       //  string selectedCategory = "Kari_Masala";
                    if (!string.IsNullOrEmpty(selectedCategory))
                    {
                        // Prompt user for multiplier using a simple input dialog
                        string input = Microsoft.VisualBasic.Interaction.InputBox(
                            "Enter quantity multiplier (e.g., 2 for double, 3 for triple):",
                            "Quantity Multiplier",
                            "1");

                        // Try to parse the input as an integer multiplier
                        if (decimal.TryParse(input, out decimal multiplier) && multiplier > 0)
                        {
                            List<SelectedProduct> products = GetProductsByCategory(selectedCategory, multiplier);
                            ProductsDataGrid.ItemsSource = null;
                            ProductsDataGrid.Items.Clear();
                            foreach (var p in products)
                            {
                                LoadedProducts.Add(p);
                            }
                            ProductsDataGrid.ItemsSource = LoadedProducts;
                            PNameNative.FontFamily = new FontFamily("SunTommy y Tamil");
                            UpdateGrandTotal();
                        }
                        else
                        {
                            MessageBox.Show("Invalid multiplier. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        // Event handler for button click to load products and ask user for quantity multiplier
        // private void LoadProductsButton_Click(object sender, RoutedEventArgs e)
        // {
        //     // string selectedCategory = CategoryComboBox.SelectedItem as string;
        //     // string selectedCategory = "Sambar_Masala";

        //     string selectedCategory = "Kari_Masala";
        //     if (!string.IsNullOrEmpty(selectedCategory))
        //     {
        //         // Prompt user for multiplier using a simple input dialog
        //         string input = Microsoft.VisualBasic.Interaction.InputBox(
        //             "Enter quantity multiplier (e.g., 2 for double, 3 for triple):",
        //             "Quantity Multiplier",
        //             "1");

        //         // Try to parse the input as an integer multiplier
        //         if (decimal.TryParse(input, out decimal multiplier) && multiplier > 0)
        //         {
        //             List<SelectedProduct> products = GetProductsByCategory(selectedCategory, multiplier);
        //             ProductsDataGrid.ItemsSource = null;
        //             ProductsDataGrid.Items.Clear();
        //             foreach (var p in products)
        //             {
        //                 LoadedProducts.Add(p);
        //             }
        //             ProductsDataGrid.ItemsSource = LoadedProducts;
        //             PNameNative.FontFamily = new FontFamily("SunTommy y Tamil");
        //         }
        //         else
        //         {
        //             MessageBox.Show("Invalid multiplier. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //         }
        //     }
        // }






        // private List<Product> GetProductsByCategory(string category) 
        // {
        //     List<Product> productList = new List<Product>();
        //     string connStr = "Driver={SQL Server};Server=.;Database=rs_gst_27;Trusted_Connection=True;";

        // string query = @"
        //     SELECT TOP 50 ProductName, QTY, Unit, Category
        //     FROM [dbo].[ProductTemplates]
        //     WHERE Category = @Category
        //     ORDER BY ProductName ASC";

        // SqlParameter[] parameters = new SqlParameter[]
        // {
        //     new SqlParameter("@Category", category)
        // };

        // var products = DatabaseHelper.GetEntitiesFromDatabase<Product>(connStr, query, parameters);
        // Products = new ObservableCollection<Product>(products);

        public List<SelectedProduct> GetProductsByCategory(string category, decimal multiplier)
        {
            string connectionString = "Driver={SQL Server};Server=.;Database=rs_gst_27;Trusted_Connection=True;";
            var productList = new List<SelectedProduct>();
            string query = @"
        SELECT 
                p.pname, 
              p.Rate1, 
                p.Rate2, 
                pt.Category, 
                pt.QTY,
                pt.unit
            FROM 
                Product p
            INNER JOIN 
                ProductTemplates pt ON p.Pcode = pt.ProductName
            WHERE 
                pt.Category = ?";

            using (var conn = new OdbcConnection(connectionString))
            using (var cmd = new OdbcCommand(query, conn))
            {
                cmd.Parameters.Add(new OdbcParameter("", category)); // ODBC uses "?" as a placeholder, so parameter name is ignored
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Multiply quantity by the entered multiplier
                        decimal baseQuantity = Convert.ToDecimal(reader["QTY"]);

                        // Determine which rate to use based on Unit
                        // string unit = reader["Unit"].ToString();
                        // decimal rate = unit == "kg"
                        //     ? Convert.ToDecimal(reader["Rate2"])
                        //     : Convert.ToDecimal(reader["Rate1"]);


                        string unit = reader["Unit"].ToString(); // normalize casing
                        decimal rate;

                        switch (unit)
                        {//gram
                            case "fpuhk;":
                            case "ml":
                                rate = Convert.ToDecimal(reader["Rate1"]);
                                break;
                            //kilo
                            case "fpNyh":
                            case "liter":
                                rate = Convert.ToDecimal(reader["Rate2"]);
                                break;
                            //piece
                            case "gP];":
                            case "unit":
                                rate = Convert.ToDecimal(reader["Rate2"]);
                                break;

                            default:
                                rate = 0; // fallback rate
                                break;
                        }


                        productList.Add(new SelectedProduct
                        {
                            PName = reader["pname"].ToString(),
                            Quantity = baseQuantity * multiplier,
                            // Unit=reader["Unit"].ToString(),

                            // QTY = reader["QTY"] != DBNull.Value ? Convert.ToSingle(reader["QTY"]) : 0,
                            // Unit = reader["Unit"].ToString(),
                            // Rate2=Convert.ToDecimal(reader["Rate2"]),
                            Unit = unit,
                            Rate2 = rate,
                            Category = reader["Category"].ToString()
                        });
                    }
                }
            }

            return productList; // Ensures all code paths return a value
        }


        private bool _isRateComboInitialized = false;
        private void RateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_isRateComboInitialized)
            {
                _isRateComboInitialized = true;
                return; // Skip this one-time auto-triggered event
            }
        }

        private void RateComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && RateComboBox.SelectedItem != null)
            {
                HandleRateSelection(moveFocusToQuantity: true);
            }
        }



        private void HandleRateSelection(bool moveFocusToQuantity = false)
        {
            if (RateComboBox.SelectedItem != null && _currentSelectedProduct != null)
            {
                string selectedValue = RateComboBox.SelectedItem.ToString();
                decimal rateToSet = 0;

                // Match based on selected label
                if (selectedValue == _currentSelectedProduct.Caption2) // Rate1
                {
                    if (decimal.TryParse(_currentSelectedProduct.Rate1.ToString(), out decimal caption2Rate))
                        rateToSet = caption2Rate;
                }
                else if (selectedValue == _currentSelectedProduct.Caption1) // CaseRate
                {
                    if (decimal.TryParse(_currentSelectedProduct.CaseRate.ToString(), out decimal caption1Rate))
                        rateToSet = caption1Rate;
                }
                else if (selectedValue == _currentSelectedProduct.Caption3) // Rate2
                {
                    if (decimal.TryParse(_currentSelectedProduct.Rate2.ToString(), out decimal caption3Rate))
                        rateToSet = caption3Rate;
                }
                else
                {
                    // If not matching label, try direct parse (for key entry)
                    decimal.TryParse(selectedValue, out rateToSet);
                }

                // Set the RateTextBox value
                RateTextBox.Text = rateToSet.ToString("0.00");

                // Update model if needed
                if (_selectedRowToUpdate != null)
                {
                    _selectedRowToUpdate.Rate2 = rateToSet;
                }

                // UI transitions
                RateTextBox.Visibility = Visibility.Visible;
                RateComboBox.Visibility = Visibility.Collapsed;

                if (moveFocusToQuantity)
                    QuantityTextBox.Focus();
            }
        }







    }
}