   M S B A M L   `   `   `  ����E  APrzewodnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Przewodnik.ControlsPrzewodnik.Controls  5   	   =#clr-namespace:Przewodnik.ConvertersPrzewodnik.Converters  5   	   ;"clr-namespace:Przewodnik.UtilitiesPrzewodnik.Utilities  5   	   _ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35eHclr-namespace:Microsoft.Kinect.Toolkit;assembly=Microsoft.Kinect.ToolkitMicrosoft.Kinect.Toolkit 5   	       Przewodnik.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5   	   +c!clr-namespace:Przewodnik.Controls   5   	   .cv#clr-namespace:Przewodnik.Converters   5   	   ,u"clr-namespace:Przewodnik.Utilities   5   	   StkHclr-namespace:Microsoft.Kinect.Toolkit;assembly=Microsoft.Kinect.Toolkit   5   	     � Title$  Przewodnik turystyczny��5	   	    � WindowState$ 	Maximized=�5
   	   $
��1920��5   	   $
��1080��5   	    � WindowStyle$
 None=�5   	    � Cursor$
 None��5   	    � 	Resources 5         EngagedUserColor �� A �� R �� G �� B  TrackedUserColor  EngagedUserMessageBrush	 �� Color  TrackedUserMessageBrush % !PostEngagementBackgroundUserColor % !PostEngagementBackgroundUserBrush  HandoffTextTemplate  HandoffButtonContent��%M  &	        &	 J     &	 �     &	 �     &	 �     &	 $    7  &	 <    &	 �   �� 5   
   $	 #80��6)   $	 #51��61   $	 #1C��69   $	 #74��6A   �� 5   
   $	 #80��6)   $	 #00��61   $	 #BC��69   $	 #F2��6A   �� 5   
   $	 	#FF511C74��6:   �� 5   
   $	 	#FF00BCF2��6:   �� 5   
   $	 #80��6:   $	 #BC��6B   $	 #BE��6J   $	 #C0��6R   �� 5   
   8	   6D   �� 5   
   .R�5      �� $
��Wrap=�6)   $��30(�6=   
�������$��25 10q�6^   $��Center=�6m   $
��Left=�6�   ��6   �� 6�   5      � 5   
   
������ $��Center=�6V   $��Center=�6s   .+�5      �� .+�5      �� $��Center=�6   
�������$��36(�6L   $��0q�6Z   $��
Press Here��6e   �� 5      $��Center=�6   
�������$��24(�6L   $��0 5 0 0q�6Z   $��To take control��6k   5      5      5       .��5!      � -   5        $��
TopTopGrid��5!      .+�5"   
   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion  -   5        $��kinectRegion��5#      
   KinectSensor
 5$      �� *KinectSensorChooser.Kinect+   IsCursorVisible 5%      �� *IsUserActive+)   "QueryPrimaryUserTrackingIdCallback 5&      �� *QueryPrimaryUserCallback+.��5'      � .+�5)      �  � RowDefinitions 5*      �� 5+      -   5         �Name$ TopRow��5+   3   $��* �6(   63   �� 5,      -   5        $ 
ContentRow��5,   3   $��* �6(   63   .+�5/      �  
 TopRow#��[ 6   $��0��6;   .+�50      :  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  -   5        $��
BackButton��50   /   $��0��6A   $
��Left=�6Q   $	��Top=�6l   
������ 
������ $��0q�6�   .��51      �� $,��&/Content/Design/Images/back-button.png��6$   6V   52      � 54      -   5        $��Weather��54      }�.  	 WeatherAreaWidth#��� 	 6B    
 WeatherAreaHeight#��� 
 6m     LightGrayColor#��[ 6�   $
��Left=�6�   $��Center=�6�   $��60,0,0,0q�6�   .+�56      � -   5        $��	container��56   #   #��� 	 64   #��� 
 6_   z�57   "   T� 58   &    T� Y 69   ��  �� ElementName$ 	container�� �� Path$ ActualHeight�-   'Przewodnik.Converters.NegativeConverter   Instance �� 	Converter# Z ��5:   "   �� 5;   &    �� 
TargetType" �6,    �� Triggers 5<   *   �� 5=   .    �� Binding 6:   �� *WeatherState+ �� Value 06[    N� EnterActions 5>   2   �� 5?   6     SlideTranslateY#��[ 6F   5A   /   �� 5B   .    6:   �� *WeatherState+ 16[    5C   2   �� 5D   6   #��[ 6F   5F   /   5H   '   .+�5K   "   �   BlockWeatherMargin#���  6'    � ColumnDefinitions 5L   &   �� 5M   *   $��* �6;   6G   �� 5N   *   $��* �6;   6G   .+�5Q   &   �� -   5        $��WeatherImage��5Q   ,   $��0��5R   ,     WeatherIcon#���  5S   ,   $��Center=�5T   ,   $��Center=�5U   ,   5V   '   �� 5W   &   -	   5        $��WeatherDegree��5W   0   $��1��5X   0    �� LineStackingStrategy$ BlockLineHeight=�5Y   0    
 Size90#���  5Z   0    �� 
LineHeight# �  5[   0   $��Light"�5\   0     
GrayColor2#��[ 5]   0   $��Center=�5^   0   $��Center=�5_   0   5`   '   ��5a   &   �� 5b   *   " �60    5c   .   �� 5d   2    6>   �� *WeatherState+ 06_   .a�5e   6   ��  �� Property � z� �� Value 5f   :   T� 5g   >    6Q   �� $ 	container��$ ActualHeight�5i   7   5j   3   5l   +   5n   #   � 5p   "   #���  6'   .+�5q   &   �� $��Center=�61   .+�5r   *   �� -
   5        $��	DayOfWeek��5r   4     TextBlockStyle#��[ 5s   5    
 Size36#���  5t   5    
 Size40# �  5u   5   #��[ 5v   5   $
��Left=�5w   5   5x   +   �� 5y   *   -   5        $��Today��5y   4   #��[ 5z   5   #���  5{   5   # �  5|   5   #��[ 5}   5   $
��Left=�5~   5   5   +   5�   '   ��5�   &   �� 5�   *   " �60    5�   .   �� 5�   2    6>   �� *WeatherState+ 16_   .a�5�   6   ��  � z� 5�   :   T� 5�   >    6Q   �� $ 	container��$ ActualHeight�5�   7   5�   3   5�   +   5�   #   5�      5�      �� 5�      $��1��6    $��Right=�60   $%��/Content/Design/Images/logo.png��6L   6w   5�      � 5�      -   5        $��PageContentGrid��5�      $��1��62     BackgroundGradientBrush#��[ 6?   6w   5�      �� 5�      $	��128��6   $��96��6%   $	��Top=�61   #��[ 6I   $��1q�6�   y�5�      �� *IsUserEngaged+ * &InvertibleBooleanToVisibilityConverter# [ ._�5�      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer     DefaultUserColor# [ 6)      UserColoringMode$ Manual=�6o       ImageBackground
  ���� !   
UserColors! 6�   �� *PostEngagementUserColors+6�   5�      5�      5�      4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5�   
   $��Center=�6W   "   IsListening" .  $��0 0 0 5q�6�   #   KinectSensorChooser# 6#   �� *KinectSensorChooser+6�   5�      5�      