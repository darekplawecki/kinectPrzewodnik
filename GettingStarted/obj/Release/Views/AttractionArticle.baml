   M S B A M L   `   `   `  ����   
Przewodnik(    "Przewodnik.Views.AttractionArticle   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   -     �Name$  AttractionArticleGrid�� � RowDefinitions �� $��0.22* ��� $
��0.7* ��� $��0.08* � � ColumnDefinitions �� $��0.07* ��� $��0.86* ��� $��0.07* �.+��� $��0��$��0��$��3��   	PageTitle#���   ���� *Title+ �� Mode$ OneWay=�� $��1��$��1��}�.  �� $��3* ��� $��* � �� $��1* ��� $��1* ��� $��1* ��� $��3* �.+�� -   $��bigImageGrid��$��3��$��0��8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   $��FirstImageButton��
������ $��0��$��1��$
��Auto��$
��Auto��$	��Top=�$��0q�.���� .+��� -   $��firstImageSource��$��UniformToFill=�  -   $��SecondImageButton��
������ $
��Auto��$
��Auto��$	��Top=�$��1��$��1��$��0q�.���� .+��� -   $��secondImageSource��$
��Fill=�  -   $��ThirdImageButton��
������ $
��Auto��$
��Auto��$	��Top=�$��2��$��1��$��0q�.���� .+�� .+��� -   $��thirdImageSource��� ���#5A5B5B J� Opacity$	 0.6Q�����  �� 
TargetType" � �� Triggers ��  �� Binding �� *Camera+ �� Value Z� .a��� 	 �� Property	 � y�
 �� Value$
 	Collapsed=�.+��� $!��../Content/play-overlay.png��$��Center=�$��Center=�$��80��$��80��$��0, -20, 0, 0q�:  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  $��3��$��2��$
��Auto=�$	��Top=�   HoverBackground
 ���� .���� -	   $��descriptionTextBlock��$��30,-100,10,-100q�  
BlockTitle#���    	GrayColor#��[  �� TextAlignment$ Justify=�$	��Top=����� *Description+$ OneWay=�