   M S B A M L   `   `   `  ���� J  FEasyLuckyNumber, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EasyLuckyNumberEasyLuckyNumber      EasyLuckyNumber.Settings   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:EasyLuckyNumber       � WindowStartupLocation$  CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�$��./assets/fonts/#Nunito)� � Title$ Settings��$	��700��$	��550��.��� .+��� -   $��title��$	��128��$��44��$��CÀI ĐẶT��$��32(�$
��Bold"�$��211 32 211 624q����#3D3D3D$1��+pack://application:,,,/assets/fonts/#Nunito)��� $	��418��$��66 90 66 610q�$��1�����#C3C3C3�� $��File dữ liệu��$��38��$��32(�$
��Bold"�$��66,114,313,548q����#3D3D3D$1��+pack://application:,,,/assets/fonts/#Nunito)��� -    ��Name$ dataFilePath��$	��350��$��52�� �� 
IsReadOnly$
 True�����#ECECEC$��66 163 134 485q�$��24(�$��Center=��� -    ��Name$ dataFileButton��$��52��$��52��$��432 163 66 485q����� $��./assets/file.png��$
��None=��� $����File dữ liệu phải là file Excel (.xlsx). Trong đó cột đầu tiên là các số để random. Cột thứ hai (có thể không có) là tên hiển thị tương ứng với số đó��$	��418��$��66��$
��Wrap=�$��16(�$��Italic$�$��66 226 66 408q��� $!��Phông chữ và cỡ chữ��$��38��$��32(�$
��Bold"�$��66,306,171,356q����#3D3D3D�� -    ��Name$ fontFamilyInput��$	��350��$��52��$��24(�$��Center=����#ECECEC$��66 358 134 290q��� -   $ fontSizeInput��$��52��$��52��$��432 358 66 290q� � 
InputScope$ Number��	 �� 	MaxLength$	 3��$��24(�$��Center=��� $��Hình nền��$	��266��$��38��$��32(�$
��Bold"�$��66 434 218 228q����#3D3D3D�� -   $ backgroundPath��$	��350��$��52��$
 True�����#ECECEC$��66 483 134 165q�$��24(�$��Center=��� -   $ backgroundFile��$��52��$��52��$��432 483 66 165q����� $��./assets/file.png��$
��None=��� -   $ finishButton��$	��219��$��52�����#74B369$��HOÀN THÀNH��$��28(�$
��Bold"�
�������$��165 604 166 44q��� -	   
 ��Name$
 
exitButton��$��16��$��38��$��x��$��28(�$
��Bold"�$��521 4 13 658q�