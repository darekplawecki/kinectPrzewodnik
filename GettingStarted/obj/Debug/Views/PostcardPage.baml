   M S B A M L   `   `   `  ����E  APrzewodnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Przewodnik.UtilitiesPrzewodnik.Utilities  5      9!clr-namespace:Przewodnik.ControlsPrzewodnik.Controls  5      =#clr-namespace:Przewodnik.ConvertersPrzewodnik.Converters  5      ] YGma.QrCodeNet.Encoding, Version=0.4.0.0, Culture=neutral, PublicKeyToken=e8a75d24b142be49wPclr-namespace:Gma.QrCodeNet.Encoding.Windows.WPF;assembly=Gma.QrCodeNet.Encoding"Gma.QrCodeNet.Encoding.Windows.WPF 5	      #    Przewodnik.Views.PostcardPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5      ,u"clr-namespace:Przewodnik.Utilities   5      +c!clr-namespace:Przewodnik.Controls   5      .cv#clr-namespace:Przewodnik.Converters   5      c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5      ZwpfPclr-namespace:Gma.QrCodeNet.Encoding.Windows.WPF;assembly=Gma.QrCodeNet.Encoding  5	      -   5        $��PostcardGrid��5
      }�. .+�5      $  Przewodnik.Controls.Transition  -   5           Name$  
transition��5         Source 6'   ��  �� ElementName$ BackgroundPhoto�� �� Path$ Content��� 5      -   5        $��BackgroundPhoto��5      $��Center=�6,   $��Center=�6I   � 5      -   5        $��Camera��5      $��Center=�6   $��Center=�66      CameraWidth#���   6Q     CameraHeight#���  6w   .+�5   
   �� -   5        $��MaskedColor��5      $
��Fill=�6#   �� 5   
   -   5        $��CameraFrame��5      $,��&../Content/Postcard/camera_frame_3.png��6#   $
��Fill=�6S   6d   5      �� 5      -   5         ��Name$ NavigationButtons��5       �� Orientation$ 
Horizontal=�6-   $��Bottom=�6F   $��Center=�6a   $��0,0,0,50q�6~   .+�5   
   8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   5        $��
PrevButton��5      $��0��6/     NavButtonsIconSize#���  6?   #���  6l   $��0,0,0,0q�6�   $��Center=�6�   
������ 
������ $��0q�6�   .��5      �� $&�� ../Content/Postcard/ico_prev.png��6   6@   5        5   
   -	   5        $��SnapshootButton��5      $��0��64     SnapshootIconSize#���  6D   #���  6p   $��50,0,0,0q�6�   $��Center=�6�   
������ 
������ $��0q�6�   .��5      �� $+��%../Content/Postcard/ico_snapshoot.png��6   6E   5        5   
   -
   5        $��
NextButton��5      $��0��6/   #���  6?   #���  6l   $��50,0,0,0q�6�   $��Center=�6�   
������ 
������ $��0q�6�   .��5      �� $&�� ../Content/Postcard/ico_next.png��6   6@   5      5      �� 5!      -   5        $��Counter��5!      $��Center=�6   $��Center=�6<   ���#FFF  Size200#���  6i   $��Black"�6�    J� Effect 5"   
   3  -System.Windows.Media.Effects.DropShadowEffect  5#         ShadowDepth$ 2Q�6      
BlurRadius$ 0Q�6/   	   Color$	 	#FF000000��6>   5%      �� 5'      -   5        
 ��Name$
 QuickStartCanvas��5'      .+�5(   
   �� $ 
Horizontal=�6   .+�5)      �� -   5         ��Name$ QuickStartTextBlock��5)       
 Size80#���  65   $
��Wrap=�6Y   $	��800��6m   $��Light"�6y    �� TextAlignment$ Center=�5*       $��100,50,100,0q�67   
������� J� Opacity$	 0.8Q�6`   6p     5,      -   5          Name$ QuickStartCancel��5,   !     EventCategoryBlockSize#���  6;   #���  6l     
GreenColor#��[ 6�   .��5-      �� $ Vertical=�6   .+�5.      � .+�5/      �� $*��$../Content/Events/Icons/ico_skip.png��6      Icon#���  6N   6o   �� 50      $(��"../Content/Events/white-circle.png��6    #���  6L   6m   51      �� 52      -   5        $��QuickStartCancelText��52       $��Center=�6<    	 TextTopMargin#��� 	 6Y    
 TextBlockStyle#��� 
 6�    
 Size36#���  6�    �� 
LineHeight# �  6�   6�   53      54      55      56      �� 58      $
��1920��6   $
��1080��6   ���#ebebeb$	 0.7Q�6:   y�6H   �� $ 	qrControl��$ 
Visibility�� 59      -   5        $��
CodeQRArea��59      $��Center=�6   $��Center=�6:     CodeQRAreaWidth#���  6�     CodeQRAreaHeight#���  6�   y�6U   �� $ 	qrControl��$ 
Visibility�.+�5:   
   �� 
���   �$	 0.4Q�6!    �� RadiusX$ 10��6/    �� RadiusY$ 10��6<    �� Stretch$
 Fill=�6I   $
��Auto��6X   $
��Auto��6e   �� 5<   
   $ 
Horizontal=�6     BlockMarginBigger#���  6.   .+�5=      �� -   5        $��Picture��5=        PictureWidth#���  6#     PictureHeight#���  6J   6u   � 5>        CodeQRAreaWidthRight#���  6   $
��Auto��6B   $��Center=�6P     BlockMarginLeft#���  6m    � RowDefinitions 5?      �� 5@      $
��Auto �6$   64   �� 5A      $
��Auto �6$   64   .+�5D      �� -   5        $��ScanCodeText��5D   X   $��0��6   #���  6)   
�������#��� 
 5E       
 Size60#���  6E    
 Size65# �  5F      $ Center=�6B   $��Center=�5G      6;   �� 5I      $��1��6   $ 
Horizontal=�6*   #���  6C   .+�5J      �  
 QRSize#���  6   #���  6<   $��Center=�6^     BlockMargin#���  6{   .+�5K      �� -   5        $��qrCanvas��5K   !   $��Center=�61   $��Center=�6L   #���  6i   #���  6�   $��0q�6�   .+�5L      9  3Gma.QrCodeNet.Encoding.Windows.WPF.QrCodeImgControl  -   5        $��	qrControl��5L   \   $��Stretch=�63   $��0q�6Q   $��Stretch=�5M   /   #���  6K   #���  6m      QuietZoneModule$
 Zero=�6�      IsGrayImage .    
LightColor$ 	#FFFFCCFF��5N   B      	DarkColor$ 	#FF910000��6Y   $y�Hidden=�6o   5O      5P        5R      -   5        $��NewPhotoButton��5R   )   #���  6?   #���  6`   $��15,0,0,0q�6�     	GrayColor#��[ 6�   #���  6�   .��5S      �� -   5        $��NewPhotoTextBlock��5S   $   
�������#��� 
 6P   #��[ 6y   # �  5T   $   $ Center=�6J   $��Center=�5U   $   $��Center=�6A   6_   5V      5W      5Z      5[      5\      �� 5^      -   5        $
 InfoMessageCanvas��5^      $��Center=�6(   $��Center=�6C   $	��600��6`   $	��600��6l   $y�Hidden=�6y   .+�5_   
   �� -   5        $ InfoMessageTextBlock��5_      #���  5`      $
��Wrap=�5a      $��Center=�5b      $��Center=�5c      $��Light"�5d      $ Center=�5e      $	��600��5f      
�������$	 0.8Q�5h      5i      5k      