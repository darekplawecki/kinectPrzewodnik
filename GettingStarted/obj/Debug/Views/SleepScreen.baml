   M S B A M L   `   `   `  ����E  APrzewodnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Przewodnik.ControlsPrzewodnik.Controls  5      ;"clr-namespace:Przewodnik.UtilitiesPrzewodnik.Utilities  5      "    Przewodnik.Views.SleepScreen   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5      +c!clr-namespace:Przewodnik.Controls   5      ,u"clr-namespace:Przewodnik.Utilities   5      -   5        $��SleepScreenGrid��5      $��Stretch=�5	      $��Stretch=�5
      
���   �  � 	Resources  5       $   PreEngagementBackgroundUserColor �� A �� R �� G �� B��%T   &	        �� 5   
   $	 #80��69   $	 #40��6A   $	 #43��6I   $	 #46��6Q   5      .+�5      � -   5        $��InstagramGrid��5      $��Center=�6    $��Center=�6=     5   
     FadeTransition$  Przewodnik.Controls.Transition  Name   Source ��Name J� Opacity	 �� ElementName
 �� Path �� Triggers �� Value �� Binding �� 
TargetName �� Property �� Value N� EnterActions �� 
TargetName �� TargetProperty W� From	 W� To g� Duration g� FillBehavior R� KeyTime R� Value  System.Windows.Visibility��%�  &	       �� 5      .R�5      � .+�5        $ t��6#    6/   �� �� 5      $ a��6%   $y�Visible=�60   $ 1Q�6E   ��6Q   �� $	 t��$
 DisplayA��� 5      $ b��6%   $y�Hidden=�60   $ 1Q�6D   ��6P   �� $	 t��$
 DisplayB�5       5      �� 5      $ A��6P    6"   �� $	 t��$
 State�.a�5      �� $ a��6!    �@K�ZIndex$ 1��6H   �� 5      $ a��6!    � y�$ Visible=�6F    5       �� 5!      .��5"   "   �� .��5#   &   W� $ a��66   $ Opacity�6P   $ 0X�5$      $ 1X�6   $ 0:0:0.5D�6   $ HoldEnd=�60   T� 5%   &   $ b��5&   
   $ 
Visibility�5'   
   $ 0:0:0.5D�5(   
   $
 Stop=�6   ..�5*   *   i� $ 0:0:0��6A    5+   .    5,   2   Visible=�6F   5.   +   5/   '   50   #   51      53      �� 54      $ B��6P    6"   �� $	 t��$
 State�.a�55      �� $ b��6!    �@K�ZIndex$ 1��6H   �� 56      $ b��6!    � y�$ Visible=�6F    57      �� 58      .��59   "   �� .��5:   &   W� $ b��66   $ Opacity�6P   $ 0X�5;      $ 1X�6   $ 0:0:0.5D�6   $ HoldEnd=�61   T� 5<   &   $ a��5=   
   $ 
Visibility�5>   
   $ 0:0:0.5D�5?   
   $
 Stop=�6   ..�5A   *   i� $ 0:0:0��6A    5B   .    5C   2   Visible=�6F   5E   +   5F   '   5G   #   5H      5J      5L      5M       � RowDefinitions 5O   
   �� 5P      $	��640 �6   6+   �� 5Q      $	��640 �6   6+    � ColumnDefinitions 5S   
   �� 5T      $	��640 �6   6-   �� 5U      $	��640 �6   6-   �� 5V      $	��640 �6   6-   .+�5Y   
   �� -   5        $ AttractCarousel1��5Z      $��0��5[      $��0��5\      $��Center=�5]      $��Center=�5^      #��[ 5_      5`      �� 5b   
   -   5        $ AttractCarousel2��5c      $��0��5d      $��1��5e      $��Center=�5f      $��Center=�5g      #��[ 5h      5i      �� 5k   
   -   5        $ AttractCarousel3��5l      $��0��5m      $��2��5n      $��Center=�5o      $��Center=�5p      #��[ 5q      5r      �� 5t   
   -   5        $ AttractCarousel4��5u      $��1��5v      $��0��5w      $��Center=�5x      $��Center=�5y      #��[ 5z      5{      �� 5}   
   -   5        $ AttractCarousel5��5~      $��1��5      $��1��5�      $��Center=�5�      $��Center=�5�      #��[ 5�      5�      �� 5�   
   -   5        $ AttractCarousel6��5�      $��1��5�      $��2��5�      $��Center=�5�      $��Center=�5�      #��[ 5�      5�      5�      '   !Przewodnik.Controls.PromptControl  5�        ContentFade#��[ 5�   	      State 5�   	   �� *IsUserActive+ �� ConverterParameter$ False�� + 'InvertibleBooleanToPromptStateConverter �� 	Converter# [ .��5�   
   8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer     DefaultUserColor# [  5�          UserColoringMode$  Manual=�5�      !   ImageBackground
! ���� $��Stretch=�5�      $��Stretch=�5�      "   
UserColors" 5�      �� *PreEngagementUserColors+5�      5�        5�      #   Text$C# =Podnieś rękę, aby rozpocząć.   Raise your hand to begin.��5�   	   
�������  KinectPurpleBrush#��[ 5�   	     StartBanner#��[ 5�   	    5�   	   �� *StartBannerState+  5�      #��[ 5�        EngagementConfirmation#��[ 5�       5�      �� *EngagementConfirmationState+.��5�   
   �� $ �� Orientation$$ 
Horizontal=�6   $	��680��6.   $	��330��6:   .+�5�      8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -	   5        #��[ 5�   !   $��0q�6Q   $	��330��6e   $	��330��6q   $��0,0,10,0q�6~   /   )Przewodnik.Utilities.CommandOnEventHelper%   AssociationEntry% 5�      4   .Przewodnik.Utilities.CommandOnEventAssociation  5�      &   Event$& Click��6d   '   Command' 62   �� *EngagementConfirmationCommand+6d   .��5�      � .+�5�      �� $��Center=�5�      $��Center=�5�      
������ $��40(�5�      
�������$
��Wrap=�5�      ( �� TextAlignment$( Center=�5�      $��Wciśnij aby rozpocząć��5�      5�      5�        5�      -
   5        #��[ 5�   !   $��0q�6Q   $	��330��6e   $	��330��6q   $��10,0,0,0q�6~   % 5�        5�      $& Click��6d   ' 62   �� *EngagementConfirmationCommand+6d   .��5�      � .+�5�      �� $��Center=�5�      $��Center=�5�      
������ $��40(�5�      
�������$
��Wrap=�5�      $( Center=�5�      $��Press button to start��5�      5�      5�      5�      5�      � 5�      ���	#CC4b0082$��Right=�6"   $	��Top=�6>   $��	0,50,50,0q�6V    5�   
   �� 5�      6!   �� 5�      6!    5�   
   �� 5�      6   �� 5�      6   .+�5�   
   �� -   5        $
��Time��5�   B   $��0��6   $��0��6$   $��2��61   $��90(�6N   
�������$��Light"�6o   $��	20,0,20,0q�6�   6�   �� 5�   
   -   5        $��WeekDay��5�   1   $��1��6   $��0��6$   $��35(�6@   
�������$��Light"�6a   $��Bottom=�6t   $��	0,0,20,-5q�6�   6�   �� 5�   
   -   5        $��DayAndMonth��5�   1   $��1��6   $��1��6$   $��35(�6D   
�������$��Light"�6e   $	��Top=�6x   $��	0,-5,20,0q�6�   6�   5�      5�      