   M S B A M L   `   `   `  ����  
Przewodnik(    "Przewodnik.Views.AttractionArticle   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5      -   5          �Name$  AttractionArticleGrid��5   	    � RowDefinitions 5      �� 5	   
   $��0.22* �6   6)   �� 5
   
   $
��0.7* �6   6(   �� 5   
   $��0.08* �6   6)    � ColumnDefinitions 5      �� 5   
   $��0.07* �6   6+   �� 5   
   $��0.86* �6   6+   �� 5   
   $��0.07* �6   6+   .+�5      �� $��0��6   $��0��6   $��3��6-      	PageTitle#���   6A    
 Size72#���  6e   ��6�   �� *Title+ �� Mode$ OneWay=�� 5      $��1��6   $��1��6   }�.  5   
   �� 5      $��3* �6   �� 5      $��* �6    5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��3* �6   .+�5"   
   � -   5        $��bigImageGrid��5"      $��3��6#   $��0��67   6F   8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  5$   
   -   5        $��FirstImageButton��5$   �   
������ $��0��66   $��1��6F   $
��Auto��6S   $
��Auto��6`   $	��Top=�6n   $��0q�6�   .��5%      �� .+�5&      �� -   5        $��firstImageSource��5&      $��UniformToFill=�60   5'      5(        5*   
   -   5        $��SecondImageButton��5*   �   
������ $
��Auto��67   $
��Auto��6D   $	��Top=�6R   $��1��6r   $��1��6�   $��0q�6�   .��5+      �� .+�5,      �� -   5        $��secondImageSource��5,      $
��Fill=�61   5-      5.        50   
   -   5        $��ThirdImageButton��50   �   
������ $
��Auto��66   $
��Auto��6C   $	��Top=�6Q   $��2��6q   $��1��6�   $��0q�6�   .��51      �� .+�52      � .+�53      �� -   5        $��thirdImageSource��53      � 54      ���#5A5B5B J� Opacity$	 0.6Q�60   ��55      �� 56       �� 
TargetType" �6$    �� Triggers 57   "   �� 58   &    �� Binding 62   �� *Camera+ �� Value 6M   Z� .a�59   *   �� 	 �� Property	 � y�
 �� Value$
 	Collapsed=�6G   5:   '   5<      .+�5>      �� $!��../Content/play-overlay.png��6    $��Center=�6E   $��Center=�6b   $��80��6~   $��80��6�   $��0, -20, 0, 0q�6�   5?      5@      5A      5B      :  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  5D   
   $��3��6   $��2��6/   $
��Auto=�6@   $	��Top=�6c      HoverBackground
 ���� .��5E      �� -	   5        $��descriptionTextBlock��5E   1   $��30,-100,10,-100q�6     TextBlockStyle#���  6M    
 Size50#���  6v    
 Size60 �� 
LineHeight# �  6�     	GrayColor#��[ 6�   $	��Top=�6  ��6�   �� *Description+$ OneWay=�6-  5F      5H      5J      