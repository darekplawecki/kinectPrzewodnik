   M S B A M L   `   `   `  ����   
Przewodnik    Przewodnik.Views.MainMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   -   $��MainMenuGrid��  � RowDefinitions  �� $��0.08* ��� $��0.84* ��� $��0.08* � � ColumnDefinitions �� $��0.07* ��� $��0.86* ��� $��0.07* �.+�� $��1��$��1�� �� �� �� ��   �� �� .+�8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -     Name$ TouristAttractionsButton��$��3q�$��0��$��0��$��2��$
��Auto��$
��Auto��$��0q�$
��Left=�   	BlueColor#��[  .���  �� $
��Auto ��� $��* �.+��� $��0��$3��-../Content/Design/Images/home_attractions.jpg����   BlockMargin#���  $��1��.+��� $2��,../Content/Design/Images/ico_attractions.png��$
��Left=�  Icon#���  �� $��atrakcje turystyczne��  TextTopBottomMargin#���    
BlockTitle#���  �� $W��QNiezbędnik każdego turysty, czyli co warto zobaczyć i zwiedzić we Wrocławiu!��  BlockDescription#���    -   $ EventsButton��$��3q�$��0��$��2��$
��Auto��$
��Auto��$	��Top=�  YellowColor#��[ .���   �� $
��Auto ��� $��* �.+��� $��0��$.��(../Content/Design/Images/home_events.jpg����  �� Orientation$ Vertical=�#���  $��1��.+��� $-��'../Content/Design/Images/ico_events.png��$
��Left=�#���  �� $��
wydarzenia��  TextTopMargin#���  #���    -   $ TwitterButton��$��3q�$��0��$��3��$��2��$
��Auto��$
��Auto��$	��Top=�  OrangeColor#��[ .���   �� $
��Auto ��� $��* �.+��� $��0��$/��)../Content/Design/Images/home_twitter.jpg���� $ Vertical=�#���  $��1��.+��� $.��(../Content/Design/Images/ico_twitter.png��$
��Left=�#���  �� $��twitter��#���  #���  �   �� �� �� .+��� $��0��$��@wroclaw_info��#���  $
��Bold"��� $��1��$z��tBez nich wrocławska nauka, kultura i sztuka były zupełnie inne. Żegnamy wrocławian, którzy odeszli w ciągu...��#���  �� $��2��$��11 godzin temu��#���   	 
FontSize18#��� 	 $��Regular"�$��Italic$�$��Right=�  -   $ WeatherButton��$��3q�$��1��$��0��$
��Auto��$
��Auto��$	��Top=� 
 
GreenColor#��[
 .���   �� $
��Auto ��� $��* �.+��� $��0��$/��)../Content/Design/Images/home_weather.jpg���� $ Vertical=�#���  $��1��.+��� $ 
Horizontal=�.+��� -   $��weatherImage��$
��Left=��� -   $��temperature��$��35(�
��������� -   $��description��$��20(�
�������$
��Wrap=�  -	   $ 
MapsButton��$��3q�$��1��$��1��$
��Auto��$
��Auto��$��Bottom=�  PurpleColor#��[ .���   �� $��* ��� $
��Auto �.+��� $ Vertical=�#���  $��0��.+��� $+��%../Content/Design/Images/ico_maps.png��$
��Left=�#���  �� $��plan miasta��#���  #���  �� $��1��$,��&../Content/Design/Images/home_maps.jpg��  -
   $ ObjectsButton��$��3q�$��1��$��2��$
��Auto��$
��Auto��$	��Top=�  	LimeColor#��[ .���   �� $
��Auto ��� $��* �.+��� $��0��$/��)../Content/Design/Images/home_objects.jpg���� $ Vertical=�#���  $��1��.+��� $.��(../Content/Design/Images/ico_objects.png��$
��Left=�#���  �� $��obiekty��#���  #���  