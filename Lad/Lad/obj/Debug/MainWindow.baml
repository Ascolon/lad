   M S B A M L   `   `   `  ����>  :Lad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LadLad  5   	       Lad.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Lad     5   	     � Title$  Лад��5   	   $	��600��5	   	   $	��700��6   $
��1100��5
   	   $
��1300��6   
������� � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       �� 
TargetType 
  Circle��%�   &	        �� 5   
   " ��6   .R�5      � .+�5      �� #��z��6#   $��Center=�5      $��Center=�5      5      5      5      .��5      � -   5        $��Parent��5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� -   5        $��
LoignPanel��5   &   $	��200��5      $	��300��6   $��1q�6+   $y�	Collapsed=�6@   ���#474747 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 0Q�6#      
BlurRadius$	 400Q�63   6F   ._�5       �� $��Center=�6   .+�5!      �� 
����ح�$��2q�62    �� TextAlignment$ Center=�6F   $��20(�5"      
������ $��10q�5#      $��40��6&   64   G� 5$      
����ح�$��2q�66   $��Center=�6J   $��20(�5%      
������ $��10q�5&      $��40��6&   64   �� 5'      $��10q�6   $��
Войти��6%   $��40��65   6D   5(      5)      � 5+   
   -   5        $
��Menu��5,   $   ���#009688��5+      �� 	 �� ElementName$	 MenuIcon��
 �� Path$
 Width� � RowDefinitions 5-      �� 5.      $��6* �6    �� 5/      $	��94* �6    .+�51      �� $��0q�6   ���#171717._�53      �� -   5        $��MenuIcon��53      $��40��6(   $��30��63   $
��Fill=�54      $��Content/Image/menu.png��55      $��0q�56      $��Right=�57       � Cursor$
 Hand��58   3   6D   59      � 5:      -   5        $��GridMenu��5:   *   $y�	Collapsed=�6   $��1��6:    5;      �� 5<      $	��10* �6$   �� 5=      $��5* �6$   �� 5>      $��5* �6$   �� 5?      $	��80* �6$   .+�5A      �� -   5        $��QuerySection��5A      $��0��6.   
������ $��2q�5B   /   
���P��$��16(�5D      $��Center=�5F      $ Center=�5G      $��20,15,20,15q�5H      6-   �� 5I      -   5        #��[  5I      $��25��6<   $��1��6H   $	��Top=�5J      $
 Hand��61   ��5K      �� 5L      $��Отчеты��6$   $��16(�62   $��Medium"�6@    �� TextAlignment$ Center=�5M   $   $��Center=�6;   6X   5O      �� 5P      -   5        #��[  5P      $��25��6<   $��2��6H   $	��Top=�5Q      $
 Hand��61   ��5R      �� 5S      $#��Добавить секцию��6$   $��16(�6;   $��Medium"�6I   $ Center=�5T   $   $��Center=�6;   6X   5V      �� 5W      -	   5        $��Sections��5\      
������ $��Stretch=�5W   3   $��Disabled=�5X      $��0,30,0,0q�5Y      $��Hidden=�5Z      
���P��$��0,0,0,0q�5[   &   $��3��6@   ��5]      �� 5^      .R�5_      �� $
 Hand��6)   .+�5`   "   �� $��0q�6(   $��Stretch=�5a   $   $��Stretch=�5b   $   ��5c   &   � 5d   *   .+�5e   .   �� -
   5        $��16(�5f   -   $��Medium"�6;   
 � Tag 5e   ^   �� *	SectionId+��5f   O   �� *Name+6g   �� 5g   .   -   5        $��22��5h   0   $��22��5i   0   $��0,0,30,0q�6;   $��Content/Image/delete.png��5k   0   $��Right=�5l   0    5g   4   �� *	SectionId+5m   /   �� 5n   .   -   5        $��20��5o   0   $��20��5p   0   $��Content/Image/edit.png��5r   0   $��Right=�5s   0    5n   4   �� *	SectionId+5t   /   5u   +   5w   #   5x      5y      5{      5|      5}       � 5~   
   -   5        $
��Body��5~       $��1��6   
������   � Source$  Content/Views/Startup.xaml?�5�        � NavigationUIVisibility$ Hidden=�5�      $��0q�5�      6   5�      5�      