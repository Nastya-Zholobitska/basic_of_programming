   M S B A M L   `   `   `  ����B  >library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:librarylibrary  5   	   )    #library.Операції_книги   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:library     5   	     � WindowStartupLocation$  CenterScreen=�6.    � Title$! Операції_книги��5   	   $��507.6��6    $��887.2��6/   ���	#FFEAEBF1.��5	      � .+�5
   
   �� 
�������$
��Left=�6!   $��70��6<   $��	29,64,0,0q�6H   
�������$	��Top=�6j   $	��301��6�   �� 5   
   $
��Left=�6   $��66��6/   $��
316,64,0,0q�6;   $	��Top=�6O   $��14��6g   ���	#FF94949C6r   �� 5   
   $
��Left=�6   $��53��6/   $��
286,75,0,0q�6;   $	��Top=�6O   $��20��6g   ���	#FFDC8C8C J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 20.818Q�6&   T� 5      5      5      �� 5   
   -   5        $W��QВидалити тих, хто рік не проходив перереєстр��5      $
��Left=�6H   $��39��6c   $��
27,186,0,0q�6o   $	��Top=�6�   $	��303��6�   $��14(�6�   ���	#FFB65454
�������6�   �� 5   
   -   5        $?��9Видання/отримання книг читачам��5      $
��Left=�6:   $��39��6U   $��
27,238,0,0q�6a   $	��Top=�6u   $	��303��6�   $��14(�6�   ���	#FFBA5353
�������6�   �� 5   
   -   5        $6��0Видалення/добавлення книг��5      $
��Left=�65   $��39��6P   $��
27,289,0,0q�6\   $	��Top=�6p   $	��303��6�   $��14(�6�   ���	#FFBA5353���	#FF3B3B3F{�.  6�   �� 5   
   -   5        $��Вихід у меню��5      
����������	#FFB85353$
��Left=�6R   $��25��6m   $��107,432,0,0q�6y   $	��Top=�6�   $	��142��6�   ���	#FFB858586�   �� 5   
   -   5        $%��Закрити програму��5      
����������	#FFB85353$
��Left=�6V   $��25��6q   $��455,432,0,0q�6}   $	��Top=�6�   $	��142��6�   ���	#FFB858586�   �� 5   
   ���	#FF3B3B3F$
��Left=�6%   $��4��6@   $��
27,130,0,0q�6K   $	��Top=�6_   $	��303��6w   �� 5   
   $
��Left=�6   $��60��6/   $��	29,69,0,0q�6;   $	��Top=�6N   $��20��6f   ���	#FFDC8C8C6q   �� 5   
   $
��Left=�6   $��53��6/   $��	49,76,0,0q�6;   $	��Top=�6N   $��14��6f   ���	#FFBA53536q   �� 5    
   ���	#FF94949C$
��Left=�6%   $��51��6@   $��	71,78,0,0q�6L   $	��Top=�6_   $��16��6w   $ 0.5,0.5&�6�   z�5!      V� 5"      .~�5#      �� �� 5$      �� 5%      $ -18.752Q�6&   T� 5&      5'      5)      �� 5*   
   $��Операції��6   $
��Left=�6#   $��40��6>   $��Center=�6J   $��Center=�6n   $��
109,82,0,0q�6�   $	��Top=�6�   $	��142��6�   ���	#FF3B3B3F$��20(�6�   $
��Bold"�6�   �� 5+   
   $
��Left=�6   $��53��6/   $��
261,77,0,0q�6;   $	��Top=�6O   $��14��6g   ���	#FFBA53536r   �� 5,   
   ���	#FF3B3B3F$
��Left=�6%   $��5��6@   $��	29,64,0,0q�6K   $	��Top=�6^   $	��303��6v   �� 5-   
   -   5        $9��3Добавити чи видалити читача��5-      $
��Left=�67   $��39��6R   $��
27,135,0,0q�6^   $	��Top=�6r   $	��303��6�   $��14(�6�   ���	#FFB65454
�������6�   �� 5.   
   -   5        $:��4Перереєстрація читачів/книг��5.      $
��Left=�67   $��39��6R   $��
27,339,0,0q�6^   $	��Top=�6r   $	��303��6�   $��14(�6�   ���	#FFBA5353
�������6�   �� 5/   
   
�������$
��Left=�6!   $	��385��6<   $��
372,31,0,0q�6I   
�������$	��Top=�6l   $	��477��6�    J� Effect 50      3  -System.Windows.Media.Effects.DropShadowEffect  51         
BlurRadius$ 30Q�6#      Color$ 	LightGray��63   53      �� 54   
   $:��4Додати примірник(и) існуючої��6   $
��Left=�67   $��38��6R   $��Center=�6^   $��Center=�6�   $��
372,31,0,0q�6�   $	��Top=�6�   $	��237��6�   
����������	#FF3B3B3F$��16(�6  �� 55   
   $:��4Видалити примірник існуючої��6   $
��Left=�66   $��38��6Q   $��Center=�6]   $��Center=�6�   $��372,188,0,0q�6�   $	��Top=�6�   $	��237��6�   
����������	#FF3B3B3F$��16(�6  �� 56   
   $2��,Видалити книги повністю��6   $
��Left=�62   $��38��6M   $��Center=�6Y   $��Center=�6}   $��372,311,0,0q�6�   $	��Top=�6�   $	��237��6�   
����������	#FF3B3B3F$��16(�6  �� 57   
   ���	#FF4B4B4D$
��Left=�6%   $	��385��6@   $��
608,31,0,0q�6M   
�������$	��Top=�6p   $��9��6�   �� 58   
   $*��$Добавити нові книги��6   $
��Left=�6.   $��38��6I   $��Center=�6U   $��Center=�6y   $��
617,31,0,0q�6�   $	��Top=�6�   $	��232��6�   
����������	#FF3B3B3F$��16(�6�   �� 59   
   $��Шифр книги��6   $
��Left=�6%   $��37��6@   $��
372,79,0,0q�6L   $	��Top=�6`   $	��113��6x   $��16(�6�   �� 5:   
   $��Чит. зал��6   $
��Left=�6#   $��37��6>   $��372,118,0,0q�6J   $	��Top=�6_   $	��113��6w   $��16(�6�   �� 5;   
   -   5        $��IDbook��5;   -   $
��Left=�6   $��31��6;   $��
485,79,0,0q�6G    �� TextWrapping$
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $��65��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5<   
   -	   5        $
��hall��5<   -   $
��Left=�6   $��31��69   $��485,115,0,0q�6E   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $��65��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5=   
   -
   5        $��Добавити��5=      $
��Left=�6$   $��31��6?   $��531,112,0,0q�6K   $	��Top=�6`   $	��103��6x   $ 0.5,0.5&�6�   ���	#FFB65454
�������z�5>      V� 5?      .~�5@      �� �� 5A      �� 5B      $ -89.701Q�6&   T� 5C      5D      5F      �� 5G   
   $��Шифр книги��6   $
��Left=�6%   $��37��6@   $��375,234,0,0q�6L   $	��Top=�6a   $	��113��6y   $��16(�6�   �� 5H   
   $��Чит. зал��6   $
��Left=�6#   $��37��6>   $��375,269,0,0q�6J   $	��Top=�6_   $	��113��6w   $��16(�6�   �� 5I   
   -   5        $��IDbook1��5I   -   $
��Left=�6   $��31��6<   $��488,232,0,0q�6H   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $��65��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5J   
   -   5        $��hall1��5J   -   $
��Left=�6   $��31��6:   $��488,273,0,0q�6F   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $��65��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5K   
   -   5        $��Видалити��5K      $
��Left=�6$   $��31��6?   $��547,253,0,0q�6K   $	��Top=�6`   $��77��6x   $ 0.5,0.5&�6�   ���	#FFB65454
�������z�5L      V� 5M      .~�5N      �� �� 5O      �� 5P      $ -89.701Q�6&   T� 5Q      5R      5T      �� 5U   
   $��Шифр книги��6   $
��Left=�6%   $��37��6@   $��375,361,0,0q�6L   $	��Top=�6a   $	��113��6y   $��16(�6�   �� 5V   
   -   5        $��IDbook2��5V   -   $
��Left=�6   $��31��6<   $��485,364,0,0q�6H   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $��65��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5W   
   -   5        $��Видалити��5W      $
��Left=�6$   $��31��6?   $��558,368,0,0q�6K   $	��Top=�6`   $��61��6x   $ 0.5,0.5&�6�   ���	#FFB65454
�������z�5X      V� 5Y      .~�5Z      �� �� 5[      �� 5\      $ -89.701Q�6&   T� 5]      5^      5`      �� 5a   
   $��
Назва��6   $
��Left=�6    $��36��6;   $��
622,77,0,0q�6G   $	��Top=�6[   $��72��6s   $��16(�6~   �� 5b   
   $��Рік публ.��6   $
��Left=�6$   $��36��6?   $��622,112,0,0q�6K   $	��Top=�6`   $	��115��6x   $��16(�6�   �� 5c   
   $��Видавництво��6   $
��Left=�6&   $��36��6A   $��622,148,0,0q�6M   $	��Top=�6b   $	��115��6z   $��16(�6�   �� 5d   
   $��Автор(и)*��6   $
��Left=�6$   $��36��6?   $��622,184,0,0q�6K   $	��Top=�6`   $	��115��6x   $��16(�6�   �� 5e   
   $��К-сть в 1 залі��6   $
��Left=�6)   $��36��6D   $��622,245,0,0q�6P   $	��Top=�6e   $	��106��6}   $��16(�6�   �� 5f   
   $��К-сть в 2 залі��6   $
��Left=�6)   $��36��6D   $��622,281,0,0q�6P   $	��Top=�6e   $	��106��6}   $��16(�6�   �� 5g   
   $��К-сть в 3 залі��6   $
��Left=�6)   $��36��6D   $��622,317,0,0q�6P   $	��Top=�6e   $	��106��6}   $��16(�6�   �� 5h   
   -   5        $��Добавити��5h      $
��Left=�6$   $��31��6?   $��664,363,0,0q�6K   $	��Top=�6`   $	��138��6x   ���	#FFAD5555
�������$��16(�6�   6�   �� 5i   
   -   5        $��bname��5i   -   $
��Left=�6   $��28��6:   $��
694,79,0,0q�6F   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��140��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5j   
   -   5        $
��year��5j   9   $
��Left=�6   $��28��6-   $��704,115,0,0q�6E   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��130��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5k   
   -   5        $
��publ��5k   9   $
��Left=�6   $��28��6-   $��737,153,0,0q�6E   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $��97��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5l   
   -   5        $��author��5l   9   $
��Left=�6   $��28��6-   $��704,192,0,0q�6G   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��130��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5m   
   -   5        $��hall1c��5m   9   $
��Left=�6   $��28��6-   $��733,248,0,0q�6G   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��101��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5n   
   -   5        $��hall2c��5n   9   $
��Left=�6   $��28��6-   $��733,284,0,0q�6G   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��101��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5o   
   -   5        $��hall3c��5o   9   $
��Left=�6   $��28��6-   $��733,320,0,0q�6H   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��101��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5p   
   $��Кількість��6   $
��Left=�6$   $��37��6?   $��372,151,0,0q�6K   $	��Top=�6`   $	��113��6x   $��16(�6�   �� 5q   
   -   5        $��count��5q   -   $
��Left=�6   $��31��6:   $��485,151,0,0q�6F   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $��65��6�   $��16(�6�   ���	#FFEAEBF16�   �� 5r   
   $6��0*якщо декілька - через кому��6   $
��Left=�66   $��28��6Q   $��622,216,0,0q�6]   $	��Top=�6r   $	��188��6�   ���	#FFB654546�   5t      5u      