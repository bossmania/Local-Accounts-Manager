   M S B A M L   `   `   `  ���� N  JWindows Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Windows_ApplicationWindows_Application       Windows_Application.client   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Windows_Application       � Title$  Send Accounts�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ WidthAndHeight=�.���  � ColumnDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $��20 � � RowDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��20 �.+��� $��1��$��1��64What is the IP that you are sending the accounts to?�� $��0,4,3,0q�$��2��$��1��IP:�� -    ��Name$ IPBox��$��Stretch=�$��2��$��1��$��20,4,0,0q�.��	127.0.0.1�� -    ��Name$ status��$��3��$��1��$��Center=�$��0,2,0,0q�Status: Waiting for the IP.�� $��4��$��1��$��Right=� �� Orientation$ 
Horizontal=�$��0,4,0,0q�.+��� -    ��Name$ Submit��	 �� 	IsDefault$
	 True��.��Submit�� -   $ Cancel��
 �� IsCancel$

 True��$��4,0,0,0q�.��Cancel