   M S B A M L   `   `   `  ����K  GLaLaverieProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:LaLaverieProject.ViewLaLaverieProject.View  5   	   .    (LaLaverieProject.View.AjouterBiereWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:LaLaverieProject.View     5   	      WindowBrush#���   5   	     � Icon$  ../Images/icon.png��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$! La Laverie - Ajouter Bière��5   	   $	��800��6,   $	��800��6<   $	��800��6L   $	��800��6\   .��5      �  � RowDefinitions 5   
   �� 5      $	��169 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6    � ColumnDefinitions 5   
   �� 5        columnLabel#���  6   �� 5      �� 5      #���  6   �� 5      .+�5    
   �� $��4��6   $��../Images/Titre.png��6$   �� 5!   
   $��1��6   $	��Nom��6   �� 5"   
   $��2��6   $��	Categorie��6   �� 5#   
   $��3��6   $��Description��6   �� 5$   
   $��4��6   $��Alcool��6   �� 5%   
   $��5��6   $��Amertume��6   �� 5&   
   $��6��6   $
��Prix��6   �� 5'   
   $��7��6   $��Image��6   �� 5(   
   $��1��6   $��1��6"     attribut#���  6P   ��60   �� *BiereToAdd.Nom+6P   �� 5)   
   $��1��6   $��2��6#     ComboBoxAttribut#���  6�   ��60   �� *ListeCategorie+ �� SelectedItem 6W   �� *SelectedCategorie+6�   �� 5*   
   $��1��6   $��3��6"   #���  6X   ��60   �� *BiereToAdd.Description+6X   �� 5+   
   $��1��6   $��4��6"   #���  6S   ��60   �� *BiereToAdd.Alcool+6S   �� 5,   
   $��1��6   $��5��6"   #���  6U   ��60   �� *BiereToAdd.Amertume+6U   �� 5-   
   $��1��6   $��6��6"   #���  6Q   ��60   �� *BiereToAdd.Prix+6Q   �� 5.   
   $��1��6   $��7��6!   $��Ajouter une Image��6/   ��6K   �� *OnImageCommand+�� 50   
   $��2��6   $��1��6    $��	Quantité��6-   �� 51   
   $��2��6   $��2��6    $��Empatage��6-   �� 52   
   $��2��6   $��3��6    $��Brassin��6-   �� 53   
   $��2��6   $��4��6    $��Fermentation��6-   �� 54   
   $��2��6   $��5��6    $��Embouteillage��6-   �� 55   
   $��2��6   $��6��6    $��Garde��6-   �� 56   
   $��3��6   $��1��6"   #���  6X   ��60   �� *BiereToAdd.NbBouteille+6X   �� 57   
   $��3��6   $��2��6"   #���  6U   ��60   �� *BiereToAdd.Empatage+6U   �� 58   
   $��3��6   $��3��6"   #���  6T   ��60   �� *BiereToAdd.Brassin+6T   �� 59   
   $��3��6   $��4��6"   #���  6Y   ��60   �� *BiereToAdd.Fermentation+6Y   �� 5:   
   $��3��6   $��5��6"   #���  6Z   ��60   �� *BiereToAdd.Embouteillage+6Z   �� 5;   
   $��3��6   $��6��6"   #���  6Y   ��60   �� *BiereToAdd.Conservation+6Y   �� 5=   
   $��2��6   $��8��6%   $��Valider��62   ��6D   �� *OnNewBiereCommand+5>      5?      