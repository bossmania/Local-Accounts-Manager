   M S B A M L   `   `   `  ����N  JWindows Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Windows_ApplicationWindows_Application  5   	        Windows_Application.server   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Windows_Application     5   	     � Title$  Receive Accounts��5   	    � WindowStartupLocation$ CenterScreen=�6"    � SizeToContent$ WidthAndHeight=�6G   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6!   $��0,2,0,0q�61   DBThis device is currently waiting for the accounts to be sent here.5   ,   �� 5   
   $��2��6   $��1��6!   $��0,2,0,0q�61   YWTo send it, go to the other device, click on send account, and put the following IP in.5    B   �� 5!   
   -   5         ��Name$ IpTextblock��5!      $��3��6)   $��1��66   $��Center=�6F   $��0,3,0,0q�6c   The IP is 127.0.0.15"      �� 5%   
   -   5        $ status��5%      $��5��6$   $��1��61   $��Center=�6A   #!Status: Waiting for a connection.5&   (   5'      5(      