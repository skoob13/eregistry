   M S B A M L   `   `   `  ���� D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry  X TXceed.Wpf.Toolkit, Version=2.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit     ERegistry.History   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:ERegistry     Kxctk:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     $	��600��$	��600��  N� Title$  History��.���  � RowDefinitions �� $��50 ��� .+�� $��0�����#19191F � ColumnDefinitions �� $��10 ��� �� $	��120 ��� $��10 �.+�� $��1��$��Center=�.+��� $��20(�
�������История болезни� $��2��$��Center=�.+��� -   $	��Add��$��30��
������ $��0q�.����  J� Opacity$	 0.9Q� �� CornerRadius$ 6��$��1q�
������� �� Padding$ 4q�._��� $��14(����#19191FДобавить запись����  �� 
TargetType" ��.R��� $��Border��#��z��#��z��#��z��._��� #��z��#��z��#��z�� �� Triggers P�  P� Property �@J�	IsFocused	 P� Value	 . . ��� 
 �� 
TargetName$
 Border�� �� Property � �� �� Value
 ���� � $��1��
������� �� $	��100 ��� $	��180 ��� .+�� $��0�����#d8d8d8 �� �� ��  �� $��10 ��� $	��100 ��� �� $	��100 ��� �� $��10 �.+��� $��0��$��1��$��Center=�Паспорт:�� $��1��$��1��$��Center=�Фамилия:�� $��2��$��1��$��Center=�	Имя:%  Xceed.Wpf.Toolkit.MaskedTextBox  -   $��passport��   Mask$ 00 00 000 000��$��Center=�$��0��$��2��$��4q��� -   $��surname��$��Center=�$��1��$��2��$��4q��� -   $
��name��$��Center=�$��2��$��2��$��4q��� $��0��$��3��$��Center=�Отчество:�� $��1��$��3��$��Center=�Дата рождения:�� -   $
��otch��$��Center=�$��0��$��4��$��4q�(  "System.Windows.Controls.DatePicker  -   $��birth��$��1��$��4��$��Center=�$��2,0,2,0q�$��0q��� -   $��b_flush��$��2��$��3��$��4q�.��Очистить�� -   $��b_search��$��2��$��4��$��4q�$��Right=�$	��100��.��
Найти� $��1�����#d8d8d8 �� $��30 ��� �� $��30 �.+�� $��0�����#19191F.+��� $��Bottom=�
�������$��12(� �� Padding$ 10,0,0,2q�&$Найденные пациенты:&   System.Windows.Controls.DataGrid  -	   $��Clients��$��1��$	��0.5q�   AlternatingRowBackground �#d8d8d8 �� AlternationCount$ 2��   RowHeaderWidth$ 0Q�   CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     
IsReadOnly .    GridLinesVisibility$
 None=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * � $��3�����#19191F.+��� -
   $��Results��
�������$��12(�$ 10,0,0,2q�$��Bottom=�%#Результаты поиска: �� -   $��ResultsName��$
��Bold"��� -   $��SelectClient��$	��100��$��4,4,14,4q�$��Right=�.��
Поиск� $��2��.+�  -   $��Search��$	��0.5q� �#d8d8d8$ 2��$ 0Q� .   .   .   . $
 None=� � ContextMenu �� .@�m� -   $��EditMI��$ ��Редактировать�� m� Icon ��    Edit#��[  m� -   $��DeleteMI��$��Удалить�� ��  
 Delete#��[ 