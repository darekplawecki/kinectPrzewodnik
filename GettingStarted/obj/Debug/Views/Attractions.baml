   M S B A M L   `   `   `  ����  
Przewodnik     GettingStarted.Attractions   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5      -   5        $��AttractionsGrid��5        � RowDefinitions  5      �� 5   
   $��0.25* �6   6)   �� 5	   
   $��0.55* �6   6)   �� 5
   
   $��0.20* �6   6)    � ColumnDefinitions 5      �� 5   
   $��0.08* �6   6+   �� 5   
   $��0.84* �6   6+   �� 5   
   $��0.08* �6   6+   .+�5      �� -   5         ��Name$ firstTextBlock��5   A   $��0��6   $��0��6   $��3��6-      	PageTitle#���   6Y    
 Size72#���  6}   atrakcje turystyczne6�   :  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  5      -   5        $��AttractionsScrollViewer��5   8   $��1��6   $��1��6(   $
��Auto=�6W   $��Disabled=�6|      ContentMargin$ 0Q�6�   
������    HoverBackground
 ���� .��5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   5        $��Rynek��5   �   $
��Auto��6!     AttractionBlockSize#���  6/   $	��Top=�6]     	BlueColor#��[ 6|   $��0q�6�   .��5      �   5      �� 5      $
��Auto �6(   68   �� 5      $��* �6(   65   .+�5       �� -   5        $��
RynekImage��5       $��0��6.   $4��.../Content/Attractions/Photos/rynek1_hover.jpg��6;   6u   �� 5!      $ Vertical=�6!     BlockMargin#���  68   $��1��6_   .+�5"      �� $,��&../Content/Attractions/Icons/rynek.png��6    $
��Left=�6P     Icon#���  6k   6�   �� 5#      -   5        $��
RynekBlock��5#   $   $��rynek��66     TextTopMargin#���  6C     TextBlockStyle#���  6l    
 Size55#���  6�    
	 Size50 �� 
LineHeight# � 	 6�   6�   5$      5%      5&        5(      -   5        $��OstrówTumski��5(   �   $
��Auto��6!   #���  6/   $	��Top=�6]    
 
GreenColor#��[
 6|   $��0q�6�   .��5)      �   5*      �� 5+      $
��Auto �6(   68   �� 5,      $��* �6(   65   .+�5.      �� -   5        $��OstrówTumskiImage��5.      $��0��65   $;��5../Content/Attractions/Photos/ostrowtumski1_hover.jpg��6B   6�   �� 5/      $ Vertical=�6!   #���  68   $��1��6_   .+�50      �� $3��-../Content/Attractions/Icons/ostrowtumski.png��6    $
��Left=�6W   #���  6r   6�   �� 51      $��ostrów tumski��6$   #���  69   #���  6b   #���  6�   # � 	 6�   6�   52      53      54        56      -	   5        $��HalaStulecia��56   �   $
��Auto��6!   #���  6/   $	��Top=�6]     PurpleColor#��[ 6|   .��57      �   58      �� 59      $
��Auto �6(   68   �� 5:      $��* �6(   65   .+�5<      �� -
   5        $��HalaStuleciaImage��5<      $��0��65   $;��5../Content/Attractions/Photos/halastulecia1_hover.jpg��6B   6�   �� 5=      $ Vertical=�6!   #���  68   $��1��6_   .+�5>      �� $3��-../Content/Attractions/Icons/halastulecia.png��6    $
��Left=�6W   #���  6r   6�   �� 5?      -   5        $��	HalaBlock��5?   $   $��hala stulecia��65   #���  6J   #���  6s   #���  6�   # � 	 6�   6�   5@      5A      5B        5D      -   5        $��PałacKrólewski��5D   �   $
��Auto��6!   #���  6/   $	��Top=�6]     YellowColor#��[ 6|   .��5E      �   5F      �� 5G      $
��Auto �6(   68   �� 5H      $��* �6(   65   .+�5J      �� -   5        $��PałacKrólewskiImage��5J      $��0��67   $=��7../Content/Attractions/Photos/palackrolewski1_hover.jpg��6D   6�   �� 5K      $ Vertical=�6!   #���  68   $��1��6_   .+�5L      �� $5��/../Content/Attractions/Icons/palackrolewski.png��6    $
��Left=�6Y   #���  6t   6�   �� 5M      -   5        $��
PalacBlock��5M   $   $��pałac królewski��66   #���  6M   #���  6v   #���  6�   # � 	 6�   6�   5N      5O      5P        5R      -   5        $��PanoramaRacławicka��5R   �   $
��Auto��6!   #���  6/   $	��Top=�6]     	LimeColor#��[ 6|   .��5S      �   5T      �� 5U      $
��Auto �6(   68   �� 5V      $��* �6(   65   .+�5X      �� -   5        $��PanoramaRacławickaImage��5X      $��0��6;   $A��;../Content/Attractions/Photos/panoramaraclawicka1_hover.jpg��6H   6�   �� 5Y      $ Vertical=�6!   #���  68   $��1��6_   .+�5Z      �� $9��3../Content/Attractions/Icons/panoramaraclawicka.png��6    $
��Left=�6]   #���  6x   6�   �� 5[      $��panorama racławicka��6$   #���  6?   #���  6h   #���  6�   # � 	 6�   6�   5\      5]      5^        5`      -   5        $��OgródJapoński��5`   �   $
��Auto��6!   #���  6/   $	��Top=�6]     OrangeColor#��[ 6|   .��5a      �   5b      �� 5c      $
��Auto �6(   68   �� 5d      $��* �6(   65   .+�5f      �� -   5        $��OgródJapońskiImage��5f      $��0��66   $<��6../Content/Attractions/Photos/ogrodjaponski1_hover.jpg��6C   6�   �� 5g      $ Vertical=�6!   #���  68   $��1��6_   .+�5h      �� $4��.../Content/Attractions/Icons/ogrodjaponski.png��6    $
��Left=�6X   #���  6s   6�   �� 5i      -   5        $��OgrodJBlock��5i   $   $��ogród japoński��67   #���  6M   #���  6v   #���  6�   # � 	 6�   6�   5j      5k      5l        5n      -   5        $��FontannaMultimedialna��5n   �   $
��Auto��6!   #���  6/   $	��Top=�6]     RedColor#��[ 6|   .��5o      �   5p      �� 5q      $
��Auto �6(   68   �� 5r      $��* �6(   65   .+�5t      �� -   5        $ ��FontannaMultimedialnaImage��5t      $��0��6>   $7��1../Content/Attractions/Photos/fontanna1_hover.jpg��6K   6�   �� 5u      $ Vertical=�6!   #���  68   $��1��6_   .+�5v      �� $/��)../Content/Attractions/Icons/fontanna.png��6    $
��Left=�6S   #���  6n   6�   �� 5w      -   5        $��FontannaBlock��5w   $   $��fontanna multimedialna��69   #���  6W   #���  6�   #��� 	 6�   # � 	 6�   6�   5x      5y      5z        5|      -   5        $��WyspaSłodowa��5|   �   $
��Auto��6!   #���  6/   $	��Top=�6]   #��[ 6|   .��5}      �   5~      �� 5      $
��Auto �6(   68   �� 5�      $��* �6(   65   .+�5�      �� -   5        $��WyspaSłodowaImage��5�      $��0��65   $;��5../Content/Attractions/Photos/wyspaslodowa1_hover.jpg��6B   6�   �� 5�      $ Vertical=�6!   #���  68   $��1��6_   .+�5�      �� $3��-../Content/Attractions/Icons/wyspaslodowa.png��6    $
��Left=�6W   #���  6r   6�   �� 5�      -   5        $��
WyspaBlock��5�   $   $��wyspa słodowa��66   #���  6K   #���  6t   #���  6�   # � 	 6�   6�   5�      5�      5�        5�      -   5        $	��ZOO��5�   �   $
��Auto��6!   #���  6/   $	��Top=�6]   #��[
 6|   .��5�      �   5�      �� 5�      $
��Auto �6(   68   �� 5�      $��* �6(   65   .+�5�      �� -   5        $��ZOOImage��5�      $��0��6,   $2��,../Content/Attractions/Photos/zoo1_hover.jpg��69   6q   �� 5�      $ Vertical=�6!   #���  68   $��1��6_   .+�5�      �� $*��$../Content/Attractions/Icons/zoo.png��6    $
��Left=�6N   #���  6i   6�   �� 5�      $	��zoo��6$   #���  6/   #���  6X   #���  6�   # � 	 6�   6�   5�      5�      5�        5�      -   5        $��OgródBotaniczny��5�   �   $
��Auto��6!   #���  6/   $	��Top=�6]   #��[ 6|   .��5�      �   5�      �� 5�      $
��Auto �6(   68   �� 5�      $��* �6(   65   .+�5�      �� -   5        $��OgródBotanicznyImage��5�      $��0��68   $>��8../Content/Attractions/Photos/ogrodbotaniczny1_hover.jpg��6E   6�   �� 5�      $ Vertical=�6!   #���  68   $��1��6_   .+�5�      �� $6��0../Content/Attractions/Icons/ogrodbotaniczny.png��6    $
��Left=�6Z   #���  6u   6�   �� 5�      -   5        $��OgrodBBlock��5�   $   $��ogród botaniczny��67   #���  6O   #���  6x   #���  6�   # � 	 6�   6�   5�      5�      5�      5�      5�      5�      