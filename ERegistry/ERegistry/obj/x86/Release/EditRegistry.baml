   M S B A M L   `   `   `  ���� D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry      ERegistry.EditRegistry   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:ERegistry     $	��380��$	��300��  � Title$#  Изменить запись�� � WindowStyle$ 
ToolWindow=� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=�.���  � RowDefinitions �� $	��100 ��� $��60 ��� �� $��30 �.+�� -   $��bg��$��0�����#FF4C4C �� �� �� $��30 �.+��� -   $��	labelName��$��1��
�������$
��Bold"�$��20(�$��Center=�$��4,0,0,0q�#!Георгий Андреевич�� -   $��labelSurame��$��0��
�������$
��Bold"�$��30(�$��Center=�$��4,0,0,0q�Тарасов�� $��2��
�������$��12(�$��Center=�$��4,0,0,0q�идет в �� -   $��	labelTime��$
��Bold"�12:00 к �� -   $��labelDoctor��$
��Bold"�#!Олегу Наркизовичу на �� -   $��labelService��$
��Bold"�Горловое пение� $��1�����#d8d8d8 �� �� .+��� $��0��$��4,0,0,0q�$��Center=�Изменить услугу�� -   $
��edit��$��0��$��2,2,4,2q�$	��140��$��Right=�.��Изменить�� -   $��OK_step2��$y�Hidden=�$��0��$
��Bold"�$��	0,0,150,0q�$��Center=�
��� � �$��Right=�Сохранено!� $��1�� � ColumnDefinitions �� $��80 ��� �� $	��100 �.+��� $��4,7,0,7q�$��0��$��Center=�Название:�� -	   $��
Service_tb��$��1��$	��2,6q�$��Center=��� -
   $��	Service_b��$��4q�$��2��.��
Найти&   System.Windows.Controls.DataGrid  -   $��Service��$	��0.5q�$��2��   AlternatingRowBackground �#d8d8d8 �� AlternationCount$ 2��   RowHeaderWidth$ 0Q�	   CanUserAddRows	 .  
   CanUserDeleteRows
 .     CanUserReorderColumns .     
IsReadOnly .    GridLinesVisibility$
 None=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * � $��4�����#d8d8d8 �� �� �� .+��� -   $��2��$��4q�.��Закрыть�� -   $��GetCheck��$��0��$��4q�.��Оплатить