   M S B A M L   `   `   `  ����N  JWindows Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Windows_ApplicationWindows_Application  5   	   $    Windows_Application.addAccount   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Windows_Application     5   	     � Title$  New account��5   	    � WindowStartupLocation$ CenterScreen=�6    � SizeToContent$ WidthAndHeight=�6B   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6!   $��
0,1.25,2,0q�61   $
��Left=�6E   $��Center=�6`   #!What service is this account for?5   +   �� 5   
   -   5         ��Name$ AccountTextbox��5      $��1��6*   $��2��67   $	��240��6G   $��5,3,0,0q�6S   $��Center=�6d   �� 5    
   $��2��6   $��1��6!   $��0,0,2,0q�61   $��Center=�6B   -+What is the username/email of this account?5!      �� 5"   
   -   5        $ UsernameTextbox��5"      $��2��6+   $��2��68   $	��240��6H   $��5,3,0,0q�6T   $��Center=�6e   �� 5$   
   $��3��6   $��1��6!   $��0,0,2,0q�61   $��Center=�6B   97Do you want to have the password be randomly generated?5%   "   �� 5&   
   -   5         ��Name$ RandomPasswordCheckbox��5&      $��3��63   $��2��6@   $��Stretch=�6P   $��5,3,0,0q�6n   $��Center=�5'   G    d� 	IsChecked$ FalseY�6b   �� 5)   
   $��4��6   $��1��6!   $��0,0,2,0q�61   $��Center=�6B   If no, then type it here.6x   G� 5*   
   -   5         G�Name$ PasswordTextbox��5*      $��4��6/   $��2��6<   $	��240��6L   $��5,3,0,0q�6X   ${�False��6i   � 5-   
   $��5��6   $��2��6!   $��5,8,0,0q�61   .+�5.      �� -   5        	 ��Name$	 Submit��5.      
 �� 	IsDefault$

 True��6%   $��Add Account��66   6L   �� 5/      -   5        $	 Cancel��5/       �� IsCancel$
 True��6%   $��Cancel��65   $��	130,0,0,0q�6F   50      51      52      