   M S B A M L   `   `   `  ����J  FEasyLuckyNumber, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EasyLuckyNumberEasyLuckyNumber  5   	       EasyLuckyNumber.Settings   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:EasyLuckyNumber     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	   $��./assets/fonts/#Nunito)�5   	    � Title$ Settings��5   	   $	��700��6   $	��550��6'   .��5      � .+�5   
   �� -   5        $��title��5      $	��128��6!   $��44��6-   $��CÀI ĐẶT��69   $��32(�6H   $
��Bold"�6V   $��211 32 211 624q�6h   ���#3D3D3D$1��+pack://application:,,,/assets/fonts/#Nunito)�5      �� 5   
   $	��418��6   $��66 90 66 610q�6    $��1��66   ���#C3C3C36A   �� 5   
   $��File dữ liệu��6   $��38��6(   $��32(�64   $
��Bold"�6B   $��66,114,313,548q�6T   ���#3D3D3D$1��+pack://application:,,,/assets/fonts/#Nunito)�5      �� 5   
   -   5         ��Name$ dataFilePath��5      $	��350��6(   $��52��64    �� 
IsReadOnly$
 True��6@   ���#ECECEC$��66 163 134 485q�6g   $��24(�6   $��Center=�6�   �� 5   
   -   5         ��Name$ dataFileButton��5      $��52��6)   $��52��64   $��432 163 66 485q�6@   ��5      �� 5      $��./assets/file.png��6   $
��None=�63   5      �� 5   
   $����File dữ liệu phải là file Excel (.xlsx). Trong đó cột đầu tiên là các số để random. Cột thứ hai (có thể không có) là tên hiển thị tương ứng với số đó��6   $	��418��5      $��66��6    $
��Wrap=�6,   $��16(�6@   $��Italic$�6N   $��66 226 66 408q�5      �� 5   
   $!��Phông chữ và cỡ chữ��6   $��38��6/   $��32(�6;   $
��Bold"�6I   $��66,306,171,356q�6[   ���#3D3D3D6s   �� 5    
   -   5         ��Name$ fontFamilyInput��5       $	��350��6,   $��52��68   $��24(�6D   $��Center=�6R   ���#ECECEC$��66 358 134 290q�6�   �� 5!   
   -   5        $ fontSizeInput��5!      $��52��6)   $��52��64   $��432 358 66 290q�6@    � 
InputScope$ Number��6X   	 �� 	MaxLength$	 3��6l   $��24(�6z   $��Center=�6�   �� 5#   
   $��Hình nền��6   $	��266��6$   $��38��60   $��32(�6<   $
��Bold"�6J   $��66 434 218 228q�6\   ���#3D3D3D6t   �� 5$   
   -   5        $ backgroundPath��5$      $	��350��6*   $��52��66   $
 True��6B   ���#ECECEC$��66 483 134 165q�6i   $��24(�6�   $��Center=�6�   �� 5%   
   -   5        $ backgroundFile��5%      $��52��6)   $��52��64   $��432 483 66 165q�6@   ��5&      �� 5'      $��./assets/file.png��6   $
��None=�63   5)      �� 5+   
   -   5        $ finishButton��5+      $	��219��6'   $��52��63   ���#74B369$��HOÀN THÀNH��6T   $��28(�5,      $
��Bold"�6   
�������$��165 604 166 44q�6D   �� 5.   
   -	   5        
 ��Name$
 
exitButton��5.      $��16��6(   $��38��63   $��x��6?   $��28(�6H   $
��Bold"�6V   $��521 4 13 658q�5/      51      52      