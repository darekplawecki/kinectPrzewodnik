   M S B A M L   `   `   `  ���� E  APrzewodnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Przewodnik.ControlsPrzewodnik.Controls  ;"clr-namespace:Przewodnik.UtilitiesPrzewodnik.Utilities  "    Przewodnik.Views.SleepScreen   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   +c!clr-namespace:Przewodnik.Controls   ,u"clr-namespace:Przewodnik.Utilities   -   $��SleepScreenGrid��$��Stretch=�$��Stretch=�
���   �  � 	Resources   $   PreEngagementBackgroundUserColor �� A �� R �� G �� B��%7   &	        �� $	 #80��$	 #40��$	 #43��$	 #46��.+�� -   $��InstagramGrid��$��Center=�$��Center=�    FadeTransition$  Przewodnik.Controls.Transition  Name   Source ��Name J� Opacity	 �� ElementName
 �� Path �� Triggers �� Value �� Binding �� 
TargetName �� Property �� Value N� EnterActions �� 
TargetName �� TargetProperty W� From	 W� To g� Duration g� FillBehavior R� KeyTime R� Value  System.Windows.Visibility��%  &	       �� .R�� .+�  $ t�� �� �� $ a��$y�Visible=�$ 1Q����� $	 t��$
 DisplayA��� $ b��$y�Hidden=�$ 1Q����� $	 t��$
 DisplayB� �� $ A�� �� $	 t��$
 State�.a��� $ a�� �@K�ZIndex$ 1���� $ a�� � y�$ Visible=� �� .���� .��W� $ a��$ Opacity�$ 0X�$ 1X�$ 0:0:0.5D�$ HoldEnd=�T� $ b��$ 
Visibility�$ 0:0:0.5D�$
 Stop=�..�i� $ 0:0:0��  Visible=��� $ B�� �� $	 t��$
 State�.a��� $ b�� �@K�ZIndex$ 1���� $ b�� � y�$ Visible=� �� .���� .��W� $ b��$ Opacity�$ 0X�$ 1X�$ 0:0:0.5D�$ HoldEnd=�T� $ a��$ 
Visibility�$ 0:0:0.5D�$
 Stop=�..�i� $ 0:0:0��  Visible=� � RowDefinitions �� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $ AttractCarousel1��$��0��$��0��#��[ �� -   $ AttractCarousel2��$��0��$��1��#��[ �� -   $ AttractCarousel3��$��0��$��2��#��[ �� -   $ AttractCarousel4��$��1��$��0��#��[ �� -   $ AttractCarousel5��$��1��$��1��#��[ �� -   $ AttractCarousel6��$��1��$��2��#��[ '   !Przewodnik.Controls.PromptControl    ContentFade#��[    State �� *IsUserActive+ �� ConverterParameter$ False�� + 'InvertibleBooleanToPromptStateConverter �� 	Converter# [ .��8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer     DefaultUserColor# [      UserColoringMode$  Manual=�!   ImageBackground
! ���� $��Stretch=�$��Stretch=�"   
UserColors" �� *PreEngagementUserColors+  #   Text$%# Podnieś rękę aby rozpocząć��
�������  KinectPurpleBrush#��[   StartBanner#��[  �� *StartBannerState+  #��[   EngagementConfirmation#��[  �� *EngagementConfirmationState+.��8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  #��[ $	��330��$	��330��$��Center=�$��Center=�$��0q�/   )Przewodnik.Utilities.CommandOnEventHelper$   AssociationEntry$ 4   .Przewodnik.Utilities.CommandOnEventAssociation  %   Event$% Click��&   Command& �� *EngagementConfirmationCommand+.��� .+��� $��Center=�$��Center=�
������ $��40(�
�������$
��Wrap=�$��Wciśnij aby rozpocząć��� ���	#CC4b0082$��Right=�$	��Top=�$��	0,50,50,0q� �� ��  �� �� .+��� -	   $
��Time��$��0��$��0��$��2��$��90(�
�������$��Light"�$��	20,0,20,0q��� -
   $��WeekDay��$��1��$��0��$��35(�
�������$��Light"�$��Bottom=�$��	0,0,20,-5q��� -   $��DayAndMonth��$��1��$��1��$��35(�
�������$��Light"�$	��Top=�$��	0,-5,20,0q�