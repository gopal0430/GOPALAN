   M S B A M L   `   `   `  ����  MyWpfApp    MyWpfApp.NewFileControl   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NewFileControl��5   	   $	��400��5   	   $	��600��5   	   .��5   
   � $��10q�6    � RowDefinitions 5      �� 5	      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�5      .+�5      �� $��Product:��6    $��Center=�5       �� 5      -   5         ��Name$ ProductTextBox��5   "   $	��150��5   "   $	��5,0q�5   "   5   "   �� 5      $��Rate:��6    $��Center=�5       �� 5      -   5        $ RateTextBox��5   "   $	��100��5    "   $y�Visible=�5!   "   �� 5O      -   5         ��Name$ RateComboBox��5O      $	��200��5P      $��SunTommy y Tamil)�5Q      $y�	Collapsed=�5R      $��5q�5V      
�������
���   �$��14(�5Y      $
��Left=�5Z      $	��Top=�5[      ��5S      �� *RateOptions+5[      �� 5]      $��	Quantity:��6    $��Center=�5^       �� 5_      -   5        $ QuantityTextBox��5_   "   $	��100��5`   "   $	��5,0q�5a   "   5b   "   �� 5d      -   5         ��Name$ SeparateRowsCheckBox��5d   #   $��Add as separate rows��5e   #   $
��10,5q�5f   #   �� 5p      -   5        $ masalaComboBox��5p   #   $	��200��5q   #   $��30��5r   #   $��Center=�5s   #   $��Center=�5t   #   .@�5v   "   �� $+��%சாம்பார் பொடி��6/   
 � Tag$ Sambar_Masala��5w   /   �� 5x   "   $��கறி மசாலா��6/   $ Kari_Masala��5y   /   5z      5�      &   System.Windows.Controls.DataGrid  5�      -   5          Name$ ProductsDataList��5�         
IsReadOnly$
 True��5�      $��1��5�      	   AutoGenerateColumns$	 False��5�      
   CanUserAddRows$
 False��5�         SelectionMode$ Single=�5�      $��10q�5�      $	��Top=�5�      $	��200��5�      $y�	Collapsed=�5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   -   5        	PName��,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��5�   5      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5�   5      
FontFamily$ SunTommy)�5�   5   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   5   �� *pname+5�   5     5�   "   $
 Rate��65   $ * 5�   5    5�   5   �� *Rate2+5�   5     5�   "   $	 MRP��65   $ * 5�   5    5�   5   �� *mrp+5�   5   5�        5�      -	   5        $ ProductsDataGrid��5�      $��2��5�      $��0,10,0,0q�5�      $	 False��5�      $
 True��5�      $
 False��5�      $ Single=�5�      $
��Auto=�5�         HeadersVisibility$ Column=�5�         MetroDataGrid#���   5�      ��5�      �� *LoadedProducts+ � 	Resources 5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5�   "   "  6(   .�5�   *   ��  � ��
 �����5�   1   �� 5�   *    � ��
 �   �5�   1   �� 5�   *    � ��$
 Bold"�5�   1   �� 5�   *    � ��$ Center=�5�   1   5�   #   5�       5�        5�   "   -
   5        PNameNative��$ Product��5�   5   $ * 5�   5    5�   5   �� *PName+   ElementStyle 5�   *   �� 5�   2   " ��68   .�5�   :   ��  � ��$ SunTommy y Tamil)�5�   A   5�   3   5�   #     5�   "   $
 RATE��65   $ * 5�   5    5�   5   �� *Rate2+5�   5     5�   "   $	 QTY��65   $ * 5�   5   $ SunTommy y Tamil)�5�   6    5�   5   �� *DisplayQuantity+5�   6     5�   "   $ TotalAmount��65   $ * 5�   5    5�   5   �� *Total+5�   5   5�      �� 5�      $��2��6   
������� �� CornerRadius$ 10��5�       �� Padding$ 10q�5�      $��	0,150,0,0q�5�      $��Bottom=�5�      ._�5�      �� $ 
Horizontal=�6%   $��Right=�5�   %   .+�5�   "   �� $��Grand Total: ��6,   $
��Bold"�5�   ,   $��16(�5�   ,   
����  �$��Center=�5�   ,   �� 5�   "   -   5         ��Name$ GrandTotalTextBlock��5�   ,   $
��Bold"�5�   ,   $��16(�5�   ,   
��� d �$��10,0,0,0q�5�   ,   $��Center=�5�   ,   5�      5�      5�      5�      