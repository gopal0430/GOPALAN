using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Data.Odbc;
using GDS_Test_data.Models;
using GDS_Test_data.Helpers;
using System.Windows;

namespace MyWpfApp.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private string _productCode;
		   private string _productSearchText;
		private ObservableCollection<Product> _products;
		private ObservableCollection<ProductEntry> _productEntries;
		private Product _selectedProduct;
    //    private string _quantity;
	     public MainViewModel()
        {
            _products = new ObservableCollection<Product>();
            _productEntries = new ObservableCollection<ProductEntry>();
        }

		public string ProductCode
		{
			get { return _productCode; }
			set
			{
				_productCode = value;
				OnPropertyChanged();
				LoadProductData();
			}
		}
 		public string ProductSearchText
        {
            get { return _productSearchText; }
            set
            {
                _productSearchText = value;
                OnPropertyChanged();
                LoadProductData();
            }
        }
		public ObservableCollection<Product> Products
		{
			get { return _products; }
			set
			{
				_products = value;
				OnPropertyChanged();
			}
		}

  public ObservableCollection<ProductEntry> ProductEntries
        {
            get { return _productEntries; }
            set
            {
                _productEntries = value;
                OnPropertyChanged();
            }
        }
		public Product SelectedProduct
		{
			get { return _selectedProduct; }
			set
			{
				_selectedProduct = value;
				OnPropertyChanged();
				if (_selectedProduct != null)
				{
					ProductCode = _selectedProduct.PCode;
				}
			}
		}

		// public string Quantity
        // {
        //     get { return _quantity; }
        //     set
        //     {
        //         _quantity = value;
        //         OnPropertyChanged();
        //     }
        // }

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void LoadProductData()
		{
			string connectionString = "Driver={SQL Server};Server=.;Database=rs_gst_27;Trusted_Connection=True;";
			string query = @"
				SELECT top 50
				
					 pname, Rate2, mrp 
				FROM Product
				 WHERE  active='1.0'and  pcode LIKE ? ORDER BY pcode ASC";
			OdbcParameter[] parameters = new OdbcParameter[]
			{

				new OdbcParameter("@pcode", ProductSearchText + "%")
				// new OdbcParameter("@pcode", "%" + ProductSearchText + "%"+  "ORDER BY pcode ASC")
			};

			var products = DatabaseHelper.GetEntitiesFromDatabase<Product>(connectionString, query, parameters);

			Products = new ObservableCollection<Product>(products);
            
		}
	 public void AddProductEntry()
        {
            // if (SelectedProduct != null && int.TryParse(Quantity, out int qty))
            // {
			if (SelectedProduct != null)
{
                int qty = Quantity; 
                var productEntry = new ProductEntry
                {
                    ProductName = SelectedProduct.NativePName,
                    Rate = (float)(SelectedProduct.Rate2 ?? 0),
                    Quantity = qty,
                    Total = (float)((SelectedProduct.Rate2 ?? 0) * qty)
                };

                ProductEntries.Add(productEntry);
            }
        }
	 private decimal? _rate2;
     private int _quantity;

    public string PNameNative { get; set; }

    public decimal? Rate2
    {
        get => _rate2;
        set
        {
            _rate2 = value;
            OnPropertyChanged(nameof(Rate2));
            OnPropertyChanged(nameof(Total)); // Update Total when Rate2 changes
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
            OnPropertyChanged(nameof(Total)); // Update Total when Quantity changes
        }
    }

    public string NativePName{ get; set; }
        

    public decimal Total => (Rate2 ?? 0) * Quantity; // Calculate Total dynamically

    // public event PropertyChangedEventHandler PropertyChanged;

    // protected void OnPropertyChanged(string propertyName)
    // {
    //     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    // }
	  public class ProductEntry
    {
        public string ProductName { get; set; }
        public float Rate { get; set; }
         public int Quantity { get; set; }
        public float Total { get; set; }
    }

     
	
	}
}