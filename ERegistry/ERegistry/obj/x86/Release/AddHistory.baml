   M S B A M L   `   `   `  ���� D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry  X TXceed.Wpf.Toolkit, Version=2.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit     ERegistry.AddHistory   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:ERegistry     Kxctk:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit       � Title$B  <Создать запись в истории болезни��$	��600��$	��500�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=�.��� ���#19191F � RowDefinitions �� $��30 ��� $	��120 ��� $��30 ��� $	��100 ��� �� $��20 ��� $��30 �.+��� $��0��$��4,0,0,0q�
�������$��Center=�Добавить запись� $��1�����#d8d8d8 �� �� �� ��  � ColumnDefinitions �� $��10 ��� $	��100 ��� �� $	��100 ��� �� $��10 �.+��� $��0��$��1��$��Center=�Паспорт:�� $��1��$��1��$��Center=�Фамилия:�� $��2��$��1��$��Center=�	Имя:%  Xceed.Wpf.Toolkit.MaskedTextBox  -   $��passport��   Mask$ 00 00 000 000��$��Center=�$��0��$��2��$��4q��� -   $��surname��$��Center=�$��1��$��2��$��4q��� -   $
��name��$��Center=�$��2��$��2��$��4q��� $��0��$��3��$��Center=�Отчество:�� $��1��$��3��$��Center=�Дата рождения:�� $��2��$��3��$��Center=�Дата приема:�� -   $
��otch��$��Center=�$��0��$��4��$��4q�(  "System.Windows.Controls.DatePicker  -   $��birth��$��1��$��4��$��Center=�$��2,0,2,0q�$��0q�&   Xceed.Wpf.Toolkit.DateTimePicker  -   $��rDate���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	AllowSpin .     DefaultValue$ 10:00:00X�&   Xceed.Wpf.Toolkit.DateTimeUpDown	   Format$	 FullDateTime=�$��2��$��4��$��Center=�$��2,0,2,0q�$��0q����� 
 �� 	Resources
 "  Xceed.Wpf.Toolkit.TimePicker �� 
TargetType �� Property �� Value��%D   '        �� "  .���  �@ TimeInterval$ 00:15:00.000h��� -   $��b_flush��$��3��$��1��$��4q�.��Очистить�� -   $��b_search��$��3��$��4��$��4q�$��Right=�$	��100��.��
Найти� $��2��.+��� $��4,0,0,0q�$��Center=�
�������><Найденные записи в регистратуре:�� -	   $��	SelectReg��$��2q�$��Right=�$	��100��.��Выбрать запись�� -
   $��OK_step1��$y�Hidden=�$
��Bold"�$��	0,0,110,0q�$��Center=�
��� � �$��Right=�Запись выбрана&   System.Windows.Controls.DataGrid  -   $��Clients��$��3��$	��0.5q�   AlternatingRowBackground �#d8d8d8 �� AlternationCount$ 2��   RowHeaderWidth$ 0Q�   CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     
IsReadOnly .    GridLinesVisibility$
 None=�� $��4�� �� $��20 ��� �� �� .+�� $��0�� �� �� .+��� -   $��	tb_client��$��4,0,0,0q�$��0��
�������$��Center=�$y�Hidden=�Клиент �� -   $��client_surname��$
��Bold"��� -   $��tb_dt��$��0,0,4,0q�$��1��
�������$��Center=�$��Right=�$y�Hidden=�'%Дата и время приема: �� -   $��registry_date��$
��Bold"� в �� -   $��registry_time��$
��Bold"�� $��1�� �� $��4 ��� $��20 ��� �� $��4 �.+��� $��1��
�������$��4,0,0,0q�Диагноз:�� -   $��tb_diagnosis��$
��Auto=� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $��2��$��4,0,4,0q�� $��2�� �� $��4 ��� $��20 ��� �� $��4 �.+��� $��1��
�������$��4,0,0,0q�Описание:�� -   $��
tb_details��$
��Auto=�$
 Wrap=� . $��2��$��4,0,4,0q�� $��3�� �� $��4 ��� $��20 ��� �� $��4 �.+��� $��1��
�������$��4,0,0,0q�(&Назначенное лечение:�� -   $��	tb_curing��$
��Auto=�$
 Wrap=� . $��2��$��4,0,4,0q�� $��5��.+��� $��4,0,0,0q�$��Center=�
�������20Добавить анализы: выбрано �� -   $��Count��$
��Bold"�0$" анализов на сумму �� -   $	��Sum��$
��Bold"�0 рублей�� -   $��AddAnalyzes��$	��100��$��0,0,4,0q�$��Right=�.��Добавить� $��6��.+��� -   $	��Add��$	��100��$��2q�.��Добавить в БД