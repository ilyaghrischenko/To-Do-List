   M S B A M L   `   `   `  ����I  EApplicationWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ApplicationWPF.WindowsApplicationWPF.Windows  5   	   +    %ApplicationWPF.Windows.TaskListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ApplicationWPF.Windows     5   	     � Title$  Tasks��5   	   $	��400��6   $	��500��6$   $	��400��5	   	   $	��400��6   $	��500��5
   	   $	��500��6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $	��18* �6   �� 5       � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $	��10* �6   �� 5      $
��0.2* �6   �� 5      �� 5      $
��0.2* �6   .+�5   
   � $��1��6   $��1��5      .+�5      �  5      �� 5      �� 5      $
��0.3* �6$   �� 5       $��4* �6$   �� 5!      $
��0.4* �6$   .+�5$      �  5%      �� 5&      �� 5'      �� 5(      �� 5)      �� 5*      �� 5+      �� 5,      .+�5/      �� -   5         ��Name$ CompletedButton��51      $��1��5/      $��	Completed��50      $��Times New Roman)�53      
����  �$
��Bold"�55      �� 56      -   5        $ 	AllButton��58      $��3��56      $	��All��57      $��Times New Roman)�5:      
����  �$
��Bold"�5<      ${�False��5=      �� 5>      -   5        $ ActiveButton��5@      $��5��5>      $��Active��5?      $��Times New Roman)�5B      
����  �$
��Bold"�5D      5E      &   System.Windows.Controls.DataGrid  5G      -   5          Name$ 	TasksList��5H      $��2��5G         AutoGenerateColumns$
 True��5I         
IsReadOnly$
 True��5K      5L      �� 5N      -   5         ��Name$ CompleteCheckBox��5Q      $��3��5N      $��Center=�5O      $��Center=�5P      ${�False��5S      5T      5U      � 5W   
   $��1��6   $��3��5X       5Y      �� 5Z      �� 5[      $
��0.6* �6#   �� 5\      .+�5_      �� -   5        $ 	AddButton��5a      $��1��5_      $��Add task��5`      $��Times New Roman)�5c      $
��Bold"�5d      
����  �5e      5f      5g      5h      