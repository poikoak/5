   M S B A M L   `   `   `  ����N  JWpfKinopoiskLinkSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfKinopoiskLinkSQLWpfKinopoiskLinkSQL  5   	   !    WpfKinopoiskLinkSQL.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfKinopoiskLinkSQL     5   	     � Title$  Window1��5   	   $	��200��6   $	��300��6&    � WindowStartupLocation$ CenterScreen=�62   .��5	      � -   5         �Name$ MainRoot��5	      
������� J� RenderTransformOrigin$ 0.274,0.497&�60    � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��26* �6   �� 5      $	��50* �6   .+�5   
   �� $��1��6   $��0��6"   $��First name :��63   $��Arial Black)�6H   $��15(�6a   &   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6o   �� 5   
   $��1��6   $��1��6   $��Arial Black)�62   $��10(�6K   �� 5   
   $��3��6   $��0��6!   $��Last name :��62   $��Arial Black)�6F   $��15(�6_   �� 5   
   $��3��6   $��1��6   $��Arial Black)�62   $��10(�6K   �� 5    
   $��5��6   $��0��6!   $��Birthdate :��62   $��Arial Black)�6F   $��15(�6_   (  "System.Windows.Controls.DatePicker  5!   
   $��5��6   $��1��6"   $��Arial Black)�65   $��10(�6N   �� 5"   
   -   5         �� TextAlignment$ Center=�5"      $��6��62   $��0��6?   $��80��6O   $	��Add��6Z   $��40,13,172,9q�6h   $��2��6�   $��2��6�   �� 5#   
   -   5        $��6��5#      $��1��6   $��80��6.   $ Center=�69   $��Close��6Z   $��
60,13,52,9q�6�   $��2��6�   5$      5%      