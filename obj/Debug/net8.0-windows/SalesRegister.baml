   M S B A M L   `   `   `  ����  MyWpfApp    MyWpfApp.SalesRegister   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Sales Billing��5   	   $	��800��6   $
��1200��6,   ���	#FF0C3D6A$��Segoe UI)�5       $��14(�66   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� $��
Bill Book:��6   $��Center=�6*   
�������6E   �� 5      $	��150��6   $	��5,0q�6#   �� 5      $��Date:��6   $��Center=�6%   
�������6@   (  "System.Windows.Controls.DatePicker  5      $	��150��6   $	��5,0q�6%   �� 5      $��Bill No:��6   $��Center=�6(   
�������6C   �� 5      $	��100��6   $	��5,0q�6"   �� 5      $��Customer Name:��6   $��Center=�6.   
�������6I   �� 5      $	��200��6   $	��5,0q�6"   5      � 5   
   $��1��6    5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5"      �� $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5#      �� $��Product Name:��6   $��Center=�61   
�������6L   �� 5$      $	��200��6   $	��5,0q�6&   �� 5%      $��Rate:��6   $��Center=�6)   
�������6D   �� 5&      $	��100��6   $	��5,0q�6&   �� 5'      $
��Qty:��6   $��Center=�6(   
�������6C   �� 5(      $	��100��6   $	��5,0q�6&   �� 5)      $��Free:��6   $��Center=�6)   
�������6D   �� 5*      $	��100��6   $	��5,0q�6&   5+      &   System.Windows.Controls.DataGrid  5.      $��1��6      AutoGenerateColumns$ False��6$      HeadersVisibility$ Column=�6@   $��0,0,10,0q�6[      Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$
 S.No��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 67     51      $ Product��6)   $	 200 6:     52      $
 Rate��6)   $ 80 67     53      $	 Qty��6)   $ 80 66     54      $ D.Amt��6)   $ 80 68     55      $
 Dis%��6)   $ 80 67     56      $
 Free��6)   $ 80 67     57      $ Amount��6)   $	 100 69   59      5:      � 5=   
   $��2��6   $��0,10,0,0q�6    � ColumnDefinitions 5>      �� 5?      $��* �6#   �� 5@      $	��300 �6#   .+�5D      �� $��1��6   ���	#FFE6E6E6.+�5E      �� $
��GST:��6   �� 5F      $��185.67��6   �� 5G      $��
Round off:��6   �� 5H      $
��0.09��6   �� 5I      $��Amount:��6   $
��Bold"�6+   �� 5J      $��₹ 3654.00��6   $
��Bold"�6-   $��16(�6?   
��� d �6M   �� 5K      $��PAYMENT��6   
��� � �
�������$��0,10,0,0q�6Q   5L      5M      5N      5O      