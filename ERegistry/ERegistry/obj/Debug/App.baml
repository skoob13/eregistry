   M S B A M L   `   `   `  ����D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry  5          ERegistry.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:ERegistry     5        �� 	Resources  5         DefaultImage �� 	UriSource  Settings  Calendar  Plus  DayView  Blur 
 Doctor 
 Search   ERegistry.DGConverter  DGConverter 	 OddCell �� 
TargetType*  $System.Windows.Controls.DataGridCell �� BasedOn �� Property �� Value �� Triggers P� Property P� Value 
 EvenCell  ColumnHeader=  7System.Windows.Controls.Primitives.DataGridColumnHeader  	RowHeader:  4System.Windows.Controls.Primitives.DataGridRowHeader  TabControlStyler	 �� 
TargetType
 ��Name �� Triggers �� 
TargetName��%�  &	        &	 -     &	 _     &	 �     &	 �     &	 �     &	     &	 :    &	 f    &		 y    7 &	
     7 &	 �    &	 �    &	 ;    �� 5   
   $ /Assets/Default.jpg?�6+   �� 5   
   $ /Assets/SettingsIcon.png?�6'   �� 5	   
   $ /Assets/Calendar.png?�6'   �� 5
   
   $ /Assets/Plus.png?�6#   �� 5   
   $ /Assets/DayView.png?�6&   �� 5   
   $ /Assets/Blur.png?�6#   �� 5   
   $ /Assets/Doctor.png?�6%   �� 5   
   $ /Assets/Search.png?�6%     5   
   6   �� 5   
   "  6    8   .�5      ��  � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��
 ���� 6,   �� 5       � ��$	 200��6&   �� 5       � ��$ 50��6'   �� 5       � ��$ Center=�69    5      P� 5       �@ 
IsSelected . . �5      ��  � ��
 �  ��63   �� 5       � ��
 �����63   5      5       �� 5#   
   "  6!   8   .�5$      ��  � �� �#D8D8D86+   �� 5%       � ��$ 0q�60   �� 5&       � ��$	 200��6&   �� 5'       � ��$ 50��6'   �� 5(       � ��$ Center=�69    5)      P� 5*       �@ 
IsSelected . . �5+      ��  � ��
 �  ��63   �� 5,       � ��
 �����63   5-      5/      �� 52   
   "  6%   .�53      ��  � ��
 �����6+   54      �� 57   
   "  6"   .�58      ��  � ��
 �����6+   �� 59       � ��$ 50��6&   5:      �� 5=   
   " ��6)   .�5>      ��  � ��$ 90��6&   �� 5?       � ��$ 34��6'   �� 5@       � ��$ 
16,0,-16,0q�6'   �� 5A       � �� 5B      �� 5C      "	 ��6&   .R�5D      � .+�5E      �� $��Border��6%   $��0q�63   ._�5F   "   �� $
 ContentSite��63   $��Center=�5G   )   $��Center=�5H   )   $��Header��5I   )   5J      5K       5L      P� 5M       �@��
IsSelected . . �5N   "   �� $ Border��6)    � ��
 �����6S   �� 5O   "    � �� �#19191F6?   5P      P� 5Q       �@��
IsSelected .  . �5R   "   �� $ Border��6)    � ��
 ���� 6S   �� 5S   "    � ��
 �����6?   5T      5V      5X      5Y      5[      5\      