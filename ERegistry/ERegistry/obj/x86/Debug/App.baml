   M S B A M L   `   `   `  ����D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry  5          ERegistry.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:ERegistry     5        �� 	Resources  5         DefaultImage �� 	UriSource  Settings  Calendar  Plus  DayView  Blur 
 Doctor 
 Search  Edit 
	 Delete 
 ChiefDefault  	AdDefault  DoctorDefault   ERegistry.DGConverter  DGConverter  	CellStyle �� 
TargetType*  $System.Windows.Controls.DataGridCell �� Property �� Value �� RelativeSource �� 	Converter  OddCell �� BasedOn �� Triggers	 P� Property
 P� Value  EvenCell  ColumnHeader=  7System.Windows.Controls.Primitives.DataGridColumnHeader  	RowHeader:  4System.Windows.Controls.Primitives.DataGridRowHeader  TabControlStyler �� 
TargetType ��Name �� Triggers �� 
TargetName  PlotAreaStyle��%�
  &	        &	 -     &	 _     &	 �     &	 �     &	 �     &	     &	 :    &	 f    &		 �    &	
 �    &	 �    &	     &	 P    &	 c    7  &	 �    7 &	 X    7 &	 �    &	     &	 �    &	 [	    �� 5   
   $ /Assets/Default.jpg?�6+   �� 5   
   $ /Assets/SettingsIcon.png?�6'   �� 5	   
   $ /Assets/Calendar.png?�6'   �� 5
   
   $ /Assets/Plus.png?�6#   �� 5   
   $ /Assets/DayView.png?�6&   �� 5   
   $ /Assets/Blur.png?�6#   �� 5   
   $ /Assets/Doctor.png?�6%   �� 5   
   $ /Assets/Search.png?�6%   �� 5   
   $ /Assets/Edit.png?�6#   �� 5   
   $ /Assets/Delete.png?�6%   �� 5   
   $ /Assets/DefaultChief.jpg?�6+   �� 5   
   $ /Assets/DefaultAd.png?�6(   �� 5   
   $ /Assets/DefaultDoctor.jpg?�6,     5   
   6   �� 5   
   "  6"   .�5      ��  � �� 6+   ��  �� *Self+8   5      �� 5   
   "  6    8   .�5      ��  � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��
 ���� 6,   �� 5        � ��$	 200��6&   �� 5!       � ��$ 50��6'   �� 5"       � ��$ Center=�69    5#      P� 5$      	 �@ 
IsSelected
 . . �5%      ��  � ��
 �  ��63   �� 5&       � ��
 �����63   5'      5)      �� 5,   
   "  6!   8   .�5-      ��  � �� �#D8D8D86+   �� 5.       � ��$ 0q�60   �� 5/       � ��$	 200��6&   �� 50       � ��$ 50��6'   �� 51       � ��$ Center=�69    52      P� 53      	 �@ 
IsSelected
 . . �54      ��  � ��
 �  ��63   �� 55       � ��
 �����63   56      58      �� 5;   
   "  6%   .�5<      ��  � ��
 �����6+   5=      �� 5@   
   "  6"   .�5A      ��  � ��
 �����6+   �� 5B       � ��$ 50��6&   5C      �� 5F   
   " ��6)   .�5G      ��  � ��$ 90��6&   �� 5H       � ��$ 34��6'   �� 5I       � ��$ 
16,0,-16,0q�6'   �� 5J       � �� 5K      �� 5L      " ��6&   .R�5M      � .+�5N      �� $��Border��6%   $��0q�63   ._�5O   "   �� $ ContentSite��63   $��Center=�5P   )   $��Center=�5Q   )   $��Header��5R   )   5S      5T       5U      P� 5V      	 �@��
IsSelected
 . . �5W   "   �� $ Border��6)    � ��
 �����6S   �� 5X   "    � �� �#19191F6?   5Y      P� 5Z      	 �@��
IsSelected
 .  . �5[   "   �� $ Border��6)    � ��
 ���� 6S   �� 5\   "    � ��
 �����6?   5]      5_      5a      5b      �� 5e   
   " �6&   .�5f      ��  � ��
 ���� 6+   5g      5i      5j      