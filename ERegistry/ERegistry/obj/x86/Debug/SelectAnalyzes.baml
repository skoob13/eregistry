   M S B A M L   `   `   `  ����D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry  5   	       ERegistry.SelectAnalyzes   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ERegistry     5   	     � Title$5  /Добавить анализ в историю��5   	   $	��400��6+   $	��400��68    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$ 
ToolWindow=�6D   .��5
      � ���#19191F � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      6   �� 5      $��30 �6   6*   �� 5      6   �� 5      $��20 �6   6*   �� 5      $��30 �6   6*   .+�5   
   �� $��0��6   $��4,0,0,0q�6!   
�������$��Center=�6E    Список анализов:6r   �� 5   
   -   5        $	��Add��5      $��0��6   $	��100��6)   $��4,2,4,2q�65   $��Right=�6F   .��6t   Добавить анализ6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $	��All��5   6   $��1��6   $	��0.5q�6       AlternatingRowBackground �#d8d8d8 �� AlternationCount$ 2��5         RowHeaderWidth$ 0Q�6(      CanUserAddRows .  	   CanUserDeleteRows	 .  
   CanUserReorderColumns
 .     
IsReadOnly .    GridLinesVisibility$
 None=�5   C      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6^   �� 5   
   $��2��6   $��4,0,0,0q�6!   
�������$��Center=�6E   $"Выбранные анализы:6t     5   
   -   5        $��Selected��5   6   $��3��6   $	��0.5q�6     �#d8d8d8$ 2��5      $ 0Q�6(      ColumnHeaderHeight$ 0Q�6;    .  	 .  
 .   . $
 None=�5   C   $ * 6^      HeadersVisibility$
 None=�6n   �� 5   
   $��4��6   $��4,0,0,0q�6!   
�������$��Center=�6E   #!Выбрано анализов: �� 6s   -   5        $��Count��5   �   $
��Bold"�6}   06�   6�   �� 5   
   -   5        $
��Save��5      $��5��6   $	��100��6*   $��4,2,4,2q�66   $��Right=�6G   .��6v   Сохранить6�   �� 5   
   -   5        $��Close��5      $��5��6   $	��100��6+   $��4,2,4,2q�67   $
��Left=�6H   .��6w   Закрыть6�   5      5       