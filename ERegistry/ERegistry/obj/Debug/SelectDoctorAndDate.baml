   M S B A M L   `   `   `  ����D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry  5   	   #    ERegistry.SelectDoctorAndDate   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ERegistry     5   	     � Title$'  !Отобразить записи��5   	   $	��120��6#   $	��180��60    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$ 
ToolWindow=�6.   $	��180��5
   	   $	��120��6   $	��120��6(   .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��40 �6   6,   �� 5      6!   .+�5   
   �� $��0��6   $��0��6!   $��Center=�61   $��4,0,0,0q�6L   	Врач:6d   �� 5   
   $��1��6   $��0��6!   $��Center=�61   $��4,0,0,0q�6L   	Дата:6d   �� 5   
   -   5        $��Doctors��5      $��0��6"   $��1��6/   $��2q�6?   (  "System.Windows.Controls.DatePicker  5   
   -   5        $
��Date��5      $��1��6!   $��1��6.   $��2q�6>   �� 5   
    
  Search#��[  6   $��2��61   $��0��6>   $��4q�6N   � 5   
   -   5        $
��Find��5   f   $��2q�6>   $��2��6I   $��1��6V   
������� 5      �� 5      $��12 �6#   60   �� 5       6%    J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#         
BlurRadius$ 2Q�6#      Opacity$	 0.3Q�62      	Direction$	 -90Q�6@   	   RenderingBias$	 Quality=�6P   
   ShadowDepth$
 1Q�6h   .+�5%      �� $��12��6   $��12��6     
 Doctor#��[ 6+   $��Center=�6L   $��Right=�6g   �� 5&      $��12(�6   $��1��6&   $��Center=�66   $��Center=�6Q   Отобразить6z   5'      5(      5)      