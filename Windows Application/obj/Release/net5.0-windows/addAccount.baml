   M S B A M L   `   `   `  ���� N  JWindows Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Windows_ApplicationWindows_Application  $    Windows_Application.addAccount   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Windows_Application       � Title$  New account�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ WidthAndHeight=�.���  � ColumnDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $��20 � � RowDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��20 �.+��� $��1��$��1��$��
0,1.25,2,0q�$
��Left=�$��Center=�#!What service is this account for?�� -    ��Name$ AccountTextbox��$��1��$��2��$	��240��$��5,3,0,0q�$��Center=��� $��2��$��1��$��0,0,2,0q�$��Center=�-+What is the username/email of this account?�� -   $ UsernameTextbox��$��2��$��2��$	��240��$��5,3,0,0q�$��Center=��� $��3��$��1��$��0,0,2,0q�$��Center=�97Do you want to have the password be randomly generated?�� -    ��Name$ RandomPasswordCheckbox��$��3��$��2��$��Stretch=�$��5,3,0,0q�$��Center=� d� 	IsChecked$ FalseY��� $��4��$��1��$��0,0,2,0q�$��Center=�If no, then type it here.G� -    G�Name$ PasswordTextbox��$��4��$��2��$	��240��$��5,3,0,0q�${�False��� $��5��$��2��$��5,8,0,0q�.+��� -   	 ��Name$	 Submit��
 �� 	IsDefault$

 True��$��Add Account���� -   $	 Cancel�� �� IsCancel$
 True��$��Cancel��$��	130,0,0,0q�