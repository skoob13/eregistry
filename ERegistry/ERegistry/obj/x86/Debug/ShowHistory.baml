   M S B A M L   `   `   `  ����D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry  5   	       ERegistry.ShowHistory   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ERegistry     5   	     � Title$'  !Звпись №1 от 12.05.2016��5   	   $	��600��6)   $	��500��66    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$ 
ToolWindow=�6D   .��5
      � ���#19191F � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      6   �� 5      $��30 �6   6*   �� 5      6   �� 5      $��30 �6   6*   �� 5      6   �� 5      $��30 �6   6*   �� 5      6   �� 5      $��30 �6   6*   .+�5   
   �� $��0��6   $��4,0,0,0q�6!   
�������$��Center=�6E   $��10(�6`   Клиент �� 6v   -   5        $��tb_cname��5   �   $
��Bold"�6�   20Тарасов Георгий Андреевич6�    у врача �� 6�   -   5        $��tb_dname��5   �   $
��Bold"�6�   0.Рамзанов Олег Наркизович6  6#  �� 5   
   $��1��6   $��4,0,0,0q�6!   
�������$��Center=�6E   Диагноз:6j   �� 5   
   -   5        $��tb_diagnosis��5   B   $
��Auto=�6    �� TextWrapping$
 Wrap=�6V    �� AcceptsReturn . $��2��6   $��4,0,4,0q�6�   6�   �� 5   
   $��3��6   $��4,0,0,0q�6!   
�������$��Center=�6E   Описание:6k   �� 5   
   -   5        $��
tb_details��5   B   $
��Auto=�6   $
 Wrap=�6T    . $��4��6}   $��4,0,4,0q�6�   6�   �� 5   
   $��5��6   $��4,0,0,0q�6!   
�������$��Center=�6E   Лечение:6j   �� 5   
   -   5        $��	tb_curing��5   B   $
��Auto=�6   $
 Wrap=�6S    . $��6��6|   $��4,0,4,0q�6�   6�   �� 5   
   $��7��6   $��4,0,0,0q�6!   
�������$��Center=�6E   #!Выбрано анализов: �� 6s   -   5        $��tb_count��5   �   $
��Bold"�6}   06�   . На сумму �� 6�   -   5        $��tb_cost��5   �   $
��Bold"�6�   06�    рублей6�   �� 5   
   -   5        $��SelectAnalyzes��5      $��7��6'   $��Right=�64   $��2,2,4,2q�6P   $	��100��6a   .��6�   Выбрать анализы6�   &   System.Windows.Controls.DataGrid  5    
   -	   5        $��
DGAnalyzes��5    6   $��8��6   $	��0.5q�6       AlternatingRowBackground �#d8d8d8 �� AlternationCount$ 2��5!      	   RowHeaderWidth$	 0Q�6(   
   CanUserAddRows
 .     CanUserDeleteRows .     CanUserReorderColumns .     
IsReadOnly .    GridLinesVisibility$
 None=�5"   C      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6^   6n   �� 5#   
   -
   5        $��Close��5#      $��9��6   $
��Left=�6+   $��2,2,4,2q�6F   $	��100��6W   .��6w   Закрыть6�   �� 5$   
   -   5        $
��Save��5$      $��9��6   $��Right=�6*   $��2,2,4,2q�6F   $	��100��6W   .��6v   Сохранить6�   5%      5&      