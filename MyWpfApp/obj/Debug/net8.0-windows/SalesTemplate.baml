   M S B A M L   `   `   `  ����  MyWpfApp    MyWpfApp.SalesTemplate   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Sales Template��5   	   $	��350��6    $	��525��6-   .��5      � .+�5   
   �� $��10q�6   .+�5	      �� $��Select Category:��6   $��16(�6(   $��0,0,0,5q�66   �� 5
      -   5         ��Name$ CategoryComboBox��5
      $	��250��5      $��0,0,0,15q�6   .@�5   
   �� $��
Vegetables��6   �� 5   
   $��Fruits��6   5      �� 5      -   5         ��Name$ MultiplierPanel��5   A    �� Orientation$ 
Horizontal=�6   $y�	Collapsed=�6*   $��0,0,0,15q�6Z   .+�5   
   �� $��Enter Multiplier:��6   $��Center=�6-   $��0,0,10,0q�6H   �� 5   
   -   5         ��Name$ MultiplierTextBox��5      $	��100��5      5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ ProductsDataGrid��5         AutoGenerateColumns$ False��5      $	��300��5         Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Product��6!   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 62   �� *ProductName+  5      $
 Rate��6!   	 6/   �� *Rate1+  5       $ Quantity��6!   	 63   �� *
Quantity+  5!      $ Adjusted Qty��6!   	 67   �� *AdjustedQuantity+5#      5$      5&      5'      