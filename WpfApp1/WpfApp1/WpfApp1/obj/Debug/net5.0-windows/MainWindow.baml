   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � WindowStartupLocation$  CenterScreen=�5	       � Title$ Головне вікно��5
   	   $	��410��6   $	��652��6,    � 
ResizeMode$ NoResize=�68   $
��Left=�6N   $	��Top=�6p    � Icon$ /diamond_icon_196971.png��6�    J� 	AllowDrop$
 True��6�   .��5      � $��0,0,0,0q�6   ���#E6E7F2 J� RenderTransformOrigin$ 0.497,0.577&�61    � ColumnDefinitions 5   
   �� 5      $
��553* �6   �� 5      $	��35* �6   �� 5      $	��64* �6    � RowDefinitions 5   
   �� 5      $
��215* �6   �� 5      $
��179* �6   .+�5   
   �� 
�������$��124,42,25,0q�6$   $��2��69   $	��274��6J   $	��Top=�6W   $ 0.489,0.577&�6o    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 30Q�6#   
   Color$
 	LightGray��63   6G   5      �� 5   
   $)��#Привіт, користувач!��6   $
��Left=�6.   $��44��6I   $��
136,56,0,0q�6U   $	��Top=�6i   $	��294��6�   $��22(�6�   $
��Bold"�6�   �� 5   
   -   5        $��
Вийти��5      
�������$
��Left=�6I   $��38��6d   $��
348,26,0,0q�6p   $��1��6�   $	��Top=�6�   $	��137��6�   �� 5   
   -   5        $��Гра��5      
�������$
��Left=�6H   $��38��6c   $��
156,26,0,0q�6o   $��1��6�   $	��Top=�6�   $	��137��6�   $��16(�6�   $��Normal"�6�   $��Normal$�6�   $��1,0,0,1q�6�   ���	#FF2952746  �� 5   
   -   5        $��Калькулятор��5      
�������$
��Left=�6N   $��38��6i   $��156,147,0,0q�6u   $	��Top=�6�   $	��137��6�   �� 5   
   -   5        $��Реєстрація��5      
�������$
��Left=�6L   $��38��6g   $��348,147,0,0q�6s   $	��Top=�6�   $	��137��6�   �� 5   
   $=��7Обери одну із доступних опцій:��6   $
��Left=�69   $��37��6T   $��	136,0,0,0q�6`   $��Center=�6s   $	��235��6�   $��14(�6�   �� 5    
   -   5        $��
Автор��5       ���	#FF673AB7$
��Left=�6P   $��26��6k   $��268,132,0,0q�6w   $��1��6�   $	��Top=�6�   $	��116��6�   $��13(�6�   $��Normal"�6�   $��Normal$�6�   $��1,0,0,1q�6�   ���	#FF295274���	#FFE2E3EE6$  5#      5$      