   M S B A M L   `   `   `  ���� D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry      ERegistry.SelectAnalyzes   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:ERegistry       � Title$5  /Добавить анализ в историю��$	��400��$	��400�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=�.��� ���#19191F � RowDefinitions �� $��30 ��� �� $��30 ��� �� $��20 ��� $��30 �.+��� $��0��$��4,0,0,0q�
�������$��Center=� Список анализов:�� -   $	��Add��$��0��$	��100��$��4,2,4,2q�$��Right=�.��Добавить анализ&   System.Windows.Controls.DataGrid  -   $	��All��$��1��$	��0.5q�   AlternatingRowBackground �#d8d8d8 �� AlternationCount$ 2��   RowHeaderWidth$ 0Q�   CanUserAddRows .  	   CanUserDeleteRows	 .  
   CanUserReorderColumns
 .     
IsReadOnly .    GridLinesVisibility$
 None=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * �� $��2��$��4,0,0,0q�
�������$��Center=�$"Выбранные анализы:  -   $��Selected��$��3��$	��0.5q� �#d8d8d8$ 2��$ 0Q�   ColumnHeaderHeight$ 0Q� .  	 .  
 .   . $
 None=�$ *    HeadersVisibility$
 None=��� $��4��$��4,0,0,0q�
�������$��Center=�#!Выбрано анализов: �� -   $��Count��$
��Bold"�0�� -   $
��Save��$��5��$	��100��$��4,2,4,2q�$��Right=�.��Сохранить�� -   $��Close��$��5��$	��100��$��4,2,4,2q�$
��Left=�.��Закрыть