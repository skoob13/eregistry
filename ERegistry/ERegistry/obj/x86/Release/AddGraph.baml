   M S B A M L   `   `   `  ���� D  @ERegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ERegistry	ERegistry      ERegistry.AddGraph   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:ERegistry       � Title$?  9Связать специальность и график��$	��460��$	��600�� � WindowStyle$ 
ToolWindow=� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=�.���  � RowDefinitions �� $��28 ��� $��60 ��� �� $��60 ��� �� $��30 ��� $��40 �.+�� $��0�����#19191F.+��� 
�������$��Center=�$��Center=�WUСоздать график и добавить специальность врачу� $��1�����#d8d8d8 �� �� .+��� $��0��$��4,0,0,0q�$��Center=�!Шаг 1: выбор врача�� -   $��0��$��2,2,4,2q�$	��140��$��Right=�.��Выбрать врача�� -   $��OK_step1��$y�Hidden=�$
��Bold"�$��	0,0,150,0q�$��Center=�
��� � �$��Right=�OK� $��1�� � ColumnDefinitions �� $��80 ��� �� $	��120 �.+��� $��4,0,0,0q�$��0��$��Center=�Фамилия:�� -   $��Surname_search��$��1��$��2q�$��Center=��� -   $��4q�$��2��.��
Найти&   System.Windows.Controls.DataGrid  -   $��Doctors��$	��0.5q�$��2��   AlternatingRowBackground �#d8d8d8 �� AlternationCount$ 2��   RowHeaderWidth$ 0Q�	   CanUserAddRows	 .  
   CanUserDeleteRows
 .     CanUserReorderColumns .     
IsReadOnly .    GridLinesVisibility$
 None=�� $��3�����#d8d8d8 �� �� .+��� $��0��$��4,0,0,0q�$��Center=�<:Шаг 2: выбор специальности врачу�� -   $��0��$��2,2,4,2q�$	��140��$��Right=�.��+)Выбрать специальность�� -   $��OK_step2��$y�Hidden=�$��0��$
��Bold"�$��	0,0,150,0q�$��Center=�
��� � �$��Right=�OK� $��1�� �� $��80 ��� �� $	��120 �.+��� $��4,0,0,0q�$��0��$��Center=�Название:�� -   $��Spec_search��$��1��$��2q�$��Center=��� -	   $��Spec_search_button��$��4q�$��2��.��
Найти  -
   $
��Spec��$	��0.5q�$��4�� �#d8d8d8$ 2��$ 0Q�	 .  
 .   .   . $
 None=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * � $��5�����#d8d8d8.+��� $��4,0,0,0q�$��Center=�'%Шаг 3: создать график�� -   $��OK_step3��$y�Hidden=�$
��Bold"�$��	0,0,150,0q�$��Center=�
��� � �$��Right=�OK�� -   $��CrGraph��$��0��$��2,2,4,2q�$	��140��$��Right=�.��Создать график� $��6�����#19191F.+��� -   $	��140��$��30��$��Center=�$��Right=�$��4q�.��Добавить запись�� -   $	��140��$��30��$��Center=�$
��Left=�$��4q�.��Очистить форму