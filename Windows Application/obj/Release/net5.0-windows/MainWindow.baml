   M S B A M L   `   `   `  ���� N  JWindows Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Windows_ApplicationWindows_Application  $    Windows_Application.MainWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Windows_Application     $��18(�  � Title$  Local Password Logger�� � WindowStartupLocation$ CenterScreen=�
������� � SizeToContent$ WidthAndHeight=� � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value)  #System.Windows.Controls.DataGridRow�� %�  '        '  �     �� "  .���  � �� Z� ��  � �� Z� ��  � ��
 �   � P�  �@ 
IsSelected$
	 True��. ���  � �� Z� ��  � �� Z� ��  � ��
 �   ��� "  .���  � �� Z� ��  � �� Z� ��  � ��
 �   � P�  �@ 
IsSelected$
	 True��. ���  � �� Z� ��  � �� Z� ��  � ��
 �   �.��� 
 � ColumnDefinitions
 �� $��40 ��� $
��auto ��� $
��auto ��� $��* ��� $��40 � � RowDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $��20 �.+�&   System.Windows.Controls.DataGrid  -     Name$ PasswordTable��   AlternatingRowBackground
 �����   CanUserAddRows$ False��   CanUserDeleteRows$ False��   CanUserReorderColumns$ False��$��2��$��1��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Service��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	account+  $ Username/Email��$
 auto  �� *
username+  $ Password��$
 auto  �� *censorPassword+4  .System.Windows.Controls.DataGridTemplateColumn   ��  �� Orientation$ 
Horizontal=�$��-2,0,0,0q�$
��Left=�.+��� -    ��Name$ 
NewAccount��$��2.5, 0q�$��44��.���� $��Imgs/newAccountImage.png���� -   $ SendAccount��$��2.5, 0q�$��44��.���� $��Imgs/sendAccountImage.png���� -   $ ReceiveAccount��$��2.5, 0q�$��44��.���� $"��Imgs/recciveAccountImage.png��   CellTemplate �� .R��� $ 
Horizontal=�$
��2, 0q�$
��Left=�.+��� $ CopyPassword��-   $��2.5, 0q�$��44��.���� $ ��Imgs/copyPasswordImage.png���� $ ModifyAccount��-   $��2.5, 0q�$��44��.���� $!��Imgs/modifyAccountImage.png���� $ DeleteAccount��-   $��2.5, 0q�$��44��.���� $!��Imgs/deleteAccountImage.png��