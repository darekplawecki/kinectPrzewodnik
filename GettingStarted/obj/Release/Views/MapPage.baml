   M S B A M L   `   `   `  ���� E  APrzewodnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Przewodnik.ViewModelsPrzewodnik.ViewModels  d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF     Przewodnik.Views.MapPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :
ViewModels#clr-namespace:Przewodnik.ViewModels     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   \mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF   -   $��MapPageGrid��  � DataContext  (  "Przewodnik.ViewModels.MapViewModel  .+��� -    ��Name$ firstTextBlock��$��50 50 50 150q�$��50(�Mapa� -    �Name$ MapGrid��$��	0 150 0 0q�.+�'  !Microsoft.Maps.MapControl.WPF.Map  -     Name$ MasterBingMap��+  %Microsoft.Maps.MapControl.WPF.MapCore   CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F @AoYws8aLN6--qMJ06VlJ6uj2rZWoiDKX1h7NESbZKANua_yepBlEBu3ZuybMUN9q    Mode;  5Microsoft.Maps.MapControl.WPF.Design.MapModeConverter$
 Road    Center �� *MapCenterPoint+ �� Mode$ TwoWay=�   	ZoomLevel �� *MapZoomLevel+$ TwoWay=�	   Children.	 �� $	��100��$��50��,  &Microsoft.Maps.MapControl.WPF.MapLayer
   Position<  6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$
 51.105726, 17.030613    PositionOriginB  <Microsoft.Maps.MapControl.WPF.Design.PositionOriginConverter$ BottomCenter  J� Opacity$	 0.7Q�$��Center=�.+�F� =����        � -1    � -1 Zbр�� ����     Zb�        	
���  ��
�������$��2���� $��15(�
���   �$��25 0 0 0q�Opera�� Wrocławska�� $	��100��$��50��$
 51.109588, 17.032255 $ BottomCenter $	 0.7Q�$��Center=�.+�F� =����        � -1    � -1 -1р�� ����     -1�        	
���  ��
�������$��2���� $��15(�
���   �$��25 0 0 0q�Ratusz�� $	��100��$��50��$
 51.113313, 17.004950 $ BottomCenter $	 0.7Q�$��Center=�.+�F� =����        � -1    � -1 ��р�� �,�     ���        	
���  ��
�������$��2���� $��15(�
���   �$��25 0 0 0q�Muzeum�� współczesne�� 
Wrocław�� $	��100��$��50��$
 51.110178, 17.044595 $ BottomCenter $	 0.7Q�$��Center=�.+�F� =����        � -1    � -1 Zbр�� ����     Zb�        	
���  ��
�������$��2���� $��15(�
���   �$��25 0 0 0q�
Panorama�� Racławicka�� -    ��Name$ 
LogMessage��.+��� -   $ testMessageLeftHand��$
��1000��$	��200��$��20(�
���   �$��Center=����� *TestMessageHand+