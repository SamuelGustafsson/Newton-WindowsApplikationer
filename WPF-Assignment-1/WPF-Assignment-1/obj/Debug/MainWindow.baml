   M S B A M L   `   `   `  ����K  GWPF-Assignment-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPF_Assignment_1WPF_Assignment_1  5   	   !    WPF_Assignment_1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,sclr-namespace:WPF_Assignment_1     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5      ]� -   5        $��mainDockPanel��5      ��. .+�5	   
   o� $	��Top=�6   $
��Left=�6$   
�������
���   �.@�5      m� $��_File��6   .@�5      m� -   5        $��_Exit��5      5   4   5      m� 5      $��_Edit��6   .@�5      m�  m� Command$ ApplicationCommands.Copy��6   m� 5      $ ApplicationCommands.Cut��6   m� 5      $ ApplicationCommands.Paste��6   5      5      �� 5   
   $��Bottom=�6   
���P��$��40��5      .@�5      �� .��5      �� -   5        $��statusBarText��5      $��Ready��5      5      5       c� 5#   
   $	��Top=�6   $��Center=�6'   $��70��5$      .@�5&      	� -   5        $��btnRektangel��5&       	� 	GroupName$ shapeSelection��5'      
���   �$��2q�5)      $
��Left=�5*      .��5+      � .+�5,      �� 
���  ��$��30��5-       �� 5/      $��	Rektangel��6     �� TextAlignment$ Center=�50       $��Center=�51       52      53      	� 56      -   5        $��btnRomb��56      $ shapeSelection��57      
���   �$��2q�59      $
��Left=�5:      .��5;      � .+�5<      �� 
����+��$��30��5=       $��30��5>        � LayoutTransform 5?      �� 5@       �� Angle$	 -45Q�6.   5B      �� 5D      $
��Romb��6    $ Center=�5E       $��Center=�5F       6=   5G      5H      	� 5I      -   5        $��btnLine��5I      $ shapeSelection��5J      
���   �$��2q�5L      $
��Left=�5M      .��5N      � .+�5O      �� 
���   �$��35��5Q      $��35��5R      $��10��5S      
����  �	 �� X1$ 10��5U      	 �� Y1$ 10��6!   	 �� X2$ 25��5V      		 �� Y2$	 25��6!   
 �� StrokeStartLineCap$
 Triangle=�5W       �� StrokeEndLineCap$
 Flat=�5X      63   5Y      5Z      �� 5[      -   5        $��Clear canvas��5[      5^      5_      �� 5b   
   -   5        $��canvasDrawingArea��5f      $
��Left=�5b      }�. 
��� ���5f      5g      5h      