   M S B A M L   `   `   `  ����D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry  5          ERegistry.Registry   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:ERegistry     5        N� Title$  Registry��5	      $	��600��5
      $	��600��6   .��5      �  � RowDefinitions 5   
   �� 5      $	��196 �6   6+   �� 5      6   .+�5   
   � $��0��6   ���#FF4C4C.+�5      �� $��18(�6   
�������$��	0,16,16,0q�69   $��Right=�6L   Friday6p   � 5      -   5        $��AddRegistry��5   I   $	��120��6\   $��30��6h   
�������$��Bottom=�6�   $��Right=�6�   $��	0,0,16,16q�6�    � ColumnDefinitions 5      �� 5      $��16 �6'   64   �� 5      6)    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 2Q�6'      Opacity$	 0.3Q�66      	Direction$	 -90Q�6D      RenderingBias$ Quality=�6T      ShadowDepth$ 1Q�6l   .+�5      �� $��14��6   $��14��6$      Plus#��[  6/   $��Center=�6N   $��Right=�6i   �� 5      $��1��6   $��Center=�6,   $��Center=�6G   Добавить запись6u   5      � 5        5!      �� 5"      $��7* �6$   �� 5#      $��5* �6$   .+�5%      � $��0��6   $��Center=�6$   $��Bottom=�6A   .+�5&      �� $��72(�6    
�������266E   5'      � 5(      $��1��6   $��Center=�6$   .+�5)      �� $��48(�6    
�������
February6K   5*      5+      5,      � 5-   
   $��1��6   
�������$y�Hidden=�6/    5.      �� 5/      $��45 �6    6.   �� 50      6"   .+�52      � $��0��6   ���#101014.+�53      �� $��30(�6   $��Center=�6*   $��Center=�6G   
�������!Ближайшие записи6�   54      � 55      $��1��6   
�������.+�56      � -   5        $��Wrapper��56   N   $��Center=�6   	 � Orientation$	 Vertical=�67   57      58      59      � 5:   
   -   5        $	��Reg��5:      $��1��6   .+�5;      � $	��150��6    5<      �� 5=      $��40 �6$   62   �� 5>      6&   .+�5@      � $��0��6   
��� ��� 5A      �� 5B      6*   �� 5C      6*   .+�5E      �� $��0��6    
���   �$��Center=�6@   !26 февраля 2016 года6s   �� 5F      $��1��6    
���   �$��Center=�6@   Понедельник6j   5G      &   System.Windows.Controls.DataGrid  5H      -   5        $��reger��5H      $��1��6(   
   AutoGenerateColumns
 . .@�5J      0  *System.Windows.Controls.DataGridTextColumn  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Name+   ElementStyle 5K      �� 5L       �� 
TargetType" ��6$   .�5M   "   ��  �� Property � �� �� Value 6?   �� *Name+  DGConverter �� 	Converter# [ 5N      5P      5R      5S      5U      5V      5W      