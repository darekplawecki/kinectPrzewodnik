   M S B A M L   `   `   `  ����E  APrzewodnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Przewodnik.ControlsPrzewodnik.Controls  5   	   =#clr-namespace:Przewodnik.ConvertersPrzewodnik.Converters  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   SlideTranslateY  �� TargetProperty W� From g� FillBehavior g� Duration g� DecelerationRatio  NextImageTransition � 	Resources   System.Windows.Visibility  Key �� 
TargetName R� KeyTime  Visible R� Value	 T� X
 �� ElementName �� Path-   'Przewodnik.Converters.NegativeConverter   Instance �� 	Converter �� Triggers �� Value �� Binding �� 
TargetName �� Property �� Value N� EnterActions  SlideStoryboard  PreviousImageTransition�� 5   	   D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   'c!clr-namespace:Przewodnik.Controls  5   	   *cv#clr-namespace:Przewodnik.Converters  5   	   %  &	        &	 �     7  7  7  7  &	 �    7  7  7  7  �� 5      .��5   
   W� $,  &RenderTransform.(TranslateTransform.Y)�5	      $ 0X�5
      $
 Stop=�6   $ 0:0:0.2D�5      $	 0.5Q�5      5      �� 5       5   
   ��  5      Visible Visible=�62   �� 5      SlideStoryboard .��5      W� $ 	container��5      $,  &RenderTransform.(TranslateTransform.X)�5      $ 0X�5      $
 Stop=�6   $ 0:0:0.4D�5      $	 0.5Q�5      T� 5      $ a��5      $  
Visibility�5      $ 0:0:0.4D�5      $
 Stop=�6&   ..�5      i� $ 0:0:0��6-   8   6=   5      T� 5      $ b��5       $  
Visibility�5!      $ 0:0:0.4D�5"      $
 Stop=�6&   ..�5#      i� $ 0:0:0��6-   8  6=   5$      5%      5&      .R�5'   
   � }�. .+�5(      � $��	container��6   z�5)      T� 5*      	 6)   �� $
 	container��$ ActualWidth�# Z .+�5,      �� $��a��6!   $y�Hidden=�6*   ��6>   �� $
 
transition��$ DisplayA��� 5-      $��b��6!   $y�Hidden=�6*   ��6>   �� $
 
transition��$ DisplayB�5.      5/       50   
   �� 51      $ A��6Q    6   �� $
 
transition��$ State�.a�52      �� $ a��6    � y�$ Visible=�6>   �� 53      $ a��6    � z� 54      T� 55      	 6-   �� $
 	container��$ ActualWidth�57       58      �� 59      8�� 6&   5;      �� 5<      $ B��6Q    6   �� $
 
transition��$ State�.a�5=      �� $ b��6    � y�$ Visible=�6>   �� 5>      $ b��6    � z� 5?      T� 5@      	 6-   �� $
 	container��$ ActualWidth�5B       5C      �� 5D      8�� 6&   5F      5H      �� 5L       5M   
   ��  5N      Visible Visible=�62   �� 5O      SlideStoryboard .��5P      W� $ 	container��5Q      $,  &RenderTransform.(TranslateTransform.X)�5R      $ 0X�5S      $
 Stop=�6   $ 0:0:0.4D�5T      $	 0.5Q�5U      T� 5V      $ a��5W      $  
Visibility�5X      $ 0:0:0.4D�5Y      $
 Stop=�6&   ..�5Z      i� $ 0:0:0��6-   8   6=   5[      T� 5\      $ b��5]      $  
Visibility�5^      $ 0:0:0.4D�5_      $
 Stop=�6&   ..�5`      i� $ 0:0:0��6-   8  6=   5a      5b      5c      .R�5d   
   � }�. .+�5e      � $��	container��6   $��0q�6$   z�5f      T� 5g      	 6)   �� $
 	container��$ ActualWidth�.+�5i      �� $��a��6!   $y�Hidden=�6*   ��6>   �� $
 
transition��$ DisplayA��� 5j      $��b��6!   $y�Hidden=�6*   ��6>   �� $
 
transition��$ DisplayB�5k      5l       5m   
   �� 5n      $ A��6Q    6   �� $
 
transition��$ State�.a�5o      �� $ a��6    � y�$ Visible=�6>   �� 5p      $ a��6    � z� 5q      T� 5r      	 6-   �� $
 	container��$ ActualWidth�# Z 5t       5u      �� 5v      8�� 6&   5x      �� 5y      $ B��6Q    6   �� $
 
transition��$ State�.a�5z      �� $ b��6    � y�$ Visible=�6>   �� 5{      $ b��6    � z� 5|      T� 5}      	 6-   �� $
 	container��$ ActualWidth�# Z 5       5�      �� 5�      8�� 6&   5�      5�      5�      