   M S B A M L   `   `   `  ����  MyWpfApp    MyWpfApp.NewFileControl   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NewFileControl��5   	   $	��400��5   	   $	��600��5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�5      .+�5      �� $��Product:��6   $��Center=�5      �� 5      -   5         ��Name$ ProductTextBox��5      $	��150��5      $	��5,0q�5      5      �� 5      $��Rate:��6   $��Center=�5      �� 5      -   5        $ RateTextBox��5      $	��100��5       $y�Visible=�5!      �� 5)      -   5         ��Name$ RateComboBox��5)      $��16(�5*      $��Segoe UI)�5+      
���   �
�������$y�	Collapsed=�5.      50      �� 53      $��	Quantity:��6   $��Center=�54      �� 55      -   5        $ QuantityTextBox��55      $	��100��56      $	��5,0q�57      58      �� 5:      -   5        $��LoadProductsButton��5:      $	��100��5;      $	��5,0q�5<      $+��%சாம்பார் பொடி��5=      5>      �� 5@      -   5        $��PrintButton��5@      $	��100��5A      $	��5,0q�5B      $��Print��5C      5D      5E      &   System.Windows.Controls.DataGrid  5H   
   -   5          Name$ ProductsDataList��5H         
IsReadOnly$
 True��5I      $��1��5J         AutoGenerateColumns$ False��5K         CanUserAddRows$ False��5L      	   SelectionMode$	 Single=�5M      $��10q�5N      $	��Top=�5O      $	��200��5P      $y�	Collapsed=�5Q      
   Columns
 5S      0  *System.Windows.Controls.DataGridTextColumn  5T      -   5        	PName��,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��5U   %      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5W   %      
FontFamily$ SunTommy)�5X   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5V   %   �� *pname+5X   %     5Y      $
 Rate��6%   $ * 5[   %    5Z   %   �� *Rate2+5[   %     5\      $	 MRP��6%   $ * 5^   %    5]   %   �� *mrp+5^   %   5`        5d   
   -	   5        $ ProductsDataGrid��5d      $��2��5e      $��0,10,0,0q�5f      $ False��5g      $
 True��5h      $ False��5i      $	 Single=�5k      $
��Auto=�5l         HeadersVisibility$ Column=�5m         MetroDataGrid#���   5n      ��5o      �� *LoadedProducts+ � 	Resources 5p      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5q      "  6   .�5r      ��  � ��
 �����5s      �� 5t       � ��
 �   �5u      �� 5v       � ��$
 Bold"�5w      �� 5x       � ��$ Center=�5y      5z      5{      
 5|        5}      -
   5        PNameNative��$ Product��5~   %   $ * 5�   %    5   %   �� *PName+   ElementStyle 5�      �� 5�      " ��6    .�5�      ��  � ��$ SunTommy y Tamil)�5�   %   5�      5�        5�      $
 RATE��6%   $ * 5�   %    5�   %   �� *Rate2+5�   %     5�      $	 QTY��6%   $ * 5�   %    5�   %   �� *
Quantity+5�   %     5�      $ TotalAmount��6%   $ * 5�   %    5�   %   �� *Total+5�   %   5�      �� 5�   
   $��2��6   
������� �� CornerRadius$ 10��5�       �� Padding$ 10q�5�      $��	0,150,0,0q�5�      $��Bottom=�5�      ._�5�      �� $ 
Horizontal=�6   $��Right=�5�      .+�5�      �� $��Grand Total: ��6   $
��Bold"�5�      $��16(�5�      
����  �$��Center=�5�      �� 5�      -   5         ��Name$ GrandTotalTextBlock��5�      $
��Bold"�5�      $��16(�5�      
��� d �$��10,0,0,0q�5�      $��Center=�5�      5�      5�      5�      5�      