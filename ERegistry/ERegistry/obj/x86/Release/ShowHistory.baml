   M S B A M L   `   `   `  ���� D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry      ERegistry.ShowHistory   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:ERegistry       � Title$'  !Звпись №1 от 12.05.2016��$	��600��$	��500�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=�.��� ���#19191F � RowDefinitions �� $��30 ��� $��30 ��� �� $��30 ��� �� $��30 ��� �� $��30 ��� �� $��30 �.+��� $��0��$��4,0,0,0q�
�������$��Center=�$��10(�Клиент �� -   $��tb_cname��$
��Bold"�20Тарасов Георгий Андреевич у врача �� -   $��tb_dname��$
��Bold"�0.Рамзанов Олег Наркизович�� $��1��$��4,0,0,0q�
�������$��Center=�Диагноз:�� -   $��tb_diagnosis��$
��Auto=� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $��2��$��4,0,4,0q��� $��3��$��4,0,0,0q�
�������$��Center=�Описание:�� -   $��
tb_details��$
��Auto=�$
 Wrap=� . $��4��$��4,0,4,0q��� $��5��$��4,0,0,0q�
�������$��Center=�Лечение:�� -   $��	tb_curing��$
��Auto=�$
 Wrap=� . $��6��$��4,0,4,0q��� $��7��$��4,0,0,0q�
�������$��Center=�#!Выбрано анализов: �� -   $��tb_count��$
��Bold"�0. На сумму �� -   $��tb_cost��$
��Bold"�0 рублей�� -   $��SelectAnalyzes��$��7��$��Right=�$��2,2,4,2q�$	��100��.��Выбрать анализы&   System.Windows.Controls.DataGrid  -	   $��
DGAnalyzes��$��8��$	��0.5q�   AlternatingRowBackground �#d8d8d8 �� AlternationCount$ 2��	   RowHeaderWidth$	 0Q�
   CanUserAddRows
 .     CanUserDeleteRows .     CanUserReorderColumns .     
IsReadOnly .    GridLinesVisibility$
 None=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * �� -
   $��Close��$��9��$
��Left=�$��2,2,4,2q�$	��100��.��Закрыть�� -   $
��Save��$��9��$��Right=�$��2,2,4,2q�$	��100��.��Сохранить