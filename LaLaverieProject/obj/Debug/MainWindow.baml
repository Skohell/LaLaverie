   M S B A M L   `   `   `  ����K  GLaLaverieProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LaLaverieProjectLaLaverieProject  5   	   !    LaLaverieProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LaLaverieProject     5   	     � Icon$  /Images/icon.png��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ La Laverie - Bienvenue��5
   	   $	��780��6(   $	��600��68   $	��780��6G   $	��600��6W   .��5      � ��5   
   �� 5       j� Stretch$
 None=�6    �� ImageSource$ Images/MainPage.png��6(    j� 
AlignmentY$	 Top=�6J    j� 
AlignmentX$ Center=�6[   .+�5   
   �� -   5        $��MyFadingText��5   6      loading#���   6   Cliquer pour entrer... � Triggers 5      :� 5       :� RoutedEvent$ TextBlock.Loaded��6   .[�5      �� .��5      �� .��5      W� 	 �� 
TargetName$	 MyFadingText��5      
 �� TargetProperty$
 (TextBlock.Opacity)�5       W� From$	 1.0X�5      	 W� To$	 0.0X�6    g� Duration$ 0:0:1D�6!    g� AutoReverse .  g� RepeatBehavior$ Forever��5       5      5      5      5      �� 5!   
     
mainButton#���  64   ��6   �� *OnClickCommand+64   5"      5#      