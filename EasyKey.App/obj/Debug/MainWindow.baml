   M S B A M L   `   `   `  ����F  BEasyKey.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EasyKey.AppEasyKey.App  5   	       EasyKey.App.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:EasyKey.App     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)   .��5	      � ���	#FF4A4A4A � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��4* �6   .+�5   
   (� $��0��6   $��0��6   .��5      �� $��EasyKey��6   $
��16,0q�6&   $��Rockwell Extra Bold)�64   $��40(�6U   
������ ���	#FF4DF9D3$��Center=�6�   $��Center=�6�   5      �� 5   
   -   5         ��Name$ btnCreatePassword��5   .   $��1��6   $��0��6   $��Create New Password��6I   $��16q�6g   $��	Quicksand)�6s   $��14(�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5      �  � Color$ 	#FF4AFACE��6#   � 5      $ 	#FF58F2EB��6#    � Offset$
 0.86Q�65   � 5      $ 	#FF57EFE1��6#   $
 0.56Q�65   5       5"      �� 5#   
   -   5        $ btnImportPassword��5#   .   $��2��6   $��0��6   $��Import Passwords��6I   $��16q�6d   $��	Quicksand)�6p   $��14(�6�   ��5$      �� 5%      $ 0.5,1&�6&   $ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5&      � $ 	#FF4AFACE��6#   � 5'      $ 	#FF58F2EB��6#   $
 0.86Q�65   � 5(      $ 	#FF57EFE1��6#   $
 0.56Q�65   5)      5+      �� 5,   
   -   5        $ btnExportPassword��5,   .   $��3��6   $��0��6   $��Export Passwords��6I   $��16q�6d   $��	Quicksand)�6p   $��14(�6�   ��5-      �� 5.      $ 0.5,1&�6&   $ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5/      � $ 	#FF4AFACE��6#   � 50      $ 	#FF58F2EB��6#   $
 0.86Q�65   � 51      $ 	#FF57EFE1��6#   $
 0.56Q�65   52      54      �� 55   
   -   5        $ btnSettings��55   .   $��5��6   $��0��6   $��Settings��6C   $��16q�6V   $��	Quicksand)�6b   $��14(�6y   ��56      �� 57      $ 0.5,1&�6&   $ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��58      � $ 	#FF4AFACE��6#   � 59      $ 	#FF58F2EB��6#   $
 0.86Q�65   � 5:      $ 	#FF57EFE1��6#   $
 0.56Q�65   5;      5=       � 5>   
   -   5        	  �Name$	 Content��5>      $��1��6!   $��6��61   
  � NavigationUIVisibility$
 Hidden=�6B   $��	Quicksand)�6b   $��14(�6y   
����+��6�   5@      5A      