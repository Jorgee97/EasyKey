   M S B A M L   `   `   `  ����F  BEasyKey.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EasyKey.AppEasyKey.App  5          EasyKey.App.GridPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:EasyKey.App     5      -   5          N� Title$  GridPage��5	      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ AccountHolder��5         AutoGenerateColumns .  $��1��6F   $��16q�6V   $��6��6b   $��	Quicksand)�6s      SelectionMode$ Single=�6�      CanUserDeleteRows .     
IsReadOnly .  � ContextMenu 5      �� 5      .@�5      m� -   5         m�Name$ 
OptionEdit��5      $
��Edit��63   6A   m� 5      -   5        $ OptionDelete��5      $��Delete��65   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      	   
FontFamily$	 	Quicksand)�6k   ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ 	AccountID�   ClipboardContentBinding 6H   Z� 6�     5      $	 	Quicksand)�6f   $

 Name��6}    6%   �� $
 Name� 6C   Z� 6}     5      $	 	Quicksand)�6j   $
 Username��6�    6%   �� $ Username� 6G   Z� 6�     5      $	 	Quicksand)�6g   $
 Email��6~    6%   �� $ Email� 6D   Z� 6~     5      $	 	Quicksand)�6j   $
 Password��6�    6%   �� $ Password� 6G   Z� 6�   5      5      5      