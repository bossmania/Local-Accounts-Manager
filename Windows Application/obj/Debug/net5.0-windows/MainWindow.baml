   M S B A M L   `   `   `  ����N  JWindows Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Windows_ApplicationWindows_Application  5   	   $    Windows_Application.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Windows_Application     5   	   $��18(�5        � Title$  Local Password Logger��5   	    � WindowStartupLocation$ CenterScreen=�6'   
������� � SizeToContent$ WidthAndHeight=�5	   	    � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value)  #System.Windows.Controls.DataGridRow�� 5   
   %�  '        '  J    �� 5      "  62   .�5      ��  � �� 6/   Z� �� 5       � �� 60   Z� �� 5       � ��
 �   �6/    5      P� 5       �@ 
IsSelected$
	 True��64   . �5      ��  � �� 67   Z� �� 5       � �� 68   Z� �� 5       � ��
 �   �67   5      5      �� 5      "  6   .�5      ��  � �� 6/   Z� �� 5       � �� 60   Z� �� 5       � ��
 �   �6/    5      P� 5        �@ 
IsSelected$
	 True��64   . �5!      ��  � �� 67   Z� �� 5"       � �� 68   Z� �� 5#       � ��
 �   �67   5$      5&      5'      .��5+      � 
 � ColumnDefinitions
 5,   
   �� 5-      $��40 �6   �� 5.      $
��auto �6   �� 5/      $
��auto �6   �� 50      $��* �6   �� 51      $��40 �6    � RowDefinitions 53   
   �� 54      $��20 �6   �� 55      $
��auto �6   �� 56      $
��auto �6   �� 57      $
��auto �6   �� 58      $��* �6   �� 59      $��20 �6   .+�5=   
   &   System.Windows.Controls.DataGrid  -   5          Name$ PasswordTable��5=         AlternatingRowBackground
 �����   CanUserAddRows$ False��6O      CanUserDeleteRows$ False��5>         CanUserReorderColumns$ False��6-   $��2��6L   $��1��6Y      Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ Service��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	account+6R     5E      $ Username/Email��6%   $
 auto 6Z    6=   �� *
username+6Z     5F      $ Password��6%   $
 auto 6Z    67   �� *censorPassword+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5H       5J      �� 5K       �� Orientation$ 
Horizontal=�6%   $��-2,0,0,0q�6>   $
��Left=�6P   .+�5L      �� -   5         ��Name$ 
NewAccount��5L   %   $��2.5, 0q�6R   $��44��6b   .��5M   "   �� $��Imgs/newAccountImage.png��6(   5N      �� 5O      -   5        $ SendAccount��5O   %   $��2.5, 0q�6T   $��44��6d   .��5P   "   �� $��Imgs/sendAccountImage.png��6(   5Q      �� 5R      -   5        $ ReceiveAccount��5R   %   $��2.5, 0q�6Z   $��44��6j   .��5S   "   �� $"��Imgs/recciveAccountImage.png��6(   5T      5U         CellTemplate 5X      �� 5Z      .R�5[      �� $ 
Horizontal=�6)   $
��2, 0q�6B   $
��Left=�6P   .+�5\   "   �� $ CopyPassword��6)   -   5        $��2.5, 0q�5\   Z   $��44��6j   .��5]   &   �� $ ��Imgs/copyPasswordImage.png��6,   5^   #   �� 5_   "   $ ModifyAccount��6)   -   5        $��2.5, 0q�5_   \   $��44��6l   .��5`   &   �� $!��Imgs/modifyAccountImage.png��6,   5a   #   �� 5b   "   $ DeleteAccount��6)   -   5        $��2.5, 0q�5b   \   $��44��6l   .��5c   &   �� $!��Imgs/deleteAccountImage.png��6,   5d   #   5e      5f      5h      5j      5k      5l      