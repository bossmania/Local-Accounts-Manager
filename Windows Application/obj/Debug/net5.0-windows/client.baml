   M S B A M L   `   `   `  ����N  JWindows Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Windows_ApplicationWindows_Application  5   	        Windows_Application.client   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Windows_Application     5   	     � Title$  Send Accounts��5   
    � WindowStartupLocation$ CenterScreen=�6     � SizeToContent$ WidthAndHeight=�6E   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6!   64What is the IP that you are sending the accounts to?6g   �� 5   
   $��0,4,3,0q�6   $��2��6%   $��1��62   IP:6G   �� 5    
   -   5         ��Name$ IPBox��5       $��Stretch=�6!   $��2��6?   $��1��6L   $��20,4,0,0q�6\   .��6n   	127.0.0.15!      �� 5"   
   -   5         ��Name$ status��5"      $��3��6$   $��1��61   $��Center=�6A   $��0,2,0,0q�6^   Status: Waiting for the IP.5#   *   �� 5&   
   $��4��6   $��1��6"   $��Right=�62    �� Orientation$ 
Horizontal=�6N   $��0,4,0,0q�6g   .+�5'      �� -   5         ��Name$ Submit��5'      	 �� 	IsDefault$
	 True��6%   .��6K   Submit6S   �� 5(      -   5        $ Cancel��5(      
 �� IsCancel$

 True��6%   $��4,0,0,0q�65   .��6F   Cancel6N   5)      5*      5+      