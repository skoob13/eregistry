   M S B A M L   `   `   `  ����D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry  5   	       ERegistry.SpecDictionary   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ERegistry     5   	   -   5          � Title$1  +Словарь специальностей��5   	   $	��300��6(   $	��500��65    � WindowStyle$ 
ToolWindow=�5	   	    � WindowStartupLocation$ CenterOwner=�6"    � 
ResizeMode$ NoResize=�5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      6   .+�5   
   �� $��0��6   $��Center=�6!   $��8,0,0,0q�6<   .,Специализация и графики6f   �� 5   
   -   5        $��0��5      $��28��6   $	��100��6*   $��Right=�66   $��0,0,8,0q�6R   .��6u   Добавить запись5      &   System.Windows.Controls.DataGrid  5   
   -   5        $	��Dic��5       $��1��6   $��1q�6+   ���#d8d8d8   RowHeaderWidth$ 0Q�6U      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .  	   CanUserResizeColumns	 .  $��2,0,2,4q�5   h   
   AutoGenerateColumns
 .    GridLinesVisibility$
 None=�5   .    �� AlternationCount$ 2��6I      AlternatingRowBackground �#d8d8d85      5      5      