   M S B A M L   `   `   `  ���� E  APrzewodnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Przewodnik.ConvertersPrzewodnik.Converters  "    Przewodnik.Views.TwitterPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   6
converters#clr-namespace:Przewodnik.Converters   c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  -   $��TwitterGrid��.+��� -     ��Name$  firstTextBlock��$��50 50 50 150q�$��50(�Twitter feed:  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  -   $��ScrollViewer��$��50 150 50 50q�$
��Auto=�$��Disabled=�   ContentMargin$ 0Q�$	��220��$	��300��
������    HoverBackground
 ���� .����  �� Orientation$ Vertical=�.+��� -   $��ErrorContent��$�� ��$��20(��� -   $��TwitterContent��$�� ���� -    ��Name$ MainList��$
��Left=�$��Center=� � 	Resources -   'Przewodnik.Converters.DateTimeConverter   dateConverter��%   &	          ���� .R��� $ 
Horizontal=�.+�+  %Microsoft.Expression.Controls.Callout     AnchorPoint$ -0.103,1.02&�   CalloutStyle$ RoundedRectangle=�9  3Microsoft.Expression.Controls.CompositeContentShape   Fill �	#FF52318F$��14.667(�$
��Left=�$��70��$��30, 30 , 5, 30q�	   Stroke
	 �����$	��Top=�$	��550��
 J� RenderTransformOrigin$
 0.488,-0.019&����� $��20, 5, 20, 5q�$	��550��.+��� $ 
Horizontal=�.+��� $��Black"����� *Author+�� ���� *Date+ �� 	Converter# [  �� $
��Wrap=����� *	Content+