   M S B A M L   `   `   `  ����B  >library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:librarylibrary  5   	   +    %library.Добавити_читача   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:library     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$9 3Добавити чи видалити читача��5   	   $��507.6��6-   $	��728��6<   ���	#FFEAEBF1.��5	      � .+�5
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
27,289,0,0q�6\   $	��Top=�6p   $	��303��6�   $��14(�6�   ���	#FFBA5353
�������6�   �� 5   
   -   5        $��Вихід у меню��5      
����������	#FFB85353$
��Left=�6R   $��25��6m   $��109,439,0,0q�6y   $	��Top=�6�   $	��142��6�   ���	#FFB858586�   �� 5   
   -   5        $%��Закрити програму��5      
����������	#FFB85353$
��Left=�6V   $��25��6q   $��455,439,0,0q�6}   $	��Top=�6�   $	��142��6�   ���	#FFB858586�   �� 5   
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
   $9��3Добавити чи видалити читача��6   {�.  $
��Left=�6I   $��39��6d   $��
27,135,0,0q�6p   $	��Top=�6�   $	��303��6�   $��14(�6�   ���	#FFB65454���	#FF3D3D416�   �� 5.   
   
�������$
��Left=�6!   $	��396��6<   $��
372,31,0,0q�6I   
�������$	��Top=�6l   $	��315��6�    J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50         
BlurRadius$ 30Q�6#      Color$ 	LightGray��63   52      �� 53   
   $#��Добавити читача��6   $
��Left=�6*   $��38��6E   $��Center=�6Q   $��Center=�6u   $��
372,31,0,0q�6�   $	��Top=�6�   $	��315��6�   
����������	#FF3B3B3F$��18(�6�   �� 54   
   $��Прізвище��6   $
��Wrap=�6$   $
��Left=�68   $��29��6S   $��
384,82,0,0q�6_   $	��Top=�6s   $��78��6�   $��14(�6�   �� 55   
   $!��Номер паспорту��6   $
��Wrap=�6*   $
��Left=�6>   $��29��6Y   $��384,111,0,0q�6e   $	��Top=�6z   $	��116��6�   $��14(�6�   �� 56   
   $#��Дата народження��6   $
��Wrap=�6+   $
��Left=�6?   $��29��6Z   $��384,140,0,0q�6f   $	��Top=�6{   $	��116��6�   $��14(�6�   �� 57   
   $��Адреса��6   $
��Wrap=�6"   $
��Left=�66   $��29��6Q   $��384,169,0,0q�6]   $	��Top=�6r   $	��116��6�   $��14(�6�   �� 58   
   $��Освіта��6   $
��Wrap=�6"   $
��Left=�66   $��29��6Q   $��384,221,0,0q�6]   $	��Top=�6r   $	��116��6�   $��14(�6�   �� 59   
   $'��!Наявність наук.ст.��6   $
��Wrap=�6.   $
��Left=�6B   $��29��6]   $��384,245,0,0q�6i   $	��Top=�6~   $	��116��6�   $��14(�6�   �� 5:   
   $#��Дата реєстрації��6   $
��Wrap=�6+   $
��Left=�6?   $��29��6Z   $��384,294,0,0q�6f   $	��Top=�6{   $	��116��6�   $��14(�6�   �� 5;   
   $#��Видалити читача��6   $
��Left=�6*   $��33��6E   $��Center=�6Q   $��Center=�6u   $��372,355,0,0q�6�   $	��Top=�6�   $	��315��6�   
����������	#FF3B3B3F$��18(�6�   �� 5<   
   $��Чит. квиток��6   $
��Wrap=�6'   $
��Left=�6;   $��29��6V   $��384,398,0,0q�6b   $	��Top=�6w   $��95��6�   $��14(�6�   �� 5=   
   -   5        $��Surname��5=   -   $
��Left=�6   $��20��6<   $��Center=�6H   $��
510,82,0,0q�6l    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��157��6�   $��14(�6�   ���	#FFE0E1E66�   �� 5>   
   -   5        $��Passport��5>   -   $
��Left=�6   $��Center=�6=   $��20��6b   $��510,108,0,0q�6n   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��157��6�   $��14(�6�   ���	#FFE0E1E66�   �� 5?   
   -   5        $��Birthday��5?   -   $
��Left=�6   $��Center=�6=   $��20��6b   $��510,136,0,0q�6n   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��157��6�   $��14(�6�   ���	#FFE0E1E66�   �� 5@   
   -	   5        $��Adres��5@   -   $
��Left=�6   $��Center=�6:   $��20��6^   $��510,165,0,0q�6j   $
 Wrap=�6   $�� ��6�   $	��Top=�6�   $	��157��6�   $��14(�6�   ���	#FFE0E1E66�   �� 5A   
   -
   5        $��Registr��5A   -   $
��Left=�6   $��Center=�6<   $��20��6`   $��510,297,0,0q�6l   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��157��6�   $��14(�6�   ���	#FFE0E1E66�   �� 5B   
   -   5        $��Добавити��5B      $
��Left=�6$   $��22��6?   $��473,328,0,0q�6K   $	��Top=�6`   $	��124��6x   
����������	#FFBA53536�   �� 5C   
   -   5        $��Ed��5C   .   $
��Left=�6   $��20��68   $��Center=�6D   $��510,217,0,0q�6h   $	��Top=�6}   $	��157��6�   .@�5D      �� -   5        $
��one1��5D      початкова6/   �� 5E      -   5        $
��two1��5E      середня6-   �� 5F      -   5        $��three1��5F      
вища6,   5G      �� 5H   
   -   5        $��Dg��5H   .   $
��Left=�6   $��Center=�68   $��20��6\   $��510,244,0,0q�6h   $	��Top=�6}   $	��157��6�    �� SelectedIndex$ 0��6�   
���   �.@�5I      �� -   5        	 ��Name$		 one��5I      
немає6,   �� 5J      -   5        $		 two��5J      є6(   5K      �� 5L   
   $!��Номер телефону��6   $
��Wrap=�6*   $
��Left=�6>   $��29��6Y   $��384,194,0,0q�6e   $	��Top=�6z   $	��116��6�   $��14(�6�   �� 5M   
   -   5        
 ��Name$
 Teleph��5M   -   $
��Left=�6   $��Center=�6=   $��20��6a   $��510,191,0,0q�6m   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��157��6�   $��14(�6�   ���	#FFE0E1E66�   �� 5N   
   $��Чит. зал��6   $
��Wrap=�6$   $
��Left=�68   $��29��6S   $��384,271,0,0q�6_   $	��Top=�6t   $	��116��6�   $��14(�6�   �� 5O   
   -   5        $

 Hall��5O   -   $
��Left=�6   $��Center=�6;   $��20��6_   $��510,271,0,0q�6k   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��157��6�   $��14(�6�   ���	#FFE0E1E66�   �� 5P   
   -   5        $

 idid��5P   -   $
��Left=�6   $��Center=�6;   $��20��6_   $��473,398,0,0q�6k   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $��91��6�   $��14(�6�   ���	#FFE0E1E66�   �� 5Q   
   -   5        $��Видалити��5Q      $
��Left=�6$   $��22��6?   $��579,398,0,0q�6K   $	��Top=�6`   $��93��6x   
����������	#FFBA53536�   �� 5R   
   -   5        $:��4Перереєстрація читачів/книг��5R      $
��Left=�67   $��39��6R   $��
29,339,0,0q�6^   $	��Top=�6r   $	��303��6�   $��14(�6�   ���	#FFBA5353
�������6�   5S      5T      