   M S B A M L   `   `   `  ����   
Przewodnik#    Przewodnik.Views.CalendarPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   -     �Name$  CalendarGrid��.+�� }�. $��
50 0 50 50q� � RowDefinitions �� $��1* ��� $��1* ��� $��4* � � ColumnDefinitions �� $��3* ��� $��1* �.+��� -    ��Name$ titleTextBlock��$��50(�$��0��$��0����  �� Orientation$ 
Horizontal=�$��	0,-50,0,0q�$��0��$��1��$��2��.+�8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -     Name$ 	Wszystkie��   	OldButton#��[  $��	Wszystkie��$	��100��$��50��$��20(�  -   $ Muzyka��#��[  $��Muzyka��$	��100��$��50��$��20(�  -   $
 Kino��#��[  $
��Kino��$	��100��$��50��$��20(�  -   $ Teatr��#��[  $��Teatr��$	��100��$��50��$��20(�  -   $	 Art��#��[  $	��Art��$	��100��$��50��$��20(�  -   $	 Off��#��[  $	��Off��$	��100��$��50��$��20(�  -	   $ DJ��#��[  $��DJ��$	��100��$��50��$��20(�  -
   $ Sport��#��[  $��Sport��$	��100��$��50��$��20(�  -   $ Dzieci��#��[  $��Dzieci��$	��100��$��50��$��20(�  -   $ Nauka��#��[  $��Nauka��$	��100��$��50��$��20(�  -   $
 Inne��#��[  $
��Inne��$	��100��$��50��$��20(��� -   $ 
emptyBlock��$
��Auto��$+��%Brak wydarzeń dla wybranej kategorii��$��20(�$��Black"�$y�Hidden=�$��0��$��2��:  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  -     Name$ ScrollViewer��$��Disabled=�$
��Auto=�
������    HoverBackground
 ���� $��0��$��2��.���� $ Vertical=�$��0, -100, 0, -100q�.+��� -    ��Name$ 	EventList��$
��Left=�$��Center=�$��0q����� .R��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��0,0,10,0q�$
��Auto��$��Black"�
��� ������� *Hour+�� $��0,0,10,0q�$
��Auto��$��Black"�
���Gc������ *Type+�� $��0,0,10,0q�$
��Auto��$��Black"�
���**������ *Place+�� $��0,0,0,20q�$
��Auto��$��Black"�$��16(����� *Name+  $	��200��$��Disabled=�$
��Auto=�$��1��$��2��$��2��
 ���� .���� $ Vertical=�$��0,-100,0,-100q�.+�  -   $
 day1��#��[  $	��150��$��50��$��20(�  -   $
 day2��#��[  $	��150��$��50��$��20(�  -   $
 day3��#��[  $	��150��$��50��$��20(�  -   $
 day4��#��[  $	��150��$��50��$��20(�  -   $
 day5��#��[  $	��150��$��50��$��20(�  -   $
 day6��#��[  $	��150��$��50��$��20(�  -   $
 day7��#��[  $	��150��$��50��$��20(�  -   $
 day8��#��[  $	��150��$��50��$��20(�  -   $
 day9��#��[  $	��150��$��50��$��20(�  -   $ day10��#��[  $	��150��$��50��$��20(�  -   $ day11��#��[  $	��150��$��50��$��20(�  -   $ day12��#��[  $	��150��$��50��$��20(�  -   $ day13��#��[  $	��150��$��50��$��20(�  -   $ day14��#��[  $	��150��$��50��$��20(�