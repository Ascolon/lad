   M S B A M L   `   `   `  ����>  :Lad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Lad.MessageBoxWindowLad.MessageBoxWindow  5   	   -    'Lad.MessageBoxWindow.EditLearningDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Lad.MessageBoxWindow     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStyle$
 None=�6    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ EditSectionDialog��5	   	   $	��250��6#   $	��400��60   ���#3F3F46 � 	Resources 5
       �� 
TargetType 
  Circle��%�   &	        �� 5   
   " ��6   .R�5      � .+�5      �� #��z��6#   $��Center=�5      $��Center=�5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��70* �6   .+�5   
   �� $��35��6   $��0��5      $��Имя��6"   $��18(�5       $��1��6    $��Center=�5!      $��	22,7,22,7q�5"      
������ 6@   �� 5#   
   $��35��6   $��0��5$      $��Фамилия��6"   $��18(�5%      $��2��6    $��Center=�5&      $��	22,7,22,7q�5'      
������ 6@   �� 5(   
   $	��0,0q�6   $��Center=�6!    �� TextAlignment$ Center=�5)      $��2��6+   $��20(�5*      $5��/Редактирование учащегося��5+      66   �� 5,   
   -   5        $��NewName��5-      $��35��5,      $��1��5-   !   $��18(�5.      $��1��5/      $��Center=�50      $��	22,7,22,7q�51      
������ 
����ح�$��2q�54      6(   �� 55   
   -   5        $��	NewFamily��56      $��35��55      $��1��56   #   $��18(�57      $��2��58      $��Center=�59      $��	22,7,22,7q�5:      
������ 
����ح�$��2q�5=      6(   �� 5>   
   $��3��6   	 �� Orientation$	 
Horizontal=�6"   $��Center=�6;   $��2��6X   .+�5?      �� -   5        $��16(�5?      $��Medium"�68   #��[  6L   $��30��6o   $��0,0,10,0q�6{   $	��120��6�   .��6�   Сохранить6�   �� 5@      -   5        $��16(�5@      $��Medium"�60   #��[  6D   $��30��6g   $	��120��6s   .��6   Отмена6�   5A      5B      5C      