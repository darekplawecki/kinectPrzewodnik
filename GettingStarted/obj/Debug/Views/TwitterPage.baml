   M S B A M L   `   `   `  ����E  APrzewodnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Przewodnik.ConvertersPrzewodnik.Converters  5      "    Przewodnik.Views.TwitterPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5      6
converters#clr-namespace:Przewodnik.Converters   5      c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5      -   5        $��TwitterGrid��5        � RowDefinitions  5	      �� 5
   
   $��0.22* �6   6)   �� 5   
   $��0.68* �6   6)   �� 5   
   $
��0.1* �6   6(    � ColumnDefinitions 5      �� 5   
   $
��0.1* �6   6*   �� 5   
   $
��0.8* �6   6*   �� 5   
   $
��0.1* �6   6*   .+�5      �� -   5         ��Name$ firstTextBlock��5   A   $��0��6   $��0��6   $��3��6-      	PageTitle#���   6Y    
 Size72#���  6}   z ostatniej chwili...6�   �� 5      $��1��6   $��1��6   .+�5   
   �� -   5        $��ErrorContent��5      $�� ��6(    
 Size36#���  60   6V   �� 5   
   -   5        $��TwitterContent��5      $�� ��6*   64   5      :  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  5      -   5        $��ScrollViewer��5   8   $��1��6   $��1��6(   $��Disabled=�6L   $
��Auto=�6u      ContentMargin$ 0Q�6�   
������    HoverBackground
 ���� .��5   
   �� $��0,0,0,0q�6    �� Orientation$ Vertical=�6&   $
��Auto��6=   .+�5       �� -   5         ��Name$ MainList��5       $��Stretch=�6(   $	��Top=�6F   
������ $��Stretch=�6w   $��0q�6�    � 	Resources 5!      -   'Przewodnik.Converters.DateTimeConverter  dateConverter��%   &	         5"      63   5#      ��5$      �� 5%      .R�5&      �� .+�5(      �   TextBottomMargin#���  6#   ��5)   "   �� 5*   &    �� 
TargetType" �6,   	 �� Triggers	 5+   *   �� 5,   .   
 �� Binding
 6:   �� *	Direction+ �� Value 06X   .a�5-   2   ��  �� Property � y� �� Value$ Visible=�6O   5.   /   �� 5/   .   
 6:   �� *	Direction+ 16X   .a�50   2   ��  � y�$ 	Collapsed=�6O   51   /   53   '    55   "   �� 56   &   $
��Auto �67   6F   �� 57   &   $��15 �67   6D   �� 58   &     
TweetWidth#���  67   6^     5:   "   �� 5;   &     TweetHeight#���  64   6]   .+�5>   "   �� $��0��6(   $��0��65   ��6E   �� *Image+6`   � 5?   "   $��0��6*   $��2��67    � Points �   ��� �����  Q%$��0,20,0,0q�6a   ��6s   �� *	Colors[0]+��6�   �� *	Colors[0]+�� 5A   "   $��0��6-   $��2��6:   $ Vertical=�6J   $��14,0,0,0q�6a   ��6s   �� *	Colors[0]+.+�5B   &   �� $ Vertical=�61     BlockTwitterMargin#���  6H   .+�5C   *   ��   TextBlockStyle#���  6�   #���  6�    
	 Size28#��� 	 6   �� 
LineHeight# � 	 6&  $
��Bold"�6L  ��64   �� *Author+ �� StringFormat$
 @{0}�� �� FallbackValue$ @WrocławPrzewodnik�� �� TargetNullValue$ @WrocławPrzewodnik��6`  �� 5D   *   	 �� X1$ 0��6/   	 �� Y1$ 0��66   	 �� X2$ 1��6=   	 �� Y2$ 0��6D    �� Stretch$
 Fill=�6K   $��1��6w   ��6Z   �� *	Colors[1]+6w   �� 5E   *    

 Size60#��� 
 6M   #���  6r     TextTopMargin#���  6�   #��� 	 6�   # � 	 6�   ��64   �� *	Content+6  �� 5F   *   #���  6u   #��� 	 6�   # � 	 6�   $��Right=�6�   ��64   �� *Date+ �� 	Converter# [ ��6  �� *	Colors[1]+6'  5G   '   5H   #   5I      � 5L      #���  6#   $��Right=�6O   ��5M   "   �� 5N   &   " �6,   	 5O   *   �� 5P   .   
 6:   �� *	Direction+ 16X   .a�5Q   2   ��  � y�$ Visible=�6O   5R   /   �� 5S   .   
 6:   �� *	Direction+ 06X   .a�5T   2   ��  � y�$ 	Collapsed=�6O   5U   /   5W   '    5Y   "   �� 5Z   &   #���  67   6^   �� 5[   &   $��15 �67   6D   �� 5\   &   $
��Auto �67   6F     5^   "   �� 5_   &   #���  64   6]   .+�5b   "   �� $��0��6-   $��0��6:   $ Vertical=�6J   $��0,0,15,0q�6a   ��6s   �� *	Colors[0]+.+�5c   &   �� $ Vertical=�61   #���  6H   .+�5d   *   �� #���  6�   #���  6�   #��� 	 6�   # � 	 6  $
��Bold"�67  ��64   �� *Author+$
 @{0}��$ @unknown��$ @uknown��6K  �� 5e   *   $ 0��6/   $ 0��66   $ 1��6=   $ 0��6D   $
 Fill=�6K   $��1��6w   ��6Z   �� *	Colors[1]+6w   �� 5f   *   #��� 
 6M   #���  6r   #���  6�   #��� 	 6�   # � 	 6�   ��64   �� *	Content+6  �� 5g   *   #���  6u   #��� 	 6�   # � 	 6�   $��Right=�6�   ��64   �� *Date+# [ ��6  �� *	Colors[1]+6'  5h   '   5i   #   � 5j   "   $��0��6*   $��0��67    �   ��� �� Q%$��0,20,0,0q�6`   $��Right=�6�   ��6r   �� *	Colors[0]+��6�   �� *	Colors[0]+6�   �� 5l   "   $��0��6(   $��2��65   ��6E   �� *Image+6`   5m      5n      5o      5q      5s      5t      5u      